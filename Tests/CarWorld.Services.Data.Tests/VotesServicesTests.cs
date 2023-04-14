using CarWorld.Data;
using CarWorld.Data.Common.Repositories;
using CarWorld.Data.Models;
using CarWorld.Data.Repositories;
using CarWorld.Services.Contracts;
using CarWorld.Services.Mapping;
using CarWorld.Web.ViewModels.Administration;
using CarWorld.Web.ViewModels.Votes;
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

        [Test]
        [TestCase(5, 1, 1)]
        [TestCase(10, 6, -1)]
        public async Task GetVotesForPostByIdAsyncShouldRetunRightNumber(
            int count,
            int postId,
            int votesCount)
        {
            await this.VotesSeedingAsync(count);

            var votes = await this.votesService.GetVotesForPostByIdAsync(postId);

            Assert.AreEqual(votesCount, votes);
        }

        [Test]
        public async Task VoteAsyncShouldSuccessfullyVoteAPost()
        {
            await this.VotesSeedingAsync(5);

            var vote = await this.dbContext.Votes.FirstOrDefaultAsync();

            await this.votesService.VoteAsync(new VoteInputModel
            {
                IsUpVote = false,
                PostId = 1,
                UserId = vote.UserId,
            });
        }

        private async Task VotesSeedingAsync(int count)
        {
            for (int i = 0; i < count; i++)
            {
                var post = new Post
                {
                    Title = i.ToString(),
                    Content = i.ToString(),
                };

                await this.dbContext.Posts.AddAsync(post);

                await this.dbContext.SaveChangesAsync();

                await this.votesService.VoteAsync(new VoteInputModel
                {
                    IsUpVote = (i <= (count / 2)) ? true : false,
                    PostId = i,
                    UserId = Guid.NewGuid().ToString(),
                });
            }
        }
    }
}
