using RestCountries.Domain.Regions;

namespace RestCountriesWebApp.Models
{
  public class RegionViewModel
  {
    public Region Region { get; set; }

    public RegionViewModel(Region region)
    {
      Region = region;
    }
  }
}