using CarWorld.Web.ViewModels.Comments;
using System.Threading.Tasks;

namespace CarWorld.Services.Contracts
{
    public interface ICommentsService
    {
        Task<bool> IsCommentInPost(int? parentId, int postId);
        Task CreateComment(CreateCommentInputModel model);
    }
}
