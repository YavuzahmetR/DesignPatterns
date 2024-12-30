using DesignPattern.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesinPattern.Business
{
    public interface IProductService : IGenericService<Product>
    {
        Task<List<Product>> GetCategoriesOfProducts();
    }
}
