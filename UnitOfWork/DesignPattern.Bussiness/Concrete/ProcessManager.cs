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
    public class ProcessManager : IProcessService
    {
        private readonly IUnitofWork _unitofWork;
        private readonly IProcessDal _processDal;

        public ProcessManager(IUnitofWork unitofWork, IProcessDal processDal)
        {
            _unitofWork = unitofWork;
            _processDal = processDal;
        }

        public void TDelete(Process entity)
        {
            _processDal.Delete(entity);
            _unitofWork.Save();
        }

        public List<Process> TGetAll()
        {
            return _processDal.GetAll();

        }

        public Process TGetById(int id)
        {
            return _processDal.GetById(id);
        }

        public void TInsert(Process entity)
        {
            _processDal.Insert(entity);
            _unitofWork.Save();
        }

        public void TMultiUpdate(List<Process> entities)
        {
            _processDal.MultiUpdate(entities);
            _unitofWork.Save();
        }

        public void TUpdate(Process entity)
        {
            _processDal.Update(entity);
            _unitofWork.Save();
        }
    }
}
