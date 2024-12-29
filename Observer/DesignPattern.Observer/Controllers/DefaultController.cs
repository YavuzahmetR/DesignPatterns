using DesignPattern.Observer.DAL;
using DesignPattern.Observer.Models;
using DesignPattern.Observer.ObserverPattern;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DesignPattern.Observer.Controllers
{
    public class DefaultController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ObserverObject _observerObject;

        public DefaultController(UserManager<AppUser> userManager, ObserverObject observerObject)
        {
            _userManager = userManager;
            _observerObject = observerObject;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(RegisterViewModel req)
        {
            var user = new AppUser
            {
                Name = req.Name,
                Surname = req.Surname,
                Email = req.Email,
                UserName = req.Name + req.Surname + Guid.NewGuid().ToString().Substring(0, 4),
                City = req.City,
                District = req.District
            };
            var result = await _userManager.CreateAsync(user, req.Password);
            if (result.Succeeded)
            {
                _observerObject.Notify(user);
                return View();
            }
            return View();
        }
    }
}
