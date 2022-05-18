namespace CarWorld.Web.Areas.Admin.Controllers
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using CarWorld.Common;
    using CarWorld.Services.Contracts;
    using CarWorld.Web.Areas.Administration.Controllers;
    using CarWorld.Web.ViewModels.Administration.Regions;
    using Microsoft.AspNetCore.Mvc;

    public class RegionsController : AdministrationController
    {
        private readonly IRegionsService regionsService;

        public RegionsController(IRegionsService regionsService)
        {
            this.regionsService = regionsService;
        }

        [HttpGet]
        public async Task<IActionResult> ManageRegions(string search, string orderBy, int id = 1)
        {
            const int itemsPerPage = 12;

            var regions = await regionsService.GetRegionsAsync<RegionsInListViewModel>(search, orderBy);

            var viewModel = new RegionsListViewModel()
            {
                PageNumber = id,
                Regions = regions.Skip((id - 1) * itemsPerPage).Take(itemsPerPage),
                ItemsCount = regions.Count(),
                ItemsPerPage = itemsPerPage,
                Search = search,
                OrderBy = orderBy,
            };

            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateRegionInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                await regionsService.CreateRegionAsync(model);
            }
            catch (InvalidOperationException ex)
            {
                this.ModelState.AddModelError(string.Empty, ex.Message);
                return View(model);
            }

            TempData["CreateMessage"] = GlobalConstants.SuccessfulCreate;

            return RedirectToAction(nameof(ManageRegions));
        }

        public async Task<IActionResult> Delete(int id)
        {           

            if (!await regionsService.IsRegionExistingByIdAsync(id))
            {
                TempData["ErrorMessage"] = GlobalConstants.RedirectToHomepageAlertMessage;
                return Redirect("/Admin/Home/index");
            }

            await regionsService.DeleteRegionAsync(id);

            TempData["DeleteMessage"] = GlobalConstants.SuccessfulDelete;

            return RedirectToAction(nameof(ManageRegions));
        }

        public async Task<IActionResult> Recover(int id)
        {
            if (!await regionsService.IsRegionExistingByIdAsync(id))
            {
                TempData["ErrorMessage"] = GlobalConstants.RedirectToHomepageAlertMessage;
                return Redirect("/Admin/Home/index");
            }

            await regionsService.RecoverRegionAsync(id);

            TempData["RecoverMessage"] = GlobalConstants.SuccessfulRecover;

            return RedirectToAction(nameof(ManageRegions));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if (!await regionsService.IsRegionExistingByIdAsync(id))
            {
                TempData["ErrorMessage"] = GlobalConstants.RedirectToHomepageAlertMessage;
                return Redirect("/Admin/Home/index");
            }

            var model = await regionsService.GetRegionByIdAsync<EditRegionInputModel>(id);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditRegionInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                await regionsService.EditRegionAsync(model);
            }
            catch (InvalidOperationException ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(model);
            }

            TempData["EditMessage"] = GlobalConstants.SuccessfulEdit;

            return RedirectToAction(nameof(ManageRegions));
        }
    }
}
