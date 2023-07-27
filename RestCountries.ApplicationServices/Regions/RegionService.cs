using RestCountries.Domain.Regions;
using RestCountries.Domain.Subregions;
using RestCountries.Infrastructure.Countries;
using Serilog;
using System.Net;

namespace RestCountries.ApplicationServices.Regions
{
  // Region Service
  // Ability to get region by its name - gets a list of countries in region and constructs a region object.
  public class RegionService : BaseService
  {
    private readonly ICountryRepo _countryRepo;
    public RegionService(ILogger logger, ICountryRepo countryRepo) : base(logger) 
    {
      _countryRepo = countryRepo;
    }

    public async Task<Region> GetRegionAsync(string regionName)
    {
      try
      {
        var countries = await _countryRepo.GetCountriesByRegionAsync(regionName);
        var region = new Region(countries);
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
