using Microsoft.AspNetCore.Mvc;

namespace DemoMvc.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            string name = "Tom";
            int age = 30;
            ViewBag.Name = name;
            ViewData["Age"] = age;
            TempData["name"] = name;
            return View();
        }
        public IActionResult About()
        {
            ViewBag.Name = TempData["name"];
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }
    }
}
