using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Pronia.Business.Services.Abstracts;
using Pronia.Core.Models;

namespace _8may.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class FeatureController : Controller
    {
       
        private readonly IFeatureService _featureService;
        public FeatureController(IFeatureService featureService)
        {
           _featureService = featureService;
        }
        public IActionResult Index()
        {
            var features = _featureService.GetAll();
            return View(features);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Feature feature)
        {
            if (feature == null) return NotFound();
            _featureService.AddF(feature);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var dfeature = _featureService.Get(x => x.Id== id);
            if(dfeature == null)  return NotFound(); 
            return View(dfeature);
        }
        [HttpPost]
        public IActionResult DeletePost(int id)
        {
            _featureService.DeleteF(id);
            return RedirectToAction("Index");
        }
        public IActionResult Update(int id2)
        {
            var ufeature = _featureService.Get(x => x.Id == id2);
            if (ufeature == null)  return NotFound(); 
            return View(ufeature);
        }
        [HttpPost]
        public IActionResult UpdatePost(Feature feature)
        {
            if (feature == null) return NotFound();
            _featureService.UpdateF(feature.Id, feature);
            return RedirectToAction("Index");
        }

    }
}
