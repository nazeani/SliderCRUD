using Microsoft.AspNetCore.Mvc;
using Pronia.Business.Services.Abstracts;

namespace _8may.Controllers
{
    public class ShopController : Controller
    {
        ICategoryService _categoryService;
        public ShopController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        public IActionResult Index()
        {
            var categories = _categoryService.GetAll();
            return View(categories  );
        }
    }
}
