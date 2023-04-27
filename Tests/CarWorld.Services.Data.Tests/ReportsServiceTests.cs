using CarWorld.Data;
using CarWorld.Data.Models;
using CarWorld.Data.Models.Enums;
using CarWorld.Data.Repositories;
using CarWorld.Services.Contracts;
using CarWorld.Services.Mapping;
using CarWorld.Web.ViewModels.Administration.CarReports;
using CarWorld.Web.ViewModels.Reports;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CarWorld.Services.Data.Tests
{
    public class ReportsServiceTests
    {
        private DbContextOptionsBuilder<ApplicationDbContext> options;
        private ApplicationDbContext dbContext;
        private EfRepository<CarReport> reportsRepository;
        private IReportsService reportsService;

        [SetUp]
        public async Task SetUp()
        {
            this.options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString());
            this.dbContext = new ApplicationDbContext(this.options.Options);
            this.reportsRepository = new EfRepository<CarReport>(this.dbContext);
            this.reportsService = new ReportsService(this.reportsRepository);

            AutoMapperConfig.RegisterMappings(typeof(CarReportsInListViewModel).Assembly);
        }

        [Test]
        public async Task CreateCarReportAsyncShouldSuccessfullyCreateAReport()
        {
            await this.ReportsSeedingAsync(1);

            var reportsCount = await this.dbContext.CarReports.CountAsync();

            Assert.AreEqual(1, reportsCount);
        }

        [Test]
        public async Task DeleteCarReportAsyncShouldDeleteCarReport()
        {
            await this.ReportsSeedingAsync(1);

            await this.reportsService.DeleteCarReportAsync(1);

            var reportsCount = await this.dbContext.CarReports.CountAsync();

            Assert.AreEqual(0, reportsCount);
        }

        [Test]
        public async Task GetReportByIdAsyncShouldReturnRightCarReport()
        {
            await this.ReportsSeedingAsync(5);

            var carReport = await this.reportsService.GetReportByIdAsync<CarReportViewModel>(1);

            Assert.AreEqual("Title0", carReport.Title);
        }

        [Test]
        public async Task GetReportsAsyncShouldReturnRightCarReports()
        {
            await this.ReportsSeedingAsync(5);

            var carReportsCount = await this.dbContext.CarReports.CountAsync();

            var carReports = await this.reportsService.GetReportsAsync<CarReportsInListViewModel>("Description", "Oldest");

            Assert.AreEqual(5, carReportsCount);
            Assert.AreEqual("Title4", carReports[0].Title);
        }

        private async Task ReportsSeedingAsync(int count)
        {
            for (int i = 0; i < count; i++)
            {
                await this.reportsService.CreateCarReportAsync(new CarReportInputModel
                {
                    CarId = i,
                    Description = "Description",
                    Title = $"Title{i}",
                    ReporterId = i.ToString(),
                    ReportType = ReportType.Scam,
                });
            }
        }
    }
}
