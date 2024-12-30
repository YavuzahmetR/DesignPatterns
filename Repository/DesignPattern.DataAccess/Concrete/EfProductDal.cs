using DesignPattern.DataAccess.Abstract;
using DesignPattern.DataAccess.Context;
using DesignPattern.Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.DataAccess.Concrete
{
    public class EfProductDal : GenericRepository<Product>, IProductRepository
    {
        public EfProductDal(AppDbContext appDbContext):base(appDbContext)
        {
            
        }
        public IQueryable<Product> GetCategoriesOfProducts()
        {
            return dbContext.Products.Include(x => x.Category).AsNoTracking();
            
        }
    }
}

