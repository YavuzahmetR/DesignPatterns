using DesignPattern.DataAccess.Abstract;
using DesignPattern.DataAccess.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.DataAccess.Concrete
{
    public class UnitOfWork(AppDbContext appDbContext) : IUnitOfWork
    {
        public async Task<int> SaveChangesAsync() => await appDbContext.SaveChangesAsync();

    }
}
