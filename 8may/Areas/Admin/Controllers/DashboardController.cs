using Microsoft.AspNetCore.Mvc;
using Pronia.Core.Models;

namespace _8may.Areas.Admin.Controllers
{
    public class DashboardController : Controller
    {
        [Area("Admin")]

        public IActionResult Index()
        {
            return View();
        }
    }
}
