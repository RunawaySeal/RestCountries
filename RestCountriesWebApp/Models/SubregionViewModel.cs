using RestCountries.Domain.Subregions;

namespace RestCountriesWebApp.Models
{
  public class SubregionViewModel
  {
    public Subregion Subregion { get; set; }

    public SubregionViewModel(Subregion subregion)
    {
      Subregion = subregion;
    }
  }
}