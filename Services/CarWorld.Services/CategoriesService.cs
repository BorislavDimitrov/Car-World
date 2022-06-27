using AutoMapper;
using CarWorld.Data.Common.Repositories;
using CarWorld.Data.Models;
using CarWorld.Services.Contracts;
using CarWorld.Services.Mapping;
using CarWorld.Web.ViewModels.Administration.Categories;
using CarWorld.Web.ViewModels.Categories;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CarWorld.Services
{
    public class CategoriesService : ICategoriesService
    {
        private readonly IDeletableEntityRepository<Category> categoriesRepo;
        private readonly IMapper mapper;

        public CategoriesService(IDeletableEntityRepository<Category> categoriesRepo)
        {
            this.categoriesRepo = categoriesRepo;
            this.mapper = AutoMapperConfig.MapperInstance;
        }

        public async Task CreateCategoryAsync(CreateCategoryInputModel model, string wwwrootPath)
        {
            if (await IsCategoryExistingByNameAsync(model.Name))
            {
                throw new InvalidOperationException($"Category with the name {model.Name} already exists.");
            }

            var category = mapper.Map<Category>(model);

            var guid = Guid.NewGuid().ToString();

            var imagePath = "/img/categories/" + guid + ".png";

            using (FileStream fs = new FileStream(
                wwwrootPath + imagePath, FileMode.Create))
            {
                await model.Image.CopyToAsync(fs);
            }

            category.ImagePath = imagePath;

            await categoriesRepo.AddAsync(category);
            await categoriesRepo.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAllCategoriesAsync<T>()
        {
            return await categoriesRepo.All()
                .To<T>()
                .ToListAsync();
        }

        public async Task<IEnumerable<UserCategoriesInListViewModel>> GetCategoriesByUserIdAsync(string userId)
        {
            return await categoriesRepo.All()
                .Where(x => x.Posts.Any(p => p.CreatorId == userId))
                .Select(x => new UserCategoriesInListViewModel
                {
                    Description = x.Description,
                    Id = x.Id,
                    ImagePath = x.ImagePath,
                    Name = x.Name,
                    PostsCount = x.Posts.Where(x => x.CreatorId == userId).Count(),
                })
                .ToListAsync();
        }

        public async Task<T> GetCategoryByIdAsync<T>(int categoryId)
        {
            return await categoriesRepo.All()
                .Where(x => x.Id == categoryId)
                .To<T>()
                .FirstOrDefaultAsync();
        }

        public async Task<T> GetCategoryForAdminAsync<T>(int categoryId)
        {
            return await categoriesRepo.AllWithDeleted()
                .Where(x => x.Id == categoryId)
                .To<T>()
                .FirstOrDefaultAsync();
        }

        public async Task<List<SelectListItem>> GetExistingCategoriesAsSelectListItemAsync()
        {
            return await categoriesRepo.AllAsNoTracking()
                .Select(x => new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = x.Name,
                })
                .ToListAsync();
        }

        public async Task<bool> IsCategoryExistingForUserByIdAsync(int categoryId)
        {
            return await categoriesRepo.All()
                .FirstOrDefaultAsync(x => x.Id == categoryId) != null ? true : false;
        }

        public async Task<bool> IsCategoryExistingForAdminByIdAsync(int categoryId)
        {
            return await categoriesRepo.AllWithDeleted()
                .FirstOrDefaultAsync(x => x.Id == categoryId) != null ? true : false;
        }

        public async Task<bool> IsCategoryExistingByNameAsync(string categoryName)
            => await categoriesRepo.AllWithDeleted()
            .FirstOrDefaultAsync(x => x.Name == categoryName) == null ? false : true;

        public async Task DeleteMakeAsync(int id)
        {
            var category = await categoriesRepo.AllWithDeleted()
                .FirstOrDefaultAsync(x => x.Id == id);

             categoriesRepo.Delete(category);

            await categoriesRepo.SaveChangesAsync();
        }

        public async Task RecoverCategoryAsync(int id)
        {
            var category = await categoriesRepo.AllWithDeleted()
                .FirstOrDefaultAsync(x => x.Id == id);

            categoriesRepo.Undelete(category);

            await categoriesRepo.SaveChangesAsync();
        }

        public async Task EditCategoryAsync(EditCategoryInputModel model, string wwwrootPath)
        {
            if (await IsCategoryExistingByNameAsync(model.Name) && model.Image == null)
            {
                throw new InvalidOperationException($"Category with the name {model.Name} already exists.");
            }

            var category = await categoriesRepo.AllWithDeleted()
                .FirstOrDefaultAsync(x => x.Id == model.Id);

            category.Name = model.Name;
            category.Description = model.Description;

            if (model.Image != null)
            {
                var guid = Guid.NewGuid().ToString();

                var imagePath = "/img/categories/" + guid + ".png";

                using (FileStream fs = new FileStream(
                    wwwrootPath + imagePath, FileMode.Create))
                {
                    await model.Image.CopyToAsync(fs);
                }

                category.ImagePath = imagePath;
            }

            await categoriesRepo.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAllCategoriesForAdminAsync<T>()
        {
            return await categoriesRepo.AllWithDeleted()
               .To<T>()
               .ToListAsync();
        }
    }
}
