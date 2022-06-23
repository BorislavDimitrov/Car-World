namespace CarWorld.Web.Areas.Admin.Controllers
{
    using CarWorld.Common;
    using CarWorld.Services.Contracts;
    using CarWorld.Web.Areas.Administration.Controllers;
    using CarWorld.Web.ViewModels.Administration.Cars;
    using CarWorld.Web.ViewModels.Models;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.Extensions.Caching.Distributed;
    using System.Linq;
    using System.Threading.Tasks;

    public class CarsController : AdministrationController
    {
        private readonly ICarsService carsService;
        private readonly IMakesService makesService;
        private readonly IModelsService modelsService;
        private readonly IRegionsService regionsService;
        private readonly IDistributedCache cache;

        public CarsController(ICarsService carsService,
            IMakesService makesService,
            IModelsService modelsService,
            IRegionsService regionsService,
            IDistributedCache cache)
        {
            this.carsService = carsService;
            this.makesService = makesService;
            this.modelsService = modelsService;
            this.regionsService = regionsService;
            this.cache = cache;
        }

        [HttpGet]
        public async Task<IActionResult> ManageCars(string search, int? makeId, int? modelId, int? regionId, string orderBy, int id = 1)
        {
            const int itemsPerPage = 12;

            var cars = await carsService.GetCarsForAdminAsync<CarsForAdminInListViewModel>(search, makeId, modelId, regionId, orderBy);

            var makes = await makesService.GetMakesAsSelectListItemAsync();          

            var models = await modelsService.GetModelsByMakeIdForAdminAsync(makeId);

            var regions = await regionsService.GetExistingRegionsAsSelectItemListAsync();          

            var viewModel = new CarsForAdminListViewModel()
            {
                PageNumber = id,
                Cars = cars.Skip((id - 1) * itemsPerPage).Take(itemsPerPage),
                ItemsCount = cars.Count(),
                ItemsPerPage = itemsPerPage,
                Search = search,
                MakeId = makeId,
                RegionId = regionId,
                OrderBy = orderBy,
                ModelId = modelId,
                Makes = makes,
                Regions = regions,
                Models = models,
            };

            return View(viewModel);
        }

        [HttpPost]
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

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            if (!await carsService.IsCarExistingForAdminByIdAsync(id))
            {
                TempData["ErrorMessage"] = GlobalConstants.RedirectToHomepageAlertMessage;
                return Redirect("/Admin/Home/Index");
            }

            var model = await carsService.GetCarDetailsByIdAsync(id);

            return View(model);
        }

        public async Task<IActionResult> GetModels(int? makeId)
        {
            var models = await modelsService.GetModelsByMakeIdForAdminAsync(makeId);

            return Json(new SelectList(models, "ModelId", "ModelName"));
        }
    }
}
