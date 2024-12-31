using DesignPattern.Facade.Facade;
using Microsoft.AspNetCore.Mvc;

namespace DesignPattern.Facade.Controllers
{
    public class OrderController : Controller
    {
        [HttpGet]
        public IActionResult OrderDetailStart()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> OrderDetailStart(int customerId, int productId, int orderId, int productCount, decimal
            productPrice)
        {
            OrderFacade order = new OrderFacade();
            await order.CompleteOrderDetail(customerId, productId, orderId, productCount, productPrice);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult OrderStart()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> OrderStart(int customerId)
        {
            OrderFacade order = new OrderFacade();
            await order.CompleteOrder(customerId);
            return RedirectToAction("Index");
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
