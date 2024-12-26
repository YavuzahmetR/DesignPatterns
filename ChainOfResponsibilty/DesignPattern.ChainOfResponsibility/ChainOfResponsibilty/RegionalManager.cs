using DesignPattern.ChainOfResponsibility.DAL;
using DesignPattern.ChainOfResponsibility.Models;

namespace DesignPattern.ChainOfResponsibility.ChainOfResponsibilty
{
    public class RegionalManager : Employee
    {
        private readonly AppDbContext _appDbContext;

        public RegionalManager(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public override void ProcessRequest(CustomerProcessViewModel request)
        {
            if (request.Amount <= 400000)
            {
                CustomerProcess customerProcess = new CustomerProcess
                {
                    Amount = request.Amount.ToString(),
                    Name = request.Name,
                    EmployeeName = "Regional Manager - Raiden Hoe",
                    Description = "Request Approved by Regional Manager"
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
                    EmployeeName = "Regional Manager - Raiden Hoe",
                    Description = "Request Rejected by by Regional Manager, To Perform Customer's Request Primary Needs Will Be Sent To him/her Another Time."
                };
                _appDbContext.CustomerProcesses.Add(customerProcess);
                _appDbContext.SaveChanges();
            }
        }
    }
}
