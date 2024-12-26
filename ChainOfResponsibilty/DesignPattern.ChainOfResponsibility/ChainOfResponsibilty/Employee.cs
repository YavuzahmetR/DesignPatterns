using DesignPattern.ChainOfResponsibility.Models;

namespace DesignPattern.ChainOfResponsibility.ChainOfResponsibilty
{
    public abstract class Employee
    {
        protected Employee? NextApprover;

        public void SetNextApprover(Employee superVisor)
        {
            NextApprover = superVisor;
        }
        public abstract void ProcessRequest(CustomerProcessViewModel request);
    }
}
