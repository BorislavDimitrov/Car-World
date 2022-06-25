using CarWorld.Services.Contracts;
using CarWorld.Web.ViewModels.Categories;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CarWorld.Web.Controllers
{
    public class CategoriesController : BaseController
    {
        private readonly ICategoriesService categoriesService;

        public CategoriesController(ICategoriesService categoriesService)
        {
            this.categoriesService = categoriesService;
        }

        public async Task<IActionResult> GetAll()
        {
            var categoreis = await categoriesService.GetAllCategoriesAsync<CategoriesInListViewModel>();

            var model = new CategoriesListViewModel
            {
                Categories = categoreis,
            };

            return View(model);
        }

        public async Task<IActionResult> GetForUser()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var categories = await categoriesService.GetCategoriesByUserIdAsync(userId);

            var viewModel = new UserCategoriesListViewModel
            {
                Categories = categories,
            };

            return View(viewModel);
        }
    }
}
