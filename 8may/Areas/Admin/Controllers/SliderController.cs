using Microsoft.AspNetCore.Mvc;
using Pronia.Business.Services.Abstracts;
using Pronia.Business.Services.Concrates;
using Pronia.Core.Models;

namespace _8may.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SliderController : Controller
    {
        private readonly ISliderService _sliderService;
        public SliderController(ISliderService sliderService)
        {
            _sliderService = sliderService;
        }
        public IActionResult Index()
        {
            var sliders = _sliderService.GetAll();
            return View(sliders);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Slider slider)
        {
            if (slider == null) return NotFound();
            _sliderService.Add(slider);
            return RedirectToAction("Index");
        }
        public IActionResult Update(int id2)
        {
            var ufeature = _sliderService.Get(x => x.Id == id2);
            if (ufeature == null) return NotFound();
            return View(ufeature);
        }
        [HttpPost]
        public IActionResult UpdatePost(Slider slider)
        {
            if (slider == null) return NotFound();
            _sliderService.Update(slider.Id, slider);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var dfeature = _sliderService.Get(x => x.Id == id);
            if (dfeature == null) return NotFound();
            return View(dfeature);
        }
        [HttpPost]
        public IActionResult DeletePost(int id)
        {
            _sliderService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
