namespace CarWorld.Services.Data.Tests
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using CarWorld.Data;
    using CarWorld.Data.Models;
    using CarWorld.Data.Repositories;
    using CarWorld.Services.Contracts;
    using CarWorld.Services.Mapping;
    using CarWorld.Web.ViewModels.Administration.Regions;
    using Microsoft.EntityFrameworkCore;
    using NUnit.Framework;

    public class RegionsServiceTests
    {
        private DbContextOptionsBuilder<ApplicationDbContext> options;
        private ApplicationDbContext dbContext;
        private EfDeletableEntityRepository<Region> regionsRepository;
        private IRegionsService regionsService;

        [SetUp]
        public void Setup()
        {
            this.options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString());
            this.dbContext = new ApplicationDbContext(this.options.Options);
            this.regionsRepository = new EfDeletableEntityRepository<Region>(this.dbContext);
            this.regionsService = new RegionsService(this.regionsRepository);

            AutoMapperConfig.RegisterMappings(typeof(RegionsInListViewModel).Assembly, typeof(CreateRegionInputModel).Assembly);
        }



        [Test]
        public async Task CreateRegionAsyncShouldSuccessfullyCreateNewRegion()
        { 
            var region = new CreateRegionInputModel()
            {
                Name = "Stara Zagora",
            };

            await this.regionsService.CreateRegionAsync(region);

            var regionsCount = this.dbContext.Regions.Count();

            Assert.AreEqual(1, regionsCount);
        }

        [Test]
        public async Task CreateRegionAsyncShouldThrowInvalidOperationExceptionDueToExistingName()
        {
            var region = new CreateRegionInputModel()
            {
                Name = "Stara Zagora",
            };

            await this.regionsService.CreateRegionAsync(region);
            Assert.ThrowsAsync<InvalidOperationException>(async () => await this.regionsService.CreateRegionAsync(region), $"Region with the name {region.Name} already exists.");
        }

        [Test]
        public async Task DeleteRegionAsyncShouldSuccessfullyDeleteARegion()
        {
            await this.RegionsSeedingAsync(5);

            await this.regionsService.DeleteRegionAsync(1);

            var activeRegionsCount = this.dbContext.Regions.Count();

            Assert.AreEqual(4, activeRegionsCount);
        }

        [Test]
        public async Task DeleteRegionAsyncShouldThrowInvalidOperationExceptionDueToNotExistingRegion()
        {
            await this.RegionsSeedingAsync(5);

            await this.regionsService.DeleteRegionAsync(1);

            Assert.ThrowsAsync<InvalidOperationException>(async () => await this.regionsService.DeleteRegionAsync(6), "The region doesnt exist.");
        }

        [Test]
        public async Task RecoverRegionAsyncShouldUnDeleteRegionSuccessfully()
        {
            this.RegionsSeedingAsync(5);

            var regionId = 1;

            await this.regionsService.DeleteRegionAsync(regionId);

            await this.regionsService.RecoverRegionAsync(regionId);

            var regions = this.dbContext.Regions;

            Assert.AreEqual(5, regions.Count());
        }

        [Test]
        public async Task GetExistingRegionsAsyncShouldReturnNonDeletedRegions()
        {
            await this.RegionsSeedingAsync(5);

            var regionId = 1;

            await this.regionsService.DeleteRegionAsync(regionId);
            var regions = await this.regionsService.GetExistingRegionsAsSelectItemListAsync();

            Assert.AreEqual(4, regions.Count());
        }

        [Test]
        public async Task GetRegionsAsyncShouldReturnDeletedAndNonDeletedRegions()
        {
            this.RegionsSeedingAsync(10);
            this.regionsService.DeleteRegionAsync(1);
            this.regionsService.DeleteRegionAsync(2);

            var regions = await this.regionsService.GetRegionsAsync<RegionsInListViewModel>(null, null);

            Assert.AreEqual(10, regions.Count());
        }

        [Test]
        public async Task GetRegionByIdAsyncShouldReturnRightRegionToEdit()
        {
            this.RegionsSeedingAsync(5);

            var regionFromService = await this.regionsService.GetRegionByIdAsync<EditRegionInputModel>(1);
            var regionFromDbContext = this.dbContext.Regions.FirstOrDefaultAsync(x => x.Id == 1);

            Assert.AreEqual(regionFromService.Id, regionFromDbContext.Id);
        }

        [Test]
        public async Task EditRegionAsyncShouldEditRegionSuccesfully()
        {
            this.RegionsSeedingAsync(5);

            var region = new EditRegionInputModel
            {
                Id = 1,
                Name = "Stara Zagora",
            };

            await this.regionsService.EditRegionAsync(region);

            var dbModel = await this.dbContext.Regions.FirstOrDefaultAsync(x => x.Id == 1);

            Assert.AreEqual("Stara Zagora", region.Name);
        }

        [Test]
        public async Task EditRegionAsyncShouldThrowInvalidOperationException()
        {
            this.RegionsSeedingAsync(5);

            var region = new EditRegionInputModel
            {
                Id = 1,
                Name = "Region5",
            };

            Assert.ThrowsAsync<InvalidOperationException>(async () => await this.regionsService.EditRegionAsync(region));
        }

        [Test]
        public async Task IsRegionExistingByNameAsyncShouldReturnTrue()
        {
            await this.RegionsSeedingAsync(5);

            var isTrue = await this.regionsService.IsRegionExistingByNameAsync("Region1");

            Assert.IsTrue(isTrue);

        }

        [Test]
        public async Task IsRegionExistingByNameAsyncShouldReturnFalse()
        {
            await this.RegionsSeedingAsync(5);

            var isFalse = await this.regionsService.IsRegionExistingByNameAsync("Region66");

            Assert.IsFalse(isFalse);

        }

        private async Task RegionsSeedingAsync(int count)
        {
            for (int i = 1; i <= count; i++)
            {
                await this.regionsService.CreateRegionAsync(new CreateRegionInputModel
                {
                    Name = $"Region{i}",
                });
            }
        }
    }
}
