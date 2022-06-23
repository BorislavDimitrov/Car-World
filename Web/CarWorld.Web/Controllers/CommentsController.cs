using CarWorld.Common;
using CarWorld.Services.Contracts;
using CarWorld.Web.ViewModels.Comments;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CarWorld.Web.Controllers
{
    public class CommentsController : BaseController
    {
        private readonly ICommentsService commentsService;

        public CommentsController(ICommentsService commentsService)
        {
            this.commentsService = commentsService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCommentInputModel model)
        {
            //var parentId = model.ParentId == 0 ? (int?)null : model.ParentId;

            if (model.ParentId != null)
            {
                if (!await commentsService.IsCommentInPost(model.ParentId, model.PostId))
                {
                    TempData["ErrorMessage"] = GlobalConstants.RedirectToHomepageAlertMessage;
                    return Redirect("/Home/index");
                }
            }

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            model.UserId = userId;

            await commentsService.CreateComment(model);

            return RedirectToAction("Details", "Posts", new { id = model.PostId });
        }
    }
}
