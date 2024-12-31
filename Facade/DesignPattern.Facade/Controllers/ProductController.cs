using DesignPattern.Facade.DAL;
using Microsoft.AspNetCore.Mvc;

namespace DesignPattern.Facade.Controllers
{
    public class ProductController : Controller
    {
        [HttpGet]
        public IActionResult AddNewProduct()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddNewProduct(Products product)
        {
            using Context context = new Context();
            context.Products.Add(product);
            context.SaveChanges();
            return RedirectToAction("CustomerList");
        }
        public IActionResult ProductList()
        {
            using Context context = new Context();
            var values = context.Products.ToList();
            return View(values);
        }
    }
}
