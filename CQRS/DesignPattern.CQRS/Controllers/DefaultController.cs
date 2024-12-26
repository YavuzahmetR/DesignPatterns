using DesignPattern.CQRS.CQRS.Commands;
using DesignPattern.CQRS.CQRS.Handlers;
using DesignPattern.CQRS.CQRS.Queries;
using Microsoft.AspNetCore.Mvc;

namespace DesignPattern.CQRS.Controllers
{
    public class DefaultController(GetProductQueryHandler _getProductQueryHandler,
        CreateProductCommandHandler _createProductCommandHandler,
        GetProductByIdQueryHandler getProductByIdQueryHandler,
        RemoveProductCommandHandler removeProductCommandHandler,
        GetProductUpdateByIdQueryHandler getProductUpdateByIdQueryHandler,
        UpdateProductCommandHandler updateProductCommandHandler) : Controller
    {

        public async Task<IActionResult> Index()
        {
            var values = await _getProductQueryHandler.Handle();
            return View(values);
        }
        public async Task<IActionResult> GetProductById(int id)
        {
            var value = await getProductByIdQueryHandler.Handle(new GetProductByIdQuery(id));
            return View(value);
        }
        [HttpGet]
        public IActionResult AddProduct()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddProduct(CreateProductCommand createProductCommand)
        {
            await _createProductCommandHandler.Handle(createProductCommand);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> DeleteProduct(int id)
        {
            await removeProductCommandHandler.Handle(new RemoveProductCommand(id));
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> UpdateProduct(int id)
        {
            var value = await getProductUpdateByIdQueryHandler.Handle(new GetProductUpdateByIdQuery(id));
            return View(value);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateProduct(UpdateProductCommand updateProductCommand)
        {
            await updateProductCommandHandler.Handle(updateProductCommand);
            return RedirectToAction(nameof(Index));
        }
    }
}
