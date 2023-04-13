using CarWorld.Data;
using CarWorld.Data.Common.Repositories;
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
    public class VotesServicesTests
    {
        private DbContextOptionsBuilder<ApplicationDbContext> options;
        private ApplicationDbContext dbContext;
        private IRepository<Vote> votesRepository;
        private IVotesService votesService;

        [SetUp]
        public async Task SetUp()
        {
            this.options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString());
            this.dbContext = new ApplicationDbContext(this.options.Options);
            this.votesRepository = new EfRepository<Vote>(this.dbContext);
            this.votesService = new VotesService(this.votesRepository);
        }

    }
}
