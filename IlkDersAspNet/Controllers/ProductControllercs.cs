using Microsoft.AspNetCore.Mvc;

namespace CustomerApp.Controllers
{
    public class ProductControllercs : Controller
    {
        public IActionResult Index(int id) { 
            return View();
        }
    }
}
