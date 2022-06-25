﻿using AutoMapper;
using CarWorld.Data.Common.Repositories;
using CarWorld.Data.Models;
using CarWorld.Services.Contracts;
using CarWorld.Services.Mapping;
using CarWorld.Web.ViewModels.Cars;
using CarWorld.Web.ViewModels.Posts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public async Task<DetailsPostViewModel> GetPostDetailsByIdAsync(int carId)
        {
            return await postsRepo.AllWithDeleted()
                .Where(x => x.Id == carId)
                .To<DetailsPostViewModel>()
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

        public async Task<bool> IsPostExistingForUserByIdAsync(int id)
            => await postsRepo.All()
            .FirstOrDefaultAsync(x => x.Id == id) == null ? false : true;
    }
}
