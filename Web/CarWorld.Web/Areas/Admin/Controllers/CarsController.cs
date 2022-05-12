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

    public class CarsController : AdministrationController
    {
        private readonly ICarsService carsService;

        public CarsController(ICarsService carsService)
        {
            this.carsService = carsService;
        }

        [HttpGet]
        public async Task<IActionResult> ManageCars(string searchText, int id = 1)
        {
            const int itemsPerPage = 12;

            var cars = await carsService.GetCarsForAdminAsync<CarsForAdminInListViewModel>();

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
                TempData["Message"] = GlobalConstants.RedirectToHomepageAlertMessage;
                return Redirect("/Admin/Home/Index");
            }

            await carsService.DeleteCarAsync(id);

            return RedirectToAction(nameof(ManageCars));
        }

        public async Task<IActionResult> Details(int id)
        {
            if (!await carsService.IsCarExistingForAdminByIdAsync(id))
            {
                TempData["Message"] = GlobalConstants.RedirectToHomepageAlertMessage;
                return Redirect("/Admin/Home/Index");
            }

            var model = await carsService.GetCarDetails(id);

            return View(model);
        }
    }
}
