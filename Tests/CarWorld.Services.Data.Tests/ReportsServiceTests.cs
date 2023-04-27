using CarWorld.Data;
using CarWorld.Data.Models;
using CarWorld.Data.Models.Enums;
using CarWorld.Data.Repositories;
using CarWorld.Services.Contracts;
using CarWorld.Services.Mapping;
using CarWorld.Web.ViewModels.Administration;
using CarWorld.Web.ViewModels.Administration.CarReports;
using CarWorld.Web.ViewModels.Reports;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
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

        private async Task ReportsSeedingAsync(int count)
        {
            for (int i = 0; i < count; i++)
            {
                await this.reportsService.CreateCarReportAsync(new CarReportInputModel
                {
                    CarId = i,
                    Description = "Description",
                    Title = "Title",
                    ReporterId = i.ToString(),
                    ReportType = ReportType.Scam,
                });
            }
        }
    }
}
