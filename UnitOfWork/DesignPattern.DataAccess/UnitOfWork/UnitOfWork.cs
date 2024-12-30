using DesignPattern.DataAccess.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.DataAccess.UnitOfWork
{
    public class UnitOfWork : IUnitofWork
    {
        private readonly Context _context;
        public UnitOfWork(Context _context)
        {
            this._context = _context;
        }
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
