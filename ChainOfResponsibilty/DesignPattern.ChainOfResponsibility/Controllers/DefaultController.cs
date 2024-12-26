using DesignPattern.ChainOfResponsibility.ChainOfResponsibilty;
using DesignPattern.ChainOfResponsibility.DAL;
using DesignPattern.ChainOfResponsibility.Models;
using Microsoft.AspNetCore.Mvc;

namespace DesignPattern.ChainOfResponsibility.Controllers
{
    public class DefaultController : Controller
    {
        private readonly IEmployeeChainBuilder _employeeChainBuilder;

        public DefaultController(IEmployeeChainBuilder employeeChainBuilder)
        {
            _employeeChainBuilder = employeeChainBuilder;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(CustomerProcessViewModel model)
        {
            var chain = _employeeChainBuilder.BuildChain();
            chain.ProcessRequest(model);
            return View();
        }
    }
}
