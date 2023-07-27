using RestCountries.Domain;
using RestCountries.Domain.Countries;
using RestCountries.Domain.Regions;
using RestCountries.Infrastructure.Countries;
using Serilog;
using System.Net;

namespace RestCountries.ApplicationServices.Countries
{
  // Country Service
  // Ability to get all countries - with pagination and filtering by name
  // Ability to get country by its name
  public class CountryService : BaseService
  {
    private readonly ICountryRepo _countryRepo;
    public CountryService(ILogger logger, ICountryRepo countryRepo) : base(logger)
    {
      _countryRepo = countryRepo;
    }

    public async Task<Response<Country>> GetAllCountriesAsync(SearchFilters searchFilters)
    {
      try
      {
        return await _countryRepo.GetCountriesAsync(searchFilters);
      }
      catch (Exception ex)
      {
        SetDomainError(HttpStatusCode.NotFound, ex.Message);
        return default;
      }
    }

    public async Task<Country> GetCountry(string name)
    {
      try
      {
        return await _countryRepo.GetCountryAsync(name);
      }
      catch (Exception ex)
      {
        SetDomainError(HttpStatusCode.NotFound, ex.Message);
        return default;
      }
    }
  }
}
