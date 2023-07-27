using RestCountries.Domain;
using RestCountries.Domain.Countries;

namespace RestCountries.Infrastructure.Countries
{
  public interface ICountryRepo
  {
    public Task<Response<Country>> GetCountriesAsync(SearchFilters searchFilters);
    public Task<List<Country>> GetCountriesByCodeAsync(List<string> codes);
    public Task<List<Country>> GetCountriesByRegionAsync(string region);
    public Task<List<Country>> GetCountriesBySubregionAsync(string subregion);
    public Task<Country> GetCountryAsync(string name);
  }
}
