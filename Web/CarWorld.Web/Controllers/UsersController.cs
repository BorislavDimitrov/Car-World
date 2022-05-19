namespace CarWorld.Web.Controllers
{
    using System.Security.Claims;
    using System.Threading.Tasks;
    using CarWorld.Common;
    using CarWorld.Data.Models;
    using CarWorld.Services.Contracts;
    using CarWorld.Web.ViewModels.Users;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class UsersController : BaseController
    {
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly IUsersService userService;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly UserManager<ApplicationUser> userManager;

        public UsersController(IWebHostEnvironment webHostEnvironment,
            IUsersService userService,
            SignInManager<ApplicationUser> signInManager,
            UserManager<ApplicationUser> userManager)
        {
            this.webHostEnvironment = webHostEnvironment;
            this.userService = userService;
            this.signInManager = signInManager;
            this.userManager = userManager;
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

       
    }
}
