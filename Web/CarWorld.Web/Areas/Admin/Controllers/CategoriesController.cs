using CarWorld.Common;
using CarWorld.Services.Contracts;
using CarWorld.Web.Areas.Administration.Controllers;
using CarWorld.Web.ViewModels.Administration.Categories;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CarWorld.Web.Areas.Admin.Controllers
{
    public class CategoriesController : AdministrationController
    {
        private readonly ICategoriesService categoriesService;
        private readonly IWebHostEnvironment webHostEnvironment;

        public CategoriesController(ICategoriesService categoriesService,
            IWebHostEnvironment webHostEnvironment)
        {
            this.categoriesService = categoriesService;
            this.webHostEnvironment = webHostEnvironment;
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCategoryInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var wwwrootPath = webHostEnvironment.WebRootPath;

            try
            {
                await categoriesService.CreateCategoryAsync(model, wwwrootPath);
            }
            catch (InvalidOperationException ex)
            {
                this.ModelState.AddModelError(string.Empty, ex.Message);
                return View(model);
            }

            TempData["CreateMessage"] = GlobalConstants.SuccessfulCreate;

            return RedirectToAction(nameof(ManageCategories));
        }

        public async Task<IActionResult> Delete(int id)
        {
            if (!await categoriesService.IsCategoryExistingForAdminByIdAsync(id))
            {
                TempData["ErrorMessage"] = GlobalConstants.RedirectToHomepageAlertMessage;
                return Redirect("/Admin/Home/index");
            }

            await categoriesService.DeleteMakeAsync(id);

            TempData["DeleteMessage"] = GlobalConstants.SuccessfulDelete;

            return RedirectToAction(nameof(ManageCategories));
        }

        public async Task<IActionResult> Recover(int id)
        {
            if (!await categoriesService.IsCategoryExistingForAdminByIdAsync(id))
            {
                TempData["ErrorMessage"] = GlobalConstants.RedirectToHomepageAlertMessage;
                return Redirect("/Admin/Home/index");
            }

            await categoriesService.RecoverCategoryAsync(id);

            TempData["RecoverMessage"] = GlobalConstants.SuccessfulRecover;

            return RedirectToAction(nameof(ManageCategories));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if (!await categoriesService.IsCategoryExistingForAdminByIdAsync(id))
            {
                TempData["ErrorMessage"] = GlobalConstants.RedirectToHomepageAlertMessage;
                return Redirect("/Admin/Home/index");
            }

            var model = await categoriesService.GetCategoryForAdminAsync<EditCategoryInputModel>(id);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditCategoryInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var wwwrootPath = webHostEnvironment.WebRootPath;

            try
            {
                await categoriesService.EditCategoryAsync(model, wwwrootPath);
            }
            catch (InvalidOperationException ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(model);
            }

            TempData["EditMessage"] = GlobalConstants.SuccessfulEdit;

            return RedirectToAction(nameof(ManageCategories));
        }

        [HttpGet]
        public async Task<IActionResult> ManageCategories()
        {
            var categories = await categoriesService.GetAllCategoriesForAdminAsync<CategoriesForAdminInListViewModel>();

            var viewModel = new CategoriesForAdminListViewModel
            {
                Categories = categories,
            };

            return View(viewModel);
        }
    }
}
