using DesignPattern.Composite.CompositePattern;
using DesignPattern.Composite.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DesignPattern.Composite.Controllers
{
    public class DefaultController(Context context) : Controller
    {


        public IActionResult Index()
        {
            var categories = context.Categories.Include(x => x.Products).ToList();
            var values = Recursive(categories, new Category { Name = "FirstCategory", Id = 0} , new ProductComposite(0,"FirstComposite"));
            ViewBag.Values = values;
            return View();
        }

        public ProductComposite Recursive(List<Category> categories, Category firstCategory, ProductComposite
            firstComposite, ProductComposite leaf = null)
        {
            categories.Where(x => x.UpperCategoryId == firstCategory.Id).ToList().ForEach(y =>
            {
                var productComposite = new ProductComposite(y.Id, y.Name);

                y.Products.ToList().ForEach(z =>
                {
                    productComposite.Components.Add(new ProductComponent(z.Id, z.Name));
                });
                if(leaf != null)
                {
                    leaf.Components.Add(productComposite);
                }
                else
                {
                    firstComposite.Components.Add(productComposite);
                }
                Recursive(categories, y, firstComposite, productComposite);

            });
            return firstComposite;
        }

    }



}
