namespace CarWorld.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
    using CarWorld.Data.Common.Repositories;
    using CarWorld.Data.Models;
    using CarWorld.Services.Contracts;
    using CarWorld.Services.Mapping;
    using CarWorld.Web.ViewModels.Administration.Regions;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.EntityFrameworkCore;

    public class RegionsService : IRegionsService
    {
        private readonly IDeletableEntityRepository<Region> regionsRepo;
        private readonly IMapper mapper;
        public RegionsService(IDeletableEntityRepository<Region> regionsRepo)
        {
            this.regionsRepo = regionsRepo;
            this.mapper = AutoMapperConfig.MapperInstance;
        }

        public async Task CreateRegionAsync(CreateRegionInputModel model)
        {
            if (await IsRegionExistingByNameAsync(model.Name))
            {
                throw new InvalidOperationException($"Region with the name {model.Name} already exists.");
            }

            var newRegion = mapper.Map<Region>(model);

            await regionsRepo.AddAsync(newRegion);

            await regionsRepo.SaveChangesAsync();
        }

        public async Task DeleteRegionAsync(int regionId)
        {
            var region = await regionsRepo.AllWithDeleted()
                .FirstOrDefaultAsync(x => x.Id == regionId);

            if (region == null)
            {
                throw new InvalidOperationException("The region doesnt exist.");
            }

            regionsRepo.Delete(region);

            await regionsRepo.SaveChangesAsync();
        }

        public async Task EditRegionAsync(EditRegionInputModel model)
        {
            var region = await regionsRepo.AllWithDeleted()
                .FirstOrDefaultAsync(x => x.Id == model.Id);

            if (await IsRegionExistingByNameAsync(model.Name))
            {
                throw new InvalidOperationException($"Region with the name {model.Name} already exists.");
            }

            region.Name = model.Name;

            await regionsRepo.SaveChangesAsync();
        }

        public async Task<T> GetRegionByIdAsync<T>(int regionId)
        {
            return await regionsRepo.AllWithDeleted()
                .Where(x => x.Id == regionId)
                .To<T>()
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<SelectListItem>> GetExistingRegionsAsync()
        {
            return await regionsRepo.AllAsNoTracking()
                .Select(x => new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = x.Name,
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<T>> GetRegionsAsync<T>(string search, string orderBy)
        {
            var regions = regionsRepo.AllWithDeleted()
                .AsQueryable();

            if (search != null)
            {
                regions = regions.Where(x => x.Name.Contains(search)).AsQueryable();
            }

            switch (orderBy)
            {
                case "NameDesc":
                    regions = regions.OrderByDescending(x => x.Name);
                    break;
                default:
                    regions = regions.OrderBy(x => x.Name);
                    break;
            }

            return await regions.To<T>()
                .ToListAsync();
        }

        public async Task RecoverRegionAsync(int regionId)
        {
            var region = await regionsRepo.AllWithDeleted()
                .FirstOrDefaultAsync(x => x.Id == regionId);

            regionsRepo.Undelete(region);

            await regionsRepo.SaveChangesAsync();
        }

        public async Task<bool> IsRegionExistingByNameAsync(string name)
            => await regionsRepo.AllWithDeleted()
            .FirstOrDefaultAsync(x => x.Name == name) == null ? false : true;

        public async Task<bool> IsRegionExistingByIdAsync(int id)
            => await regionsRepo.AllWithDeleted()
            .FirstOrDefaultAsync(x => x.Id == id) == null ? false : true;
    }
}
