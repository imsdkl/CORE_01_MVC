using Microsoft.AspNetCore.Mvc;

namespace CORE_01_MVC.Controllers
{
    public class UniverController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }        
        public IActionResult BSTU()
        {
            return View();
        }        
        public IActionResult TSTU()
        {
            return View();
        }        
        public IActionResult MSU()
        {
            return View();
        }
    }
}
