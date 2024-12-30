using DesignPattern.Bussiness.Abstract;
using DesignPattern.Entity.Concrete;
using DesignPattern.UnitOfWork.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DesignPattern.UnitOfWork.Controllers
{
    public class DefaultController : Controller
    {
        private readonly ICustomerService customerService;
        public DefaultController(ICustomerService customerService)
        {
            this.customerService = customerService;
        }
        public IActionResult Index()
        {
           return View(customerService.TGetAll());
        }


        [HttpGet]
        public IActionResult MoneyTransfer()
        {
            List<Customer> customers = customerService.TGetAll();
            ViewBag.Customers = new SelectList(customers, "Id", "Name");
            return View();
        }
        [HttpPost]
        public IActionResult MoneyTransfer(CustomerProcessViewModel req)
        {
            var sender = customerService.TGetById(req.SenderId);
            var receiver = customerService.TGetById(req.ReceiverId);

            if (sender.Balance < req.Cost)
            {
                ViewBag.ErrorMessage = "Yetersiz bakiye!";
                ViewBag.Customers = new SelectList(customerService.TGetAll(), "Id", "Name");
                return View();
            }


            sender.Balance -= req.Cost;
            receiver.Balance += req.Cost;


            List<Customer> modifiedCustomers = new List<Customer>
            {
                sender,
                receiver
            };

            customerService.TMultiUpdate(modifiedCustomers);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult GetCustomerBalance(int id)
        {
            var customer = customerService.TGetById(id);

            if (customer != null)
            {
                return Json(customer.Balance);
            }
            return Json("Müşteri bulunamadı.");
        }

    }
}
