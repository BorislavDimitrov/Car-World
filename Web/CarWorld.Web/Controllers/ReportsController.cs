using CarWorld.Common;
using CarWorld.Services.Contracts;
using CarWorld.Web.ViewModels.Reports;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CarWorld.Web.Controllers
{
    public class ReportsController : BaseController
    {
        private readonly ICarsService carsService;
        private readonly IReportsService reportsService;

        public ReportsController(ICarsService carsService,
            IReportsService reportsService)
        {
            this.carsService = carsService;
            this.reportsService = reportsService;
        }

        [HttpGet]
        public async Task<IActionResult> ReportCar(string reporterId, int carId)
        {
            var model = new CarReportInputModel()
            {
                ReporterId = reporterId,
                CarId = carId,
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> ReportCar(CarReportInputModel model)
        {          
            if (!await carsService.IsCarExistingForUserByIdAsync(model.CarId))
            {
                TempData["ErrorMessage"] = GlobalConstants.RedirectToHomepageAlertMessage;
                return Redirect("/Home/index");
            }

            if (!ModelState.IsValid)
            {
                return View();
            }

            await reportsService.CreateCarReportAsync(model);

            TempData["CreateMessage"] = "The report is sent succesfully.";

            return Redirect("/Home/Index");
        }
    }
}
