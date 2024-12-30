using DesignPattern.DataAccess.Abstract;
using DesignPattern.DataAccess.Context;
using DesignPattern.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.DataAccess.Concrete
{
    public class EfCategoryDal : GenericRepository<Category>, ICategoryRepository
    {
        public EfCategoryDal(AppDbContext appDbContext) : base(appDbContext)
        {

        }
    }
}
