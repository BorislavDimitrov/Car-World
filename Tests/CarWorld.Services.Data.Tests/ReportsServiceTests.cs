using CarWorld.Data;
using CarWorld.Data.Models;
using CarWorld.Data.Repositories;
using CarWorld.Services.Contracts;
using CarWorld.Services.Mapping;
using CarWorld.Web.ViewModels.Administration;
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

            AutoMapperConfig.RegisterMappings(typeof(MakeInListViewModel).Assembly);
        }
    }
}
