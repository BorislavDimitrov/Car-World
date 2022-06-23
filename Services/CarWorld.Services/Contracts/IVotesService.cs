using CarWorld.Web.ViewModels.Votes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorld.Services.Contracts
{
    public interface IVotesService
    {
        Task VoteAsync(VoteInputModel model);

        Task<int> GetVotesForPostByIdAsync(int postId);
    }
}
