using DesignPattern.ChainOfResponsibility.DAL;
using DesignPattern.ChainOfResponsibility.Models;

namespace DesignPattern.ChainOfResponsibility.ChainOfResponsibilty
{
    public class BankManager : Employee
    {
        private readonly AppDbContext _appDbContext;

        public BankManager(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public override void ProcessRequest(CustomerProcessViewModel request)
        {
            if (request.Amount <= 250000)
            {
                CustomerProcess customerProcess = new CustomerProcess
                {
                    Amount = request.Amount.ToString(),
                    Name = request.Name,
                    EmployeeName = "Bank Manager - Eddie Poe",
                    Description = "Request Approved by Bank Manager"
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
                    EmployeeName = "Bank Manager - Eddie Poe",
                    Description = "Request Rejected by by Bank Manager, Directing Customer to Regional Manager"
                };
                _appDbContext.CustomerProcesses.Add(customerProcess);
                _appDbContext.SaveChanges();
                NextApprover.ProcessRequest(request);
            }
        }
    }
}
