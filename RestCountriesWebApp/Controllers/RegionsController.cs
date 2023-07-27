using Microsoft.AspNetCore.Mvc;
using RestCountries.ApplicationServices.Regions;
using RestCountriesWebApp.Models;

namespace RestCountriesWebApp.Controllers
{
  [ResponseCache(Duration = 28800)]
  public class RegionsController : Controller
  {
    private readonly RegionService _regionService;

    public RegionsController(RegionService regionService)
    {
      _regionService = regionService;
    }

    [Route("Region/{name}")]
    public async Task<IActionResult> Index(string name)
    {
      var region = await _regionService.GetRegionAsync(name);
      if (_regionService.HasError)
        return NotFound(_regionService.LastErrorMessage);

      var model = new RegionViewModel(region);
      return View(model);
    }
  }
}