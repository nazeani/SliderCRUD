using Microsoft.AspNetCore.Mvc;
using Pronia.Business.Services.Abstracts;
using System.Diagnostics;

namespace _8may.Controllers
{
    //[Area("Admin")]
    public class HomeController : Controller
    {
        IFeatureService _featureService;
        public HomeController(IFeatureService featureService)
        {
            _featureService = featureService;
        }
        public IActionResult Index()
        {
            var features = _featureService.GetAll();
            return View(features);
        }

    }
}
