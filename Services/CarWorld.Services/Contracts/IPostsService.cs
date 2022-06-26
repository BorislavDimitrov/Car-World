using CarWorld.Web.ViewModels.Posts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarWorld.Services.Contracts
{
    public interface IPostsService
    {
        Task<int> CreatePostAsync(CreatePostInputModel model);

        Task<bool> IsPostExistingForUserByIdAsync(int id);

        Task<T> GetPostDetailsByIdAsync<T>(int id);

        Task<IEnumerable<T>> GetSearchPostsAsync<T>(string search, string orderBy, int categoryId);

        Task<bool> IsUserHavingPostsInCategoryAsync(string userId, int categoryId);

        Task<IEnumerable<T>> GetUserPostsAsync<T>(string userId, string search, string orderBy, int categoryId);

        Task<bool> IsPostCreatedByUserAsync(string userId, int id);

        Task EditPostAsync(EditPostInputModel model);
        Task DeletePostAsync(int id);
    }
}
