using DesignPattern.Iterator.Iterator;
using Microsoft.AspNetCore.Mvc;

namespace DesignPattern.Iterator.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            VisitRouteMover visitRouteMover = new VisitRouteMover();
            List<string> routes = new List<string>();

            visitRouteMover.AddVisitRoute(new VisitRoute { CountryName = "USA", CityName = "New York", VisitPlaceName = "Statue of Liberty" });
            visitRouteMover.AddVisitRoute(new VisitRoute { CountryName = "USA", CityName = "New York", VisitPlaceName = "Central Park" });
            visitRouteMover.AddVisitRoute(new VisitRoute { CountryName = "USA", CityName = "New York", VisitPlaceName = "Empire State Building" });
            visitRouteMover.AddVisitRoute(new VisitRoute { CountryName = "USA", CityName = "Los Angeles", VisitPlaceName = "Hollywood" });
            visitRouteMover.AddVisitRoute(new VisitRoute { CountryName = "USA", CityName = "Los Angeles", VisitPlaceName = "Disneyland" });
            visitRouteMover.AddVisitRoute(new VisitRoute { CountryName = "USA", CityName = "Los Angeles", VisitPlaceName = "Universal Studios" });

            var iterator = visitRouteMover.CreateIterator();

            while (iterator.Next())
            {
                routes.Add(iterator.CurrentItem.CountryName + " - " + iterator.CurrentItem.CityName + " - " + iterator.CurrentItem.VisitPlaceName);
            }
            ViewBag.Routes = routes;
            return View();
        }
    }
}
