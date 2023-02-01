using AutoMapper;
using CarWorld.Data.Common.Repositories;
using CarWorld.Data.Models;
using CarWorld.Services.Contracts;
using CarWorld.Services.Mapping;
using CarWorld.Web.ViewModels.Posts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarWorld.Services
{
    public class PostsService : IPostsService
    {
        private readonly IDeletableEntityRepository<Post> postsRepo;
        private readonly IMapper mapper;

        public PostsService(IDeletableEntityRepository<Post> postsRepo)
        {
            this.postsRepo = postsRepo;
            this.mapper = AutoMapperConfig.MapperInstance;
        }

        public async Task<int> CreatePostAsync(CreatePostInputModel model)
        {
            var newPost = mapper.Map<Post>(model);

            await postsRepo.AddAsync(newPost);

            await postsRepo.SaveChangesAsync();

            return newPost.Id;
        }

        public async Task<T> GetPostDetailsByIdAsync<T>(int postId)
        {
            return await postsRepo.AllWithDeleted()
                .Where(x => x.Id == postId)
                .To<T>()
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<T>> GetSearchPostsAsync<T>(string search, string orderBy, int categoryId)
        {
            var posts = postsRepo.All()
                .Where(x => x.CategoryId == categoryId)
                .AsQueryable();

            if (search != null)
            {
                posts = posts.Where(x => x.Title.Contains(search)).AsQueryable();
            }

            switch (orderBy)
            {
                case "DateAsc":
                    posts = posts.OrderBy(x => x.CreatedOn);
                    break;
                case "RateDesc":
                    posts = posts.OrderByDescending(x => x.Votes.Sum(x => (int)x.Type));
                    break;
                case "RateAsc":
                    posts = posts.OrderBy(x => x.Votes.Sum(x => (int)x.Type));
                    break;
                default:
                    posts = posts.OrderByDescending(x => x.CreatedOn);
                    break;
            }

            return await posts
                .To<T>()
                .ToListAsync();
        }

        public async Task<IEnumerable<T>> GetUserPostsAsync<T>(string userId, string search, string orderBy, int categoryId)
        {
            var posts = postsRepo.All()
                .Where(x => x.CreatorId == userId && x.CategoryId == categoryId)
                .AsQueryable();

            if (search != null)
            {
                posts = posts.Where(x => x.Title.Contains(search)).AsQueryable();
            }

            switch (orderBy)
            {
                case "DateAsc":
                    posts = posts.OrderBy(x => x.CreatedOn);
                    break;
                case "RateDesc":
                    posts = posts.OrderByDescending(x => x.Votes.Sum(x => (int)x.Type));
                    break;
                case "RateAsc":
                    posts = posts.OrderBy(x => x.Votes.Sum(x => (int)x.Type));
                    break;
                default:
                    posts = posts.OrderByDescending(x => x.CreatedOn);
                    break;
            }

            return await posts
                .To<T>()
                .ToListAsync();
        }

        public async Task<bool> IsPostExistingForUserByIdAsync(int id)
            => await postsRepo.All()
            .FirstOrDefaultAsync(x => x.Id == id) == null ? false : true;

        public async Task<bool> IsUserHavingPostsInCategoryAsync(string userId, int categoryId)
            => postsRepo.All()
            .Any(x => x.CreatorId == userId && x.CategoryId == categoryId);

        public async Task<bool> IsPostCreatedByUserAsync(string userId, int postId)
            => await postsRepo.All()
            .FirstOrDefaultAsync(x => x.CreatorId == userId && x.Id == postId) == null ? false : true;

        public async Task EditPostAsync(EditPostInputModel model)
        {
            var post = await postsRepo.All()
                .FirstOrDefaultAsync(x => x.Id == model.Id);

            post.CategoryId = model.CategoryId;
            post.Title = model.Title;
            post.Content = model.Content;

            await postsRepo.SaveChangesAsync();
        }

        public async Task DeletePostAsync(int postId)
        {
            var post = await postsRepo.All()
                .FirstOrDefaultAsync(x => x.Id == postId);

            postsRepo.Delete(post);

            await postsRepo.SaveChangesAsync();
        }
    }
}
