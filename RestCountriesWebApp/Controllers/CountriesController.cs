using Microsoft.AspNetCore.Mvc;
using RestCountries.ApplicationServices.Countries;
using RestCountries.Domain.Countries;
using RestCountriesWebApp.Models;

namespace RestCountriesWebApp.Controllers
{
  [ResponseCache(Duration = 28800)]
  public class CountriesController : Controller
  {
    private readonly CountryService _countryService;

    public CountriesController(CountryService countryService)
    {
      _countryService = countryService;
    }

    public IActionResult Index()
    {
      return View();
    }

    public async Task<IActionResult> List(int pageNo = 1, int pageSize = 20, string searchName = "", string searchRegion = "", string searchSubregion = "")
    {
      var filters = new SearchFilters() 
      { 
        PageNumber = pageNo,
        PageSize = pageSize,
        SearchName = searchName,
        SearchRegion = searchRegion,
        SearchSubregion = searchSubregion
      };

      var response = await _countryService.GetAllCountriesAsync(filters);
      if (_countryService.HasError)
        return NotFound(_countryService.LastErrorMessage);

      var model = new CountriesViewModel(response.Results.ToList(), filters, response.TotalResults);
      return PartialView("_CountryList", model);
    }

    [Route("Country/{name}")]
    public async Task<IActionResult> Country(string name)
    {
      var country = await _countryService.GetCountry(name);
      if (_countryService.HasError)
        return NotFound(_countryService.LastErrorMessage);

      var model = new CountryViewModel(country);
      return View("Country", model);
    }
  }
}