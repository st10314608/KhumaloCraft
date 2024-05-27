using Microsoft.AspNetCore.Mvc;
using KhumaloCraft.Models;


namespace KhumaloCraft.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult MyWork()
        {
            var products = Products.GetAllProducts();   
            return View(products);
        }

        [HttpPost]

        public IActionResult MyWork(Products products) 
            {
            if (ModelState.IsValid)
                {
                var result = Products.InsertProduct(products);
                if (result > 0)
                {
                    return RedirectToAction("MyWork", "Home");
                }
            }
            return View(products);
        }
    }
}
