using DesignPattern.Mediator.Mediators.Commands;
using DesignPattern.Mediator.Mediators.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DesignPattern.Mediator.Controllers
{
    public class DefaultController(IMediator mediator) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var values = await mediator.Send(new GetAllProductsQuery());
            return View(values);
        }

        public async Task<IActionResult> GetProduct(int id)
        {
            var values = await mediator.Send(new GetProductByIdQuery(id));
            return View(values);
        }
        public async Task<IActionResult> DeleteProduct(int id)
        {
            await mediator.Send(new RemoveProductCommand(id));
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> UpdateProduct(int id)
        {
            var value = await mediator.Send(new UpdateProductByIdQuery(id));
            return View(value);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateProduct(UpdateProductCommand updateProductCommand)
        {
            await mediator.Send(updateProductCommand);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult CreateProduct()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductCommand createProductCommand)
        {
            await mediator.Send(createProductCommand);
            return RedirectToAction(nameof(Index));
        }
    }
}
