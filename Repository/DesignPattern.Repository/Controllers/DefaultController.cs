using DesignPattern.Entity.Concrete;
using DesignPattern.Repository.Models;
using DesinPattern.Business;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace DesignPattern.Repository.Controllers
{
    public class DefaultController(IProductService productService, ICategoryService categoryService) : Controller
    {

        public async Task<IActionResult> Index()
        {
            var values = await productService.GetCategoriesOfProducts();
            return View(values);
        }
        [HttpGet]
        public async Task<IActionResult> CreateProduct()
        {
            List<Category> categories = await categoryService.GetAllAsync();
            ViewBag.Categories = new SelectList(categories, "Id", "Name");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateProduct(ProductCreateViewModel req)
        {
            if (ModelState.IsValid)
            {
                var product = new Product
                {
                    Name = req.Name,
                    Stock = req.Stock,
                    Price = req.Price,
                    CategoryId = req.CategoryId
                };

                await productService.AddAsync(product);
                return RedirectToAction("Index");
            }

            List<Category> categories = await categoryService.GetAllAsync();
            ViewBag.Categories = new SelectList(categories, "Id", "Name");
            return View(req);
        }
        [HttpGet]
        public async Task<IActionResult> UpdateProduct(int id)
        {
            var product = await productService.GetByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            List<Category> categories = await categoryService.GetAllAsync();
            ViewBag.Categories = new SelectList(categories, "Id", "Name", product.CategoryId);

            var productUpdateViewModel = new ProductUpdate_DeleteViewModel
            {
                Id = product.Id,
                Name = product.Name,
                Stock = product.Stock,
                Price = product.Price,
                CategoryId = product.CategoryId
            };

            return View(productUpdateViewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateProduct(ProductUpdate_DeleteViewModel req)
        {
            if (ModelState.IsValid)
            {
                var product = new Product
                {
                    Id = req.Id,
                    Name = req.Name,
                    Price = req.Price,
                    Stock = req.Stock,
                    CategoryId = req.CategoryId
                };
                await productService.UpdateAsync(product);
                return RedirectToAction("Index");
            }
            List<Category> categories = await categoryService.GetAllAsync();
            ViewBag.Categories = new SelectList(categories, "Id", "Name", req.CategoryId);
            return View(req);

        }
        public async Task<IActionResult> DeleteProduct(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await productService.GetByIdAsync(id.Value);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await productService.GetByIdAsync(id);
            if (product != null)
            {
                await productService.DeleteAsync(product);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
