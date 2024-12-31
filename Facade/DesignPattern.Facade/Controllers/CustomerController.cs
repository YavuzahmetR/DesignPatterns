using DesignPattern.Facade.DAL;
using Microsoft.AspNetCore.Mvc;

namespace DesignPattern.Facade.Controllers
{
    public class CustomerController : Controller
    {
        [HttpGet]
        public IActionResult AddNewCustomer()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddNewCustomer(Customer customer )
        {
            using Context context = new Context();
            context.Customers.Add(customer);
            context.SaveChanges();
            return RedirectToAction("CustomerList");
        }
        public IActionResult CustomerList()
        {
            using Context context = new Context();
            var values = context.Customers.ToList();
            return View(values);
        }
    }
}
