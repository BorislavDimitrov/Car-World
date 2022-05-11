using Microsoft.AspNetCore.Mvc;

namespace CarWorld.Web.Areas.Administration.Controllers
{
    public class HomeController : AdministrationController
    {
        public HomeController()
        {

        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
