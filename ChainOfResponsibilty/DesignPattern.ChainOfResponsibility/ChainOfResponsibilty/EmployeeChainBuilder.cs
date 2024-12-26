using DesignPattern.ChainOfResponsibility.DAL;

namespace DesignPattern.ChainOfResponsibility.ChainOfResponsibilty
{
    public class EmployeeChainBuilder : IEmployeeChainBuilder
    {
        private readonly AppDbContext _appDbContext;
        public EmployeeChainBuilder(AppDbContext _appDbContext)
        {
            this._appDbContext = _appDbContext;
        }
        public Employee BuildChain()
        {
            Employee treasurer = new Treasurer(_appDbContext);
            Employee assistantManager = new AssistantManager(_appDbContext);
            Employee bankManager = new BankManager(_appDbContext);
            Employee regionalManager = new RegionalManager(_appDbContext);

            treasurer.SetNextApprover(assistantManager);
            assistantManager.SetNextApprover(bankManager);
            bankManager.SetNextApprover(regionalManager);

            return treasurer;
        }
    }
}
