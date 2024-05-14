using Microsoft.AspNetCore.Mvc;
using Pronia.Business.Services.Abstracts;
using Pronia.Core.Models;

namespace _8may.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
       private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
           _categoryService = categoryService;
        }
        public IActionResult Index()
        {
            var categories = _categoryService.GetAll();
            return View(categories);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category category)
        {
            if (category == null) { return NotFound(); }
            _categoryService.Add(category);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var dCategory = _categoryService.Get(x => x.Id == id);
            if (dCategory == null)  return NotFound(); 
            return View(dCategory);
        }
        [HttpPost]
        public IActionResult DeletePost(int id)
        {
            _categoryService.Delete(id);
            return RedirectToAction("Index");
        }
        public IActionResult Update(int id2)
        {
            var existCategory = _categoryService.Get(x => x.Id == id2);
            if (existCategory == null)  return NotFound(); 
            return View(existCategory);
        }
        [HttpPost]
        public IActionResult UpdatePost(Category category)
        {
            if (category == null) { return NotFound(); }
            _categoryService.Update(category.Id, category);
            return RedirectToAction("Index");
        }
    }
}
