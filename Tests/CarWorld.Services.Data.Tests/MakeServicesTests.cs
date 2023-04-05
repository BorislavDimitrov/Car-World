using CarWorld.Data;
using CarWorld.Data.Models;
using CarWorld.Data.Repositories;
using CarWorld.Services.Contracts;
using CarWorld.Services.Mapping;
using CarWorld.Web.ViewModels.Administration;
using CarWorld.Web.ViewModels.Administration.Makes;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarWorld.Services.Data.Tests
{
    public class MakeServicesTests
    {
        private DbContextOptionsBuilder<ApplicationDbContext> options;
        private ApplicationDbContext dbContext;
        private EfDeletableEntityRepository<Make> makesRepository;
        private IMakesService makesService;

        [SetUp]
        public async Task SetUp()
        {
            this.options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString());
            this.dbContext = new ApplicationDbContext(this.options.Options);
            this.makesRepository = new EfDeletableEntityRepository<Make>(this.dbContext);
            this.makesService = new MakesService(this.makesRepository);

            AutoMapperConfig.RegisterMappings(typeof(MakeInListViewModel).Assembly);
        }

        [Test]
        public async Task CreateMakeAsyncShouldSuccessfullyCreateNewMake()
        {
            var make = new CreateMakeInputModel
            {
                Name = "Porsche",
            };

            await this.makesService.CreateMakeAsync(make);

            var makesCount = this.dbContext.Makes.Count();

            Assert.AreEqual(1, makesCount);
        }

        [Test]
        public async Task DeleteMakeAsyncShouldSuccessfullyDeleteMake()
        {
            await this.MakesSeedingAsync(5);

            await this.makesService.DeleteMakeAsync(1);

            var makesCount = await this.dbContext.Makes.CountAsync();

            Assert.AreEqual(4, makesCount);
        }

        [Test]
        public async Task CreateMakeAsyncShouldThrowInvalidOperationExceptionDueToExistingName()
        {
            await this.MakesSeedingAsync(5);

            var make = new CreateMakeInputModel
            {
                Name = "Make1",
            };

            Assert.ThrowsAsync<InvalidOperationException>(async () => await this.makesService.CreateMakeAsync(make), $"Make with the name {make.Name} already exists.");
        }

        [Test]
        public async Task EditMakeAsyncShouldSuccessfullyEditAMake()
        {
            await this.MakesSeedingAsync(5);

            var editModel = new EditMakeInputModel
            {
                Name = "Porsche",
                Id = 1,
            };

            await this.makesService.EditMakeAsync(editModel);

            var dbModel = await this.dbContext.Makes.FirstOrDefaultAsync(x => x.Id == 1);

            Assert.AreEqual("Porsche", dbModel.Name);
        }

        [Test]
        public async Task EditMakeAsyncShouldThrowInvalidOperationException()
        {
            await this.MakesSeedingAsync(5);

            var editModel = new EditMakeInputModel()
            {
                Id = 1,
                Name = "Make5",
            };

            Assert.ThrowsAsync<InvalidOperationException>
                (async () => await this.makesService.EditMakeAsync(editModel));
        }

        [Test]
        public async Task GetMakeByIdAsyncShouldReturnTheRightMake()
        {
            await this.MakesSeedingAsync(5);

            var make = await this.makesService.GetMakeByIdAsync<MakeInListViewModel>(1);

            Assert.AreEqual(1, make.Id);
        }

        [Test]
        [TestCase(null, null, 3, "Make1", "Make2", "Make3")]
        [TestCase(null, "NameDesc", 3, "Make3", "Make2", "Make1")]
        [TestCase("1", null, 1, "Make1", null, null)]
        public async Task GetMakesAsyncShouldReturnRightMakes(
            string search,
            string order,
            int count,
            string firstName,
            string secondName,
            string thirdName)
        {
            await this.MakesSeedingAsync(3);

            var names = new List<string>();
            names.Add(firstName);
            names.Add(secondName);
            names.Add(thirdName);

            var makes = await this.makesService.GetMakesAsync<MakeInListViewModel>(search, order);
            var listMakes = makes.ToList();

            Assert.AreEqual(count, makes.Count());

            for (int i = 0; i < makes.Count(); i++)
            {
                Assert.AreEqual(names[i], listMakes[i].Name);
            }
        }

        [Test]
        public async Task RecoverMakeAsyncShouldSuccessfullyRecoverAMake()
        {
            await this.MakesSeedingAsync(5);

            await this.makesService.DeleteMakeAsync(1);
            await this.makesService.RecoverMakeAsync(1);

            var make = await this.dbContext.Makes.FirstOrDefaultAsync();

            Assert.AreEqual("Make1", make.Name);
        }

        [Test]
        public async Task IsMakeExistingByNameAsyncShouldReturnTrue()
        {
            await this.MakesSeedingAsync(5);

            var isTrue = await this.makesService.IsMakeExistingByNameAsync("Make1");

            Assert.IsTrue(isTrue);
        }

        private async Task MakesSeedingAsync(int count)
        {
            for (int i = 1; i <= count; i++)
            {
                await this.makesService.CreateMakeAsync(new CreateMakeInputModel
                {
                    Name = $"Make{i}"
                });
            }
        }
    }
}
