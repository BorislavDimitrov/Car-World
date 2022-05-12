namespace CarWorld.Web.Areas.Admin.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using CarWorld.Common;
    using CarWorld.Services.Contracts;
    using CarWorld.Web.Areas.Administration.Controllers;
    using CarWorld.Web.ViewModels.Administration.Models;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;

    public class ModelsController : AdministrationController
    {
        private readonly IModelsService modelsService;
        private readonly IMakesService makesService;

        public ModelsController(IModelsService modelsService,
            IMakesService makesService)
        {
            this.modelsService = modelsService;
            this.makesService = makesService;
        }

        public async Task<IActionResult> ManageModels(string searchText,int? makeId, int id = 1)
        {
            const int itemsPerPage = 12;

            var models = await modelsService.GetModelsAsync(searchText, makeId);

            var makes = await makesService.GetMakesAsSelectListItemAsync();

            SelectListItem defaultSelectItem = new SelectListItem
            {
                Text = "Select make",
                Value = "",
            };
            
            makes.Insert(0, defaultSelectItem);

            var viewModel = new ModelListViewModel()
            {
                PageNumber = id,
                Models = models.Skip((id - 1) * itemsPerPage).Take(itemsPerPage),
                ItemsCount = models.Count(),
                ItemsPerPage = itemsPerPage,
                Makes = makes,
                MakeId = makeId ?? null,
            };

            ViewData["CurrentFilter"] = searchText;

            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            IEnumerable<SelectListItem> makes = await makesService.GetExistingMakesAsSelectListItemAsync();

            var model = new CreateModelModel()
            {
                Makes = makes,
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateModelModel model)
        {
            IEnumerable<SelectListItem> makes = await makesService.GetMakesAsSelectListItemAsync();

            if (!ModelState.IsValid)
            {
                model.Makes = makes;
                return View(model);
            }

            try
            {
                await modelsService.CreateModelAsync(model);
            }
            catch (InvalidOperationException ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                model.Makes = makes;
                return View(model);
            }
        
            return RedirectToAction("ManageModels");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if (!await modelsService.IsModelExistingByIdAsync(id))
            {
                TempData["Message"] = GlobalConstants.RedirectToHomepageAlertMessage;
                return Redirect("/Admin/Home/Index");
            }

            var model = await modelsService.GetModelByIdAsync<EditModelInputModel>(id);
            var makes = await makesService.GetMakesAsSelectListItemAsync();

            model.Makes = makes;

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditModelInputModel model)
        {
            if (!ModelState.IsValid)
            {
                var makes = await makesService.GetMakesAsSelectListItemAsync();
                model.Makes = makes;
                return View(model);
            }

            try
            {
                await modelsService.EditModelAsync(model);
            }
            catch (InvalidOperationException ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                var makes = await makesService.GetMakesAsSelectListItemAsync();
                model.Makes = makes;
                return View(model);
            }

            return RedirectToAction(nameof(ManageModels));
        }

        public async Task<IActionResult> Delete(int id)
        {
            if (!await modelsService.IsModelExistingByIdAsync(id))
            {
                TempData["Message"] = GlobalConstants.RedirectToHomepageAlertMessage;
                return Redirect("/Admin/Home/Index");
            }

            await modelsService.DeleteModelAsync(id);

            return RedirectToAction(nameof(ManageModels));
        }

        public async Task<IActionResult> Recover(int id)
        {
            if (!await modelsService.IsModelExistingByIdAsync(id))
            {
                TempData["Message"] = GlobalConstants.RedirectToHomepageAlertMessage;
                return Redirect("/Admin/Home/Index");
            }

            await modelsService.RecoverModelAsync(id);

            return RedirectToAction(nameof(ManageModels));
        }
    }
}
