using DesignPattern.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.DataAccess.Abstract
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        IQueryable<Product> GetCategoriesOfProducts();
    }
}
