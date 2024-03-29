﻿using CarWorld.Common;
using CarWorld.Data.Models;
using CarWorld.Services.Contracts;
using CarWorld.Web.Areas.Administration.Controllers;
using CarWorld.Web.ViewModels.Administration.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using System.Threading.Tasks;

namespace CarWorld.Web.Areas.Admin.Controllers
{
    public class UsersController : AdministrationController
    {
        private readonly IUsersService usersService;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly RoleManager<ApplicationRole> roleManager;

        public UsersController(IUsersService usersService,
             UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            RoleManager<ApplicationRole> roleManager)
        {
            this.usersService = usersService;
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
        }

        [HttpGet]
        public async Task<IActionResult> CreateRole()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole(CreateRoleModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            if (await roleManager.RoleExistsAsync(model.Name))
            {
                ModelState.AddModelError(string.Empty, $"Role with the name {model.Name} already exists.");
            }

            await roleManager.CreateAsync(new ApplicationRole()
            {
                Name = model.Name
            });

            TempData["CreateMessage"] = GlobalConstants.SuccessfulCreate;

            return View();
        }

        public async Task<IActionResult> ManageUsers(string search, string orderBy, int id = 1)
        {
            const int itemsPerPage = 12;

            var users = await usersService.GetUsersAsync<UserInListViewModel>(search, orderBy);

            var viewModel = new UserListViewModel()
            {
                PageNumber = id,
                Users = users.Skip((id - 1) * itemsPerPage).Take(itemsPerPage),
                ItemsCount = users.Count(),
                ItemsPerPage = itemsPerPage,
                Search = search,
                OrderBy = orderBy
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            await usersService.DeleteAccountAsync(id);

            var user = await usersService.GetUserByIdAsync(id);

            await userManager.UpdateSecurityStampAsync(user);

            TempData["DeleteMessage"] = GlobalConstants.SuccessfulDelete;

            return RedirectToAction(nameof(ManageUsers));
        }

        public async Task<IActionResult> Recover(string id)
        {
            await usersService.RecoverAccountAsync(id);

            TempData["RecoverMessage"] = GlobalConstants.SuccessfulRecover;

            return RedirectToAction(nameof(ManageUsers));
        }

        [HttpGet]
        public async Task<IActionResult> Roles(string id)
        {
            var user = await usersService.GetUserByIdAsync(id);

            var model = new UserRolesViewModel()
            {
                UserId = user.Id,
                Name = !string.IsNullOrWhiteSpace(user.FirstName + " " + user.LastName) ? user.FirstName + " " + user.LastName : user.UserName,
            };

            ViewBag.RoleItems = roleManager.Roles
                .ToList()
                .Select(r => new SelectListItem()
                {
                    Text = r.Name,
                    Value = r.Name,
                    Selected = userManager.IsInRoleAsync(user, r.Name).Result
                }).ToList();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Roles(UserRolesViewModel model)
        {
            var user = await usersService.GetUserByIdAsync(model.UserId);
            var userRoles = await userManager.GetRolesAsync(user);

            await userManager.RemoveFromRolesAsync(user, userRoles);

            if (model.RoleNames?.Length > 0)
            {
                await userManager.AddToRolesAsync(user, model.RoleNames);
            }

            return RedirectToAction(nameof(ManageUsers));
        }
    }
}
