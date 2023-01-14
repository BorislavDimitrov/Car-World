using Microsoft.AspNetCore.Mvc;

namespace CarWorld.Web.Controllers
{
    public class MapController : Controller
    {
        public MapController()
        {

        }

        public IActionResult GetMap()
        {
            return View();
        }
    }
}
