using RestCountries.Domain.Countries;

namespace RestCountriesWebApp.Models
{
  public class CountryViewModel
  {
    public Country Country { get; set; }

    public CountryViewModel(Country country)
    {
      Country = country;
    }
  }
}