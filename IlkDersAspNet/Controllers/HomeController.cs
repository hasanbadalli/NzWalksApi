using CustomerApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.Cache;

namespace CustomerApp.Controllers
{
    //[Route("[controller]/[action]")]

    public class HomeController : Controller
    {
        //[Route("Home")] attribute routing, bunu istifade elesen esas bu isleyir
        public IActionResult Index()
        {
            ViewBag.Name = "Data tasima yontemleri";
            ViewData["Name"] = "Hasan";
            TempData["SomeData"] = "Bu data somedi"; // bunu o biri actionlarda ad istifade elemek olur,
                                                     // bir responsedan o biri response data oturerkende istifade etmek olur,
                                                     // view render olduqdan sonra her 3 u yox olur
                                                     // ammaki tempdata da Keep() omrunu uzadir, Peak() silmeden oxur

            //viewbag,viewdata,tempdata, model

            
            var values = RouteData.Values["id"];
            if(values != null)
            {
                values = int.Parse(RouteData.Values["id"].ToString());
            }
            Customer customer = new Customer() { Age = 20 , FirstName = "Hasan", LastName = "Badalli" };
            ViewData["ID"] = values;
           

            return View(customer);
            //return View("Afrika", customer); View belde istifade oluna biler
            
            //return RedirectToAction("Hasan"); yuxarda olan return de meselen
            //Afrika adinda action olduqu zaman o islemir gedir bir basa vievvsden
            //afrikadani axtarir sadece, bu zaman Afrika action imizda Business la bagli nese olanda o islemir ona gore RedirectToAction istifade edirik
        }

        public IActionResult Product() { 
            return RedirectToAction("Index", "Product", new {@id = 1});
        }

        public IActionResult LearnStaticDataCustomerList()
        {
            var customers = CustomerContext.Customers;

            return View(customers); 
        
        }

        public IActionResult Hasan()
        {
            return View();
        }
    }
}
