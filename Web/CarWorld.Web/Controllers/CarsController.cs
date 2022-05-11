namespace CarWorld.Web.Controllers
{
    using System.Linq;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using CarWorld.Common;
    using CarWorld.Services.Contracts;
    using CarWorld.Web.ViewModels.Cars;
    using CarWorld.Web.ViewModels.Paging;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;

    public class CarsController : Controller
    {
        private readonly IMakesService makesService;
        private readonly IRegionsService regionsService;
        private readonly IModelsService modelsService;
        private readonly ICarsService carsService;
        private readonly IWebHostEnvironment webHostEnvironment;

        public CarsController(IMakesService makesService,
            IRegionsService regionsService,
            IModelsService modelsService,
            ICarsService carsService,
            IWebHostEnvironment webHostEnvironment)
        {
            this.makesService = makesService;
            this.regionsService = regionsService;
            this.modelsService = modelsService;
            this.carsService = carsService;
            this.webHostEnvironment = webHostEnvironment;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var regions = await regionsService.GetExistingRegionsAsync();
            var makes = await makesService.GetExistingMakesAsSelectListItemAsync();
            var makeId = makes.FirstOrDefault().Value;
            var models = await modelsService.GetModelsByMakeIdAsync(int.Parse(makeId));

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
                var regions = await regionsService.GetExistingRegionsAsync();
                var makes =  await makesService.GetExistingMakesAsSelectListItemAsync();
                var makeId = makes.FirstOrDefault().Value;
                var models = await modelsService.GetModelsByMakeIdAsync(int.Parse(makeId));

                model.Regions = regions;
                model.Makes = makes;
                model.Models = models;
                return View(model);
            }

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);   
            model.UserId = userId;

            string wwwrootPath = webHostEnvironment.WebRootPath;

            await carsService.CreateCarAsync(model, wwwrootPath);

            return RedirectToAction("UserCars");
        }
        
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Edit(int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (!await carsService.IsCarMadeByUserAsync(id, userId))
            {
                TempData["Message"] = GlobalConstants.RedirectToHomepageAlertMessage;
                return Redirect("/Home/index");
            }          

            var model = await carsService.GetCarByIdAsync<EditCarInputModel>(id);

            var regions = await regionsService.GetExistingRegionsAsync();
            var makes = await makesService.GetExistingMakesAsSelectListItemAsync();
            var models = await modelsService.GetModelsByMakeIdAsync(model.MakeId);        
            
            model.Regions = regions;
            model.Makes= makes;
            model.Models= models;

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditCarInputModel model)
        {
            if (!ModelState.IsValid)
            {
                var cities = await regionsService.GetExistingRegionsAsync();
                var makes = await makesService.GetExistingMakesAsSelectListItemAsync();
                var models = await modelsService.GetModelsByMakeIdAsync(model.MakeId);
                model.Regions = cities;
                model.Makes = makes;
                model.Models = models;

                return View(model);
            }         

            string wwwroot = webHostEnvironment.WebRootPath;

            await carsService.EditCarAsync(model, wwwroot);

            return RedirectToAction(nameof(UserCars));
        }   

        [HttpGet]
        [Authorize]
        public async Task<ActionResult> UserCars(int id = 1)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            const int itemsPerPage = 12;

            var cars = await carsService.GetUserCarsAsync(userId);

            var viewModel = new UsersCarsListViewModel()
            {
                PageNumber = id,
                Cars = cars.Skip((id - 1) * itemsPerPage).Take(itemsPerPage),
                ItemsCount = cars.Count(),
                ItemsPerPage = itemsPerPage,
            };

            //ViewData["CurrentFilter"] = searchString;

            return View(viewModel);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (!await carsService.IsCarMadeByUserAsync(id, userId))
            {
                TempData["Message"] = GlobalConstants.RedirectToHomepageAlertMessage;
                return Redirect("/Home/index");
            }

            await carsService.DeleteCarAsync(id);

            return RedirectToAction(nameof(UserCars));
        }

        public async Task<IActionResult> Details(int id)
        {
            var model = await carsService.GetCarDetails(id);

            if (!await carsService.IsCarExistingForUserByIdAsync(id))
            {
                TempData["Message"] = GlobalConstants.RedirectToHomepageAlertMessage;
                return Redirect("/Home/index");
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Search(int id = 1)
        {
            const int itemsPerPage = 1;

            var cars = await carsService.GetSearchCarsAsync<SearchCarsInListViewModel>();

            var viewModel = new SearchCarsListViewModel()
            {
                PageNumber = id,
                Cars = cars.Skip((id - 1) * itemsPerPage).Take(itemsPerPage),
                ItemsCount = carsService.GetCount(),
                ItemsPerPage = itemsPerPage,
            };

            return View(viewModel);
        }

        public async Task<IActionResult> GetModels(int makeId)
        {
            var models = await modelsService.GetModelsByMakeIdAsync(makeId);

            return Json(new SelectList(models, "ModelId", "ModelName"));
        }
    }
}
