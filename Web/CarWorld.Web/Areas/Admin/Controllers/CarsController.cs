namespace CarWorld.Web.Areas.Admin.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;

    using CarWorld.Common;
    using CarWorld.Services.Contracts;
    using CarWorld.Web.Areas.Administration.Controllers;
    using CarWorld.Web.ViewModels.Administration.Cars;
    using CarWorld.Web.ViewModels.Paging;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Caching.Distributed;

    public class CarsController : AdministrationController
    {
        private readonly ICarsService carsService;
        private readonly IDistributedCache cache;

        public CarsController(ICarsService carsService,
            IDistributedCache cache)
        {
            this.carsService = carsService;
            this.cache = cache;
        }

        [HttpGet]
        public async Task<IActionResult> ManageCars(string searchText, int id = 1)
        {
            const int itemsPerPage = 12;

            var cars = await carsService.GetCarsForAdminAsync(searchText);

            var viewModel = new CarsForAdminListViewModel()
            {
                PageNumber = id,
                Cars = cars.Skip((id - 1) * itemsPerPage).Take(itemsPerPage),
                ItemsCount = cars.Count(),
                ItemsPerPage = itemsPerPage,
            };

            ViewData["CurrentFilter"] = searchText;

            return View(viewModel);
        }

        public async Task<IActionResult> Delete(int id)
        {
            if (!await carsService.IsCarExistingForAdminByIdAsync(id))
            {
                TempData["ErrorMessage"] = GlobalConstants.RedirectToHomepageAlertMessage;
                return Redirect("/Admin/Home/Index");
            }

            await carsService.DeleteCarAsync(id);

            TempData["DeleteMessage"] = GlobalConstants.SuccessfulDelete;

            return RedirectToAction(nameof(ManageCars));
        }

        public async Task<IActionResult> Details(int id)
        {
            if (!await carsService.IsCarExistingForAdminByIdAsync(id))
            {
                TempData["ErrorMessage"] = GlobalConstants.RedirectToHomepageAlertMessage;
                return Redirect("/Admin/Home/Index");
            }

            var model = await carsService.GetCarDetails(id);

            return View(model);
        }
    }
}
