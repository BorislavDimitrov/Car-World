using CarWorld.Web.ViewModels.Posts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarWorld.Services.Contracts
{
    public interface IPostsService
    {
        Task<int> CreatePostAsync(CreatePostInputModel model);

        Task<bool> IsPostExistingForUserByIdAsync(int id);

        Task<DetailsPostViewModel> GetPostDetailsByIdAsync(int id);

        Task<IEnumerable<T>> GetSearchPostsAsync<T>(string search, string orderBy, int categoryId);
    }
}
