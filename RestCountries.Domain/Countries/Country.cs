namespace RestCountries.Domain.Countries
{
  public class Country
  {
    public string Name { get; set; } = string.Empty;
    public string Region { get; set; } = string.Empty;
    public string Subregion { get; set; } = string.Empty;
    public int Population { get; set; }
    public List<string> Capitals { get; set; } = new List<string>();
    public List<string> Currencies { get; set; } = new List<string>();
    public List<string> Languages { get; set; } = new List<string>();
    public List<Country> BorderCountries { get; set; } = new List<Country>();

    public Country() { }

    public Country(CountryDto countryDto, bool setDetails = false)
    {
      Name = countryDto.Name.Official;
      Region = countryDto.Region;
      Subregion = countryDto.Subregion;

      // Only set more details if required/needed
      // By default we this is false and only return a object with only basic info set.
      if(setDetails) 
        SetDetails(countryDto);
    }

    public void SetDetails(CountryDto countryDto)
    {
      Capitals = countryDto.Capital;
      Population = countryDto.Population;

      Currencies = countryDto.Currencies.Select(c => $"{c.Key} - ({c.Value.Symbol}){c.Value.Name}").ToList();
      Languages = countryDto.Languages.Select(c => c.Value).ToList();
    }

    public void SetBorderCountries(List<Country> countries)
    {
      BorderCountries = countries;
    }
  }
}
