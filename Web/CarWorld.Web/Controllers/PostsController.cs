using CarWorld.Common;
using CarWorld.Services.Contracts;
using CarWorld.Web.ViewModels.Posts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CarWorld.Web.Controllers
{
    public class PostsController : Controller
    {
        private readonly ICategoriesService categoriesService;
        private readonly IPostsService postsService;

        public PostsController(ICategoriesService categoriesService,
            IPostsService postsService)
        {
            this.categoriesService = categoriesService;
            this.postsService = postsService;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var categories = await categoriesService.GetExistingCategoriesAsSelectListItemAsync();

            var model = new CreatePostInputModel
            {
                Categories = categories,
            };

            return View(model);
        }

        public async Task<IActionResult> Create(CreatePostInputModel model)
        {
            if (!ModelState.IsValid)
            {
                var categories = await categoriesService.GetExistingCategoriesAsSelectListItemAsync();
                model.Categories = categories;
                return View(model);
            }

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            model.CreatorId = userId;

            int postId = await postsService.CreatePostAsync(model);

            TempData["CreateMessage"] = GlobalConstants.SuccessfulCreate;

            return RedirectToAction(nameof(Details),new {id = postId});
        }

        public async Task<IActionResult> Details(int id)
        {
            if (!await postsService.IsPostExistingForUserByIdAsync(id))
            {
                TempData["ErrorMessage"] = GlobalConstants.RedirectToHomepageAlertMessage;
                return Redirect("/Home/index");
            }

            var model = await postsService.GetPostDetailsByIdAsync<DetailsPostViewModel>(id);

            return View(model);
        }

        public async Task<IActionResult> Search(string search, string orderBy, int categoryId, int id = 1)
        {
            if (!await categoriesService.IsCategoryExistingByIdAsync(categoryId))
            {
                TempData["ErrorMessage"] = GlobalConstants.RedirectToHomepageAlertMessage;
                return Redirect("/Home/index");
            }

            var viewModel = await categoriesService.GetCategoryById<PostsListViewModel>(categoryId);

            const int itemsPerPage = 12;

            var posts = await postsService.GetSearchPostsAsync<PostInListViewModel>(search, orderBy, categoryId);

            viewModel.PageNumber = id;
            viewModel.CategoryPosts = posts.Skip((id - 1) * itemsPerPage).Take(itemsPerPage);
            viewModel.ItemsCount = posts.Count();
            viewModel.ItemsPerPage = itemsPerPage;
            viewModel.Search = search;
            viewModel.OrderBy = orderBy;

            return View(viewModel);
        }

        public async Task<IActionResult> UserPosts(string search, string orderBy, int categoryId, int id = 1)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (!(await categoriesService.IsCategoryExistingByIdAsync(categoryId) && await postsService.IsUserHavingPostsInCategoryAsync(userId, categoryId)))
            {
                TempData["ErrorMessage"] = GlobalConstants.RedirectToHomepageAlertMessage;
                return Redirect("/Home/index");
            }

            var viewModel = await categoriesService.GetCategoryById<PostsListViewModel>(categoryId);

            const int itemsPerPage = 12;

            var posts = await postsService.GetUserPostsAsync<PostInListViewModel>(userId, search, orderBy, categoryId);

            viewModel.PageNumber = id;
            viewModel.CategoryPosts = posts.Skip((id - 1) * itemsPerPage).Take(itemsPerPage);
            viewModel.ItemsCount = posts.Count();
            viewModel.ItemsPerPage = itemsPerPage;
            viewModel.Search = search;
            viewModel.OrderBy = orderBy;

            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (!await postsService.IsPostCreatedByUserAsync(userId, id))
            {
                TempData["ErrorMessage"] = GlobalConstants.RedirectToHomepageAlertMessage;
                return Redirect("/Home/index");
            }

            var model = await postsService.GetPostDetailsByIdAsync<EditPostInputModel>(id);

            var categories = await categoriesService.GetExistingCategoriesAsSelectListItemAsync();

            model.Categories = categories;

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditPostInputModel model)
        {
            if (!ModelState.IsValid)
            {
                var categories = await categoriesService.GetExistingCategoriesAsSelectListItemAsync();
                model.Categories = categories;
                return View(model);
            }

            await postsService.EditPostAsync(model);

            TempData["EditMessage"] = GlobalConstants.SuccessfulEdit;

            return RedirectToAction(nameof(Details), new { model.Id });
        }
    }
}
