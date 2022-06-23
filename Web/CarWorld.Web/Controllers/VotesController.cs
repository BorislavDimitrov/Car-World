using CarWorld.Services.Contracts;
using CarWorld.Web.ViewModels;
using CarWorld.Web.ViewModels.Votes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CarWorld.Web.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class VotesController : ControllerBase
    {
        private readonly IVotesService votesService;

        public VotesController(IVotesService votesService)
        {
            this.votesService = votesService;
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<VoteResponseViewModel>> Post(VoteInputModel model)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            model.UserId = userId;

            await votesService.VoteAsync(model);

            var votes = await votesService.GetVotesForPostByIdAsync(model.PostId);

            return new VoteResponseViewModel { VotesCount = votes };
        }
    }
}
