using CarWorld.Data.Common.Repositories;
using CarWorld.Data.Models;
using CarWorld.Data.Models.Enums;
using CarWorld.Services.Contracts;
using CarWorld.Web.ViewModels.Votes;
using System.Linq;
using System.Threading.Tasks;

namespace CarWorld.Services
{
    public class VotesService : IVotesService
    {
        private readonly IRepository<Vote> votesRepo;

        public VotesService(IRepository<Vote> votesRepo)
        {
            this.votesRepo = votesRepo;
        }

        public async Task<int> GetVotesForPostByIdAsync(int postId)
                => votesRepo.All()
            .Where(x => x.PostId == postId)
            .Sum(x => (int)x.Type);

        public async Task VoteAsync(VoteInputModel model)
        {
            var vote = this.votesRepo.All()
                .FirstOrDefault(x => x.UserId == model.UserId && x.PostId == model.PostId);

            if (vote != null)
            {
                vote.Type = model.IsUpVote ? VoteType.UpVote : VoteType.DownVote;
            }
            else
            {
                vote = new Vote
                {
                    UserId = model.UserId,
                    PostId = model.PostId,
                    Type = model.IsUpVote ? VoteType.UpVote : VoteType.DownVote,
                };

                await votesRepo.AddAsync(vote);
            }

            await votesRepo.SaveChangesAsync();
        }
    }
}
