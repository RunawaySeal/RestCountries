using Microsoft.AspNetCore.Mvc;
using RestCountries.ApplicationServices.Subregions;
using RestCountriesWebApp.Models;

namespace RestCountriesWebApp.Controllers
{
  [ResponseCache(Duration = 28800)]
  public class SubregionsController : Controller
  {
    private readonly SubregionService _subregionService;

    public SubregionsController(SubregionService subregionService)
    {
      _subregionService = subregionService;
    }

    [Route("Subregion/{name}")]
    public async Task<IActionResult> Index(string name)
    {
      var subregion = await _subregionService.GetSubegionAsync(name);
      if (_subregionService.HasError)
        return NotFound(_subregionService.LastErrorMessage);

      var model = new SubregionViewModel(subregion);
      return View(model);
    }
  }
}