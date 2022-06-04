namespace CarWorld.Web.Controllers
{
    using CarWorld.Common;
    using CarWorld.Services.Contracts;
    using CarWorld.Services.Messaging;
    using CarWorld.Web.ViewModels.Cars;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using System.Linq;
    using System.Security.Claims;
    using System.Threading.Tasks;

    public class CarsController : Controller
    {
        private readonly IMakesService makesService;
        private readonly IRegionsService regionsService;
        private readonly IModelsService modelsService;
        private readonly ICarsService carsService;
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly IEmailSender emailSender;

        public CarsController(IMakesService makesService,
            IRegionsService regionsService,
            IModelsService modelsService,
            ICarsService carsService,
            IWebHostEnvironment webHostEnvironment,
            IEmailSender emailSender)
        {
            this.makesService = makesService;
            this.regionsService = regionsService;
            this.modelsService = modelsService;
            this.carsService = carsService;
            this.webHostEnvironment = webHostEnvironment;
            this.emailSender = emailSender;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var regions = await regionsService.GetExistingRegionsAsSelectItemListAsync();
            var makes = await makesService.GetExistingMakesAsSelectListItemAsync();
            var makeId = makes.FirstOrDefault().Value;
            var models = await modelsService.GetModelsForDropdownByMakeIdAsync(int.Parse(makeId));

            var model = new CreateCarInputModel()
            {
                Regions = regions,
                Makes = makes,
                Models = models,
            };

            return View(model);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create(CreateCarInputModel model)
        {
            if (!ModelState.IsValid)
            {
                var regions = await regionsService.GetExistingRegionsAsSelectItemListAsync();
                var makes = await makesService.GetExistingMakesAsSelectListItemAsync();
                var makeId = makes.FirstOrDefault().Value;
                var models = await modelsService.GetModelsForDropdownByMakeIdAsync(int.Parse(makeId));

                model.Regions = regions;
                model.Makes = makes;
                model.Models = models;
                return View(model);
            }

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            model.UserId = userId;

            string wwwrootPath = webHostEnvironment.WebRootPath;

            await carsService.CreateCarAsync(model, wwwrootPath);

            TempData["CreateMessage"] = GlobalConstants.SuccessfulCreate;

            return RedirectToAction(nameof(UserCars));
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Edit(int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (!await carsService.IsCarMadeByUserAsync(id, userId))
            {
                TempData["ErrorMessage"] = GlobalConstants.RedirectToHomepageAlertMessage;
                return Redirect("/Home/index");
            }

            var model = await carsService.GetCarByIdAsync<EditCarInputModel>(id);

            var regions = await regionsService.GetExistingRegionsAsSelectItemListAsync();
            var makes = await makesService.GetExistingMakesAsSelectListItemAsync();
            var models = await modelsService.GetModelsForDropdownByMakeIdAsync(model.MakeId);

            model.Regions = regions;
            model.Makes = makes;
            model.Models = models;

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditCarInputModel model)
        {
            if (!ModelState.IsValid)
            {
                var cities = await regionsService.GetExistingRegionsAsSelectItemListAsync();
                var makes = await makesService.GetExistingMakesAsSelectListItemAsync();
                var models = await modelsService.GetModelsForDropdownByMakeIdAsync(model.MakeId);
                model.Regions = cities;
                model.Makes = makes;
                model.Models = models;

                return View(model);
            }

            string wwwroot = webHostEnvironment.WebRootPath;

            await carsService.EditCarAsync(model, wwwroot);

            TempData["EditMessage"] = GlobalConstants.SuccessfulEdit;

            return RedirectToAction(nameof(Details), new { model.Id });
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult> UserCars(string search, int? makeId, int? modelId, int? regionId, string orderBy, int id = 1)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            const int itemsPerPage = 12;

            var cars = await carsService.GetUserCarsAsync<UserCarsInListViewModel>(userId, search, makeId, modelId, regionId, orderBy);

            var makes = await makesService.GetExistingMakesAsSelectListItemAsync();

            var models = await modelsService.GetModelsForDropdownByMakeIdAsync(makeId);

            var regions = await regionsService.GetExistingRegionsAsSelectItemListAsync();


            var viewModel = new UsersCarsListViewModel()
            {
                PageNumber = id,
                Cars = cars.Skip((id - 1) * itemsPerPage).Take(itemsPerPage),
                ItemsCount = cars.Count(),
                ItemsPerPage = itemsPerPage,
                Search = search,
                OrderBy = orderBy,
                MakeId = makeId,
                RegionId = regionId,
                ModelId = modelId,
                Makes = makes,
                Models = models,
                Regions = regions
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (!await carsService.IsCarMadeByUserAsync(id, userId))
            {
                TempData["ErrorMessage"] = GlobalConstants.RedirectToHomepageAlertMessage;
                return Redirect("/Home/index");
            }

            await carsService.DeleteCarAsync(id);

            TempData["DeleteMessage"] = GlobalConstants.SuccessfulDelete;

            return Redirect("/Home/index");
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var model = await carsService.GetCarDetails(id);

            if (!await carsService.IsCarExistingForUserByIdAsync(id))
            {
                TempData["ErrorMessage"] = GlobalConstants.RedirectToHomepageAlertMessage;
                return Redirect("/Home/index");
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Search(string search, int? makeId, int? modelId, int? regionId, string orderBy, int id = 1)
        {
            const int itemsPerPage = 12;

            var cars = await carsService.GetSearchCarsAsync<CarsInListViewModel>(search, makeId, modelId, regionId, orderBy);

            var makes = await makesService.GetExistingMakesAsSelectListItemAsync();

            var models = await modelsService.GetModelsForDropdownByMakeIdAsync(makeId);

            var regions = await regionsService.GetExistingRegionsAsSelectItemListAsync();

            var viewModel = new CarsListViewModel()
            {
                PageNumber = id,
                Cars = cars.Skip((id - 1) * itemsPerPage).Take(itemsPerPage),
                ItemsCount = cars.Count(),
                ItemsPerPage = itemsPerPage,
                Search = search,
                OrderBy = orderBy,
                MakeId = makeId,
                RegionId = regionId,
                ModelId = modelId,
                Makes = makes,
                Models = models,
                Regions = regions
            };

            return View(viewModel);
        }

        public async Task<IActionResult> GetModels(int makeId)
        {
            var models = await modelsService.GetModelsForDropdownByMakeIdAsync(makeId);

            return Json(new SelectList(models, "ModelId", "ModelName"));
        }

        public async Task<IActionResult> Email()
        {
            //to = "powerglide@abv.bg";
            //from = "bdimitorv@gmail.com";

            var link = Url.Action("ConfirmEmail", "Users", new { userId = "userId", token = "token" }, Request.Scheme);


            

             await emailSender.SendEmailAsync("bdimitorv@gmail.com", "Test", "hesiyad232@oceore.com", "Test", $"<a href=\"{link}\"> Confirm account</a>");

            return Ok();
        }
    }
}
