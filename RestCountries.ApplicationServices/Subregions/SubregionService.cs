using RestCountries.Domain.Subregions;
using RestCountries.Infrastructure.Countries;
using Serilog;
using System.Net;

namespace RestCountries.ApplicationServices.Subregions
{
  // Subregion Service
  // Ability to get subregion by its name - gets a list of countries in subregion and constructs a subregion object.
  public class SubregionService : BaseService
  {
    private readonly ICountryRepo _countryRepo;
    public SubregionService(ILogger logger, ICountryRepo countryRepo) : base(logger)
    {
      _countryRepo = countryRepo;
    }

    public async Task<Subregion> GetSubegionAsync(string regionName)
    {
      try
      {
        var countries = await _countryRepo.GetCountriesByRegionAsync(regionName);
        var region = new Subregion(countries);
        return region;
      }
      catch (Exception ex)
      {
        SetDomainError(HttpStatusCode.NotFound, ex.Message);
        return default;
      }
    }
  }
}
