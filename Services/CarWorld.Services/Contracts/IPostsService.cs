using CarWorld.Web.ViewModels.Posts;
using System.Threading.Tasks;

namespace CarWorld.Services.Contracts
{
    public interface IPostsService
    {
        Task<int> CreatePostAsync(CreatePostInputModel model);

        Task<bool> IsPostExistingForUserByIdAsync(int id);

        Task<DetailsPostViewModel> GetPostDetailsByIdAsync(int id);
    }
}
