using DesignPattern.ChainOfResponsibility.DAL;
using DesignPattern.ChainOfResponsibility.Models;

namespace DesignPattern.ChainOfResponsibility.ChainOfResponsibilty
{
    public class Treasurer : Employee
    {
        private readonly AppDbContext _appDbContext;

        public Treasurer(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public override void ProcessRequest(CustomerProcessViewModel request)
        {
            if (request.Amount <= 100000)
            {
                CustomerProcess customerProcess = new CustomerProcess
                {
                    Amount = request.Amount.ToString(),
                    Name = request.Name,
                    EmployeeName = "Treasurer - John Doe",
                    Description = "Request Approved by Treasurer"
                };
                _appDbContext.CustomerProcesses.Add(customerProcess);
                _appDbContext.SaveChanges();
            }
            else if (NextApprover != null)
            {
                CustomerProcess customerProcess = new CustomerProcess
                {
                    Amount = request.Amount.ToString(),
                    Name = request.Name,
                    EmployeeName = "Treasurer - John Doe",
                    Description = "Request Rejected by Treasurer, Directing Customer to Assistant Bank Manager"
                };
                _appDbContext.CustomerProcesses.Add(customerProcess);
                _appDbContext.SaveChanges();
                NextApprover.ProcessRequest(request);
            }
        }
    }
}
