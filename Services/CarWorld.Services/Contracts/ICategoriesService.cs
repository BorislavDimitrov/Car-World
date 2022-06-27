using CarWorld.Web.ViewModels.Administration.Categories;
using CarWorld.Web.ViewModels.Categories;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarWorld.Services.Contracts
{
    public interface ICategoriesService
    {
        Task<List<SelectListItem>> GetExistingCategoriesAsSelectListItemAsync();

        Task<IEnumerable<T>> GetAllCategoriesAsync<T>();

        Task<bool> IsCategoryExistingForUserByIdAsync(int categoryId);

        Task<bool> IsCategoryExistingForAdminByIdAsync(int categoryId);

        Task<T> GetCategoryByIdAsync<T>(int categoryId);

        Task<T> GetCategoryForAdminAsync<T>(int categoryId);

        Task<IEnumerable<UserCategoriesInListViewModel>> GetCategoriesByUserIdAsync(string userId);

        Task CreateCategoryAsync(CreateCategoryInputModel model, string rowwwrootPath);

        Task DeleteMakeAsync(int id);

        Task RecoverCategoryAsync(int id);

        Task EditCategoryAsync(EditCategoryInputModel model, string wwwrootPath);
    }
}
