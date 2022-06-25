using CarWorld.Services.Contracts;
using CarWorld.Web.ViewModels.Categories;
using Microsoft.AspNetCore.Mvc;
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
    }
}
