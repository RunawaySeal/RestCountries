using Newtonsoft.Json;
using RestCountries.Domain;
using RestCountries.Domain.Countries;

namespace RestCountries.Infrastructure.Countries
{
  // Countries Repo
  // Ability to get all countries - with pagination and filtering by name
  // Ability to get country by its name
  // Ability to get all countries by cca2, ccn3, cca3 or cioc country code.
  // Ability to get all countries that are related to a region using the region name.
  // Ability to get all countries that are related to a subregion using the subregion name.
  public class CountryRepo : BaseRepo, ICountryRepo
  {
    //Custom contains to ignore case and only compare if value2 is set
    private static bool Contains(string value1, string value2) => 
      value1.ToLower().Contains(string.IsNullOrWhiteSpace(value2) ? value1.ToLower() : value2.ToLower());

    public async Task<Response<Country>> GetCountriesAsync(SearchFilters searchFilters)
    {
      using var httpClient = new HttpClient();
      var countriesJson = await httpClient.GetStringAsync($"{BaseUrl}all");

      var countryDtos = JsonConvert.DeserializeObject<List<CountryDto>>(countriesJson)?
        .Where(c => Contains(c.Name.Official, searchFilters.SearchName) &&
                    Contains(c.Region, searchFilters.SearchRegion) &&
                    Contains(c.Subregion, searchFilters.SearchSubregion));

      var countries = countryDtos?
        .Skip(searchFilters.PageSize * (searchFilters.PageNumber - 1))
        .Take(searchFilters.PageSize)
        .Select(c => new Country(c));

      return new Response<Country>()
      {
        TotalResults = countryDtos?.Count() ?? 0,
        Results = countries ?? new List<Country>()
      };
    }

    public async Task<List<Country>> GetCountriesByCodeAsync(List<string> codes)
    {
      using var httpClient = new HttpClient();
      var codeString = string.Join(',', codes);
      var countriesJson = await httpClient.GetStringAsync($"{BaseUrl}alpha?codes={codeString}");

      var countryDtos = JsonConvert.DeserializeObject<List<CountryDto>>(countriesJson);
      var countries = countryDtos?.Select(c => new Country(c)).ToList();

      return countries ?? new List<Country>();
    }

    public async Task<List<Country>> GetCountriesByRegionAsync(string region)
    {
      using var httpClient = new HttpClient();
      var countriesJson = await httpClient.GetStringAsync($"{BaseUrl}region/{region}");

      var countryDtos = JsonConvert.DeserializeObject<List<CountryDto>>(countriesJson);
      var countries = countryDtos?.Select(c => new Country(c, true)).ToList();

      return countries ?? new List<Country>();
    }

    public async Task<List<Country>> GetCountriesBySubregionAsync(string subregion)
    {
      using var httpClient = new HttpClient();
      var countriesJson = await httpClient.GetStringAsync($"{BaseUrl}subregion/{subregion}");

      var countryDtos = JsonConvert.DeserializeObject<List<CountryDto>>(countriesJson);
      var countries = countryDtos?.Select(c => new Country(c, true)).ToList();

      return countries ?? new List<Country>();
    }

    public async Task<Country> GetCountryAsync(string name)
    {
      using var httpClient = new HttpClient();
      var countriesJson = await httpClient.GetStringAsync($"{BaseUrl}name/{name}");

      var countryDto = JsonConvert.DeserializeObject<List<CountryDto>>(countriesJson)?.FirstOrDefault();
      if (countryDto == null)
        return new Country();

      var country = new Country(countryDto, true);

      if (countryDto.Borders.Any())
      {
        // This is given as a list of codes so we need to get the countries by the codes.
        // Then set the border countries once we have the official names.
        var borderCountries = await GetCountriesByCodeAsync(countryDto.Borders);
        country.SetBorderCountries(borderCountries);
      }

      return country;
    }
  }
}
