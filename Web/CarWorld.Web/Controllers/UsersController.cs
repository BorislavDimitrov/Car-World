namespace CarWorld.Web.Controllers
{
    using System.Linq;
    using System.Security.Claims;
    using System.Text;
    using System.Threading.Tasks;
    using CarWorld.Common;
    using CarWorld.Data.Models;
    using CarWorld.Services.Contracts;
    using CarWorld.Web.ViewModels.Cars;
    using CarWorld.Web.ViewModels.Users;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.WebUtilities;

    public class UsersController : Controller
    {
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly IUsersService userService;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly ICarsService carsService;
        private readonly IMakesService makesService;
        private readonly IModelsService modelsService;
        private readonly IRegionsService regionsService;

        public UsersController(IWebHostEnvironment webHostEnvironment,
            IUsersService userService,
            SignInManager<ApplicationUser> signInManager,
            UserManager<ApplicationUser> userManager,
            ICarsService carsService,
            IMakesService makesService,
            IModelsService modelsService,
            IRegionsService regionsService)
        {
            this.webHostEnvironment = webHostEnvironment;
            this.userService = userService;
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.carsService = carsService;
            this.makesService = makesService;
            this.modelsService = modelsService;
            this.regionsService = regionsService;
        }

        [HttpGet]
        public IActionResult Delete()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Delete(DeleteUserInputModel deleteView)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await userService.GetUserByIdAsync(userId);

            if (!await userManager.CheckPasswordAsync(user, deleteView.Password))
            {
                ModelState.AddModelError(string.Empty, "Incorrect Password.");
                return View();
            }

            await userService.DeleteAccountAsync(userId);

            await signInManager.SignOutAsync();

            return Redirect("/");
        }

        [Authorize]
        [HttpGet]
        public IActionResult AccountManager()
        {
            return View();
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Edit()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var model = await userService.GetUserSelfInfoAsync(userId);

            return View(model);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Edit(EditUserInputModel editModel)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await userService.GetUserByIdAsync(userId);

            if (!ModelState.IsValid)
            {
                editModel.ImagePath = user.ImagePath;
                return View(editModel);
            }

            string wwwrootPath = webHostEnvironment.WebRootPath;

            await userService.EditAccountAsync(userId, editModel, wwwrootPath);

            editModel.ImagePath = user.ImagePath;
            return View(editModel);
        }

        public async Task<IActionResult> ViewProfile(string userId, string search, int? makeId, int? modelId, int? regionId, string orderBy, int id = 1)
        {
            var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var user = await userManager.FindByIdAsync(userId);


            if (currentUserId == userId || user == null)
            {
                TempData["ErrorMessage"] = GlobalConstants.RedirectToHomepageAlertMessage;
                return Redirect("/Home/index");
            }

            const int itemsPerPage = 12;

            var cars = await carsService.GetUserCarsAsync<UserCarsInListViewModel>(userId, search, makeId, modelId, regionId, orderBy);

            var makes = await makesService.GetExistingMakesAsSelectListItemAsync();

            var models = await modelsService.GetModelsForDropdownByMakeIdAsync(makeId);

            var regions = await regionsService.GetExistingRegionsAsSelectItemListAsync();


            var viewModel = new ProfileViewModel()
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
                Regions = regions,
                FirstName = user.FirstName ?? "Not provided",
                LastName = user.LastName ?? "Not provided",
                UserName = user.UserName,
                ImagePath = user.ImagePath,
                PhoneNumber = user.PhoneNumber ?? "Not provided",
                Email = user.Email ?? "Not provided",
                UserId = userId,
            };

            return View(viewModel);
        }

        public async Task<IActionResult> ConfirmEmail(string userId, string token)
        {
            if (userId == null || token == null)
            {
                TempData["ErrorMessage"] = "Confirm email failed !";
                return Redirect("/Home/Index");
            }

            var user = await userManager.FindByIdAsync(userId);

            if (user == null)
            {
                TempData["ErrorMessage"] = "Confirm email failed !";
                return Redirect("/Home/Index");
            }

            var tokenByte = WebEncoders.Base64UrlDecode(token);
            token = Encoding.UTF8.GetString(tokenByte);

            var result = await userManager.ConfirmEmailAsync(user, token);

            if (result.Succeeded)
            {
                return Redirect("/Identity/Account/Login");
            }
            else
            {
                TempData["ErrorMessage"] = GlobalConstants.RedirectToHomepageAlertMessage;
                return Redirect("/Home/Index");
            }
        }

        public async Task<IActionResult> ConfirmEmailChange(string userId, string token, string oldEmail, string newEmail)
        {
            if (userId == null || token == null)
            {
                TempData["ErrorMessage"] = "Confirm email failed !";
                return Redirect("/Home/Index");
            }

            var user = await userManager.FindByIdAsync(userId);

            if (user == null)
            {
                TempData["ErrorMessage"] = "Confirm email failed !";
                return Redirect("/Home/Index");
            }

            if (user.Email != oldEmail)
            {
                TempData["ErrorMessage"] = "Confirm email failed !";
                return Redirect("/Home/Index");
            }

            var tokenByte = WebEncoders.Base64UrlDecode(token);
            token = Encoding.UTF8.GetString(tokenByte);

            var result = await userManager.ChangeEmailAsync(user, newEmail, token);

            TempData["CreateMessage"] = "New email verified";
            return Redirect("/Identity/Account/Manage/Email");
        }
    }
}
