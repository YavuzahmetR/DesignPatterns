using DesignPattern.Template.TemplatePattern;
using Microsoft.AspNetCore.Mvc;

namespace DesignPattern.Template.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            NetflixPlans netflixPlans = new BasicPlan();
            netflixPlans.CreatePlan();
            return View(netflixPlans);
        }
        public IActionResult StandartPlan()
        {
            NetflixPlans netflixPlans = new StandartPlan();
            netflixPlans.CreatePlan();
            return View(netflixPlans);
        }
        public IActionResult UltraPlan()
        {
            NetflixPlans netflixPlans = new UltraPlan();
            netflixPlans.CreatePlan();
            return View(netflixPlans);
        }
    }
}
