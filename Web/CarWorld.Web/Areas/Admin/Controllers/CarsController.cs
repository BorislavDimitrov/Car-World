namespace CarWorld.Web.Areas.Admin.Controllers
{
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
        public async Task<IActionResult> ManageCars(string searchString, int? pageNumber = 1)
        {
            var cars = carsService.GetCarsForAdminAsync();

            ViewData["CurrentFilter"] = searchString;

            int pageSize = 10;

            return View(await PaginationList<CarsListViewModel>.CreateAsync(cars, pageNumber ?? 1, pageSize));
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
