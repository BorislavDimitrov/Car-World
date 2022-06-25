using CarWorld.Data.Common.Repositories;
using CarWorld.Data.Models;
using CarWorld.Services.Contracts;
using CarWorld.Services.Mapping;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarWorld.Services
{
    public class CategoriesService : ICategoriesService
    {
        private readonly IDeletableEntityRepository<Category> categoriesRepo;

        public CategoriesService(IDeletableEntityRepository<Category> categoriesRepo)
        {
            this.categoriesRepo = categoriesRepo;
        }

        public async Task<IEnumerable<T>> GetAllCategoriesAsync<T>()
        {
            return await categoriesRepo.All()
                .To<T>()
                .ToListAsync();
        }

        public async Task<T> GetCategoryById<T>(int categoryId)
        {
            return await categoriesRepo.All()
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

        public async Task<bool> IsCategoryExistingByIdAsync(int categoryId)
        {
            return await categoriesRepo.All()
                .FirstOrDefaultAsync(x => x.Id == categoryId) != null ? true : false;
        }
    }
}
