using DesignPattern.DataAccess.Abstract;
using DesignPattern.DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.DataAccess.Concrete
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected AppDbContext dbContext;
        private readonly DbSet<T> _dbSet;
        public GenericRepository(AppDbContext appDbContext)
        {
            dbContext = appDbContext;
            _dbSet = dbContext.Set<T>();
        }

        public async ValueTask AddAsync(T Entity) => await _dbSet.AddAsync(Entity);


        public void Delete(T Entity) => _dbSet.Remove(Entity);


        public  IQueryable<T> GetAll() => _dbSet.AsQueryable().AsNoTracking();


        public async ValueTask<T?> GetByIdAsync(int id) =>  await _dbSet.FindAsync(id);


        public void Update(T Entity) => _dbSet.Update(Entity);


        public IQueryable<T> Where(Expression<Func<T, bool>> predicate) => _dbSet.Where(predicate);

    }
}
