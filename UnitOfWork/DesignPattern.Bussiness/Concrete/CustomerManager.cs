using DesignPattern.Bussiness.Abstract;
using DesignPattern.DataAccess.Abstract;
using DesignPattern.DataAccess.UnitOfWork;
using DesignPattern.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Bussiness.Concrete
{
    public class CustomerManager : ICustomerService
    {
        private readonly IUnitofWork _unitofWork;
        private readonly ICustomerDal _customerDal;

        public CustomerManager(IUnitofWork unitofWork, ICustomerDal customerDal)
        {
            _unitofWork = unitofWork;
            _customerDal = customerDal;
        }

        public void TDelete(Customer entity)
        {
            _customerDal.Delete(entity);
            _unitofWork.Save();
        }

        public List<Customer> TGetAll()
        {
            return _customerDal.GetAll();

        }

        public Customer TGetById(int id)
        {
            return _customerDal.GetById(id);
        }

        public void TInsert(Customer entity)
        {
            _customerDal.Insert(entity);
            _unitofWork.Save();
        }

        public void TMultiUpdate(List<Customer> entities)
        {
            _customerDal.MultiUpdate(entities);
            _unitofWork.Save();
        }

        public void TUpdate(Customer entity)
        {
            _customerDal.Update(entity);
            _unitofWork.Save();
        }
    }
}
