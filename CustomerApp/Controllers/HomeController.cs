using CustomerApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Net.Cache;

namespace CustomerApp.Controllers
{
    //[Route("[controller]/[action]")]

    public class HomeController : Controller
    {
        //[Route("Home")] attribute routing, bunu istifade elesen esas bu isleyir
        [HttpGet]
        public IActionResult Index()
        {
            
            
            var customers = CustomerContext.Customers;

            return View(customers);
        
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateWithForm() {

            var firstName = HttpContext.Request.Form["firstname"].ToString();
            var lastName = HttpContext.Request.Form["lastname"].ToString();
            var age = int.Parse(HttpContext.Request.Form["age"].ToString());

            Customer lastCustomer = null;
            if (CustomerContext.Customers.Count > 0)
            {
                lastCustomer = CustomerContext.Customers.Last();
            }

            int id=1;
            if(lastCustomer != null)
            {
                id = lastCustomer.Id + 1;
            }
            
            CustomerContext.Customers.Add(new Customer
            {
                Id = id,
                FirstName = firstName,
                LastName = lastName,
                Age = age
            });
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Remove()
        {
            var id = int.Parse(RouteData.Values["id"].ToString());
            var removedCustomer = CustomerContext.Customers.Find((item)=> item.Id == id);
            CustomerContext.Customers.Remove(removedCustomer);
            return RedirectToAction("Index");
        }
    }
}
