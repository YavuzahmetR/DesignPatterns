using DesignPattern.ChainOfResponsibility.DAL;
using DesignPattern.ChainOfResponsibility.Models;

namespace DesignPattern.ChainOfResponsibility.ChainOfResponsibilty
{
    public class AssistantManager : Employee
    {
        private readonly AppDbContext _appDbContext;

        public AssistantManager(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public override void ProcessRequest(CustomerProcessViewModel request)
        {
            if (request.Amount <= 150000)
            {
                CustomerProcess customerProcess = new CustomerProcess
                {
                    Amount = request.Amount.ToString(),
                    Name = request.Name,
                    EmployeeName = "Assistant Manager - Jane Doe",
                    Description = "Request Approved by Assistant Manager"
                };
                _appDbContext.CustomerProcesses.Add(customerProcess);
                _appDbContext.SaveChanges();
            }
            else if(NextApprover != null)
            {
                CustomerProcess customerProcess = new CustomerProcess
                {
                    Amount = request.Amount.ToString(),
                    Name = request.Name,
                    EmployeeName = "Assistant Manager - Jane Doe",
                    Description = "Request Rejected by Assistant Manager, Directing Customer to Bank Manager"
                };
                _appDbContext.CustomerProcesses.Add(customerProcess);
                _appDbContext.SaveChanges();
                NextApprover.ProcessRequest(request);
            }
        }
    }
}
