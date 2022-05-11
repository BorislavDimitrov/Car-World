﻿namespace CarWorld.Web.Areas.Admin.Controllers
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using CarWorld.Common;
    using CarWorld.Services.Contracts;
    using CarWorld.Web.Areas.Administration.Controllers;
    using CarWorld.Web.ViewMod.els.Administration.Makes;
    using CarWorld.Web.ViewModels.Administration;
    using CarWorld.Web.ViewModels.Administration.Makes;
    using Microsoft.AspNetCore.Mvc;

    public class MakesController : AdministrationController
    {
        private readonly IMakesService makesService;

        public MakesController(IMakesService makesService)
        {
            this.makesService = makesService;
        }

        public async Task<IActionResult> Delete(int id)
        {
            if (!await makesService.IsMakeExistingByIdAsync(id))
            {
                TempData["Message"] = GlobalConstants.RedirectToHomepageAlertMessage;
                return Redirect("/Admin/Home/index");
            }

            await makesService.DeleteMakeAsync(id);

            return RedirectToAction(nameof(ManageMakes));
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateMakeInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                await makesService.CreateMakeAsync(model);
            }
            catch (InvalidOperationException ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(model);
            }

            return RedirectToAction(nameof(ManageMakes));
        }

        public async Task<IActionResult> ManageMakes(string searchText, int id = 1)
        {
            const int itemsPerPage = 12;

            var makes = await makesService.GetMakesAsync(searchText);

            var viewModel = new MakeListViewModel()
            {
                PageNumber = id,
                Makes = makes.Skip((id - 1) * itemsPerPage).Take(itemsPerPage),
                ItemsCount = makes.Count(),
                ItemsPerPage = itemsPerPage,
            };

            ViewData["CurrentFilter"] = searchText;

            return View(viewModel);
        }

        public async Task<IActionResult> Recover(int id)
        {
            if (!await makesService.IsMakeExistingByIdAsync(id))
            {
                TempData["Message"] = GlobalConstants.RedirectToHomepageAlertMessage;
                return Redirect("/Admin/Home/index");
            }

            await makesService.RecoverMakeAsync(id);

            return RedirectToAction(nameof(ManageMakes));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if (!await makesService.IsMakeExistingByIdAsync(id))
            {
                TempData["Message"] = GlobalConstants.RedirectToHomepageAlertMessage;
                return Redirect("/Admin/Home/index");
            }

            var model = await makesService.GetMakeByIdAsync<EditMakeInputModel>(id);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditMakeInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                await makesService.EditMakeAsync(model);
            }
            catch (InvalidOperationException ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(model);
            }
         
            return RedirectToAction(nameof(ManageMakes));
        }
    }
}
