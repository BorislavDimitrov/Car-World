using CarWorld.Common;
using CarWorld.Services.Contracts;
using CarWorld.Web.Areas.Administration.Controllers;
using CarWorld.Web.ViewModels.Administration.CarReports;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace CarWorld.Web.Areas.Admin.Controllers
{
    public class ReportsController : AdministrationController
    {
        private readonly IReportsService reportsService;
        public ReportsController(IReportsService reportsService)
        {
            this.reportsService = reportsService;
        }

        public async Task<IActionResult> ManageReports(string search, string orderBy, int id = 1)
        {
            const int itemsPerPage = 12;

            var reports = await reportsService.GetReportsAsync<CarReportsInListViewModel>(search, orderBy);

            var viewModel = new CarReportsListViewModel
            {
                PageNumber = id,
                Reports = reports.Skip((id - 1) * itemsPerPage).Take(itemsPerPage),
                ItemsCount = reports.Count(),
                ItemsPerPage = itemsPerPage,
                Search = search,
                OrderBy = orderBy,
            };

            return View(viewModel);
        }

        public async Task<IActionResult> CarReportDetails(int id)
        {
            if (!await reportsService.IsReportExistingByIdAsync(id))
            {
                TempData["ErrorMessage"] = GlobalConstants.RedirectToHomepageAlertMessage;
                return Redirect("/Admin/Home/index");
            }

            var report = await reportsService.GetReportByIdAsync<CarReportViewModel>(id);

            await reportsService.SetReportAsCheckedByIdAsync(id);

            return View(report);
        }

        [HttpPost]
        public async Task<IActionResult> CarReportDelete(int id)
        {
            if (!await reportsService.IsReportExistingByIdAsync(id))
            {
                TempData["ErrorMessage"] = GlobalConstants.RedirectToHomepageAlertMessage;
                return Redirect("/Admin/Home/index");
            }
            
            await reportsService.DeleteCarReportAsync(id);

            TempData["DeleteMessage"] = GlobalConstants.SuccessfulDelete;

            return RedirectToAction(nameof(ManageReports));
        }
    }
}
