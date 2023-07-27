using RestCountries.Domain.Countries;

namespace RestCountriesWebApp.Models
{
  public class CountriesViewModel
  {
    public List<Country> Countries { get; set; }
    public SearchFilters SearchFilters { get; set; }
    public int TotalPages { get; set; }

    public CountriesViewModel(List<Country> countries, SearchFilters searchFilters, int totalCountries = 0)
    {
      Countries = countries;
      SearchFilters = searchFilters;
      TotalPages = (totalCountries + SearchFilters.PageSize - 1) / SearchFilters.PageSize; // Rounds up division for last page.
    }
  }
}