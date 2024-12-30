using DesignPattern.DataAccess.Abstract;
using DesignPattern.DataAccess.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.DataAccess.Repositories
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        private readonly Context _context;
        public GenericRepository(Context context)
        {
            _context = context;
        }
        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public List<T> GetAll()
        {
            return _context.Set<T>().ToList();    
        }

        public T GetById(int id)
        {
            return _context.Set<T>().Find(id)!;
        }

        public void Insert(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public void MultiUpdate(List<T> entities)
        {
            _context.Set<T>().UpdateRange(entities);
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }
    }
}
