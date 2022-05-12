namespace CarWorld.Services
{
    using AutoMapper;
    using CarWorld.Data.Common.Repositories;
    using CarWorld.Data.Models;
    using CarWorld.Services.Contracts;
    using CarWorld.Services.Mapping;
    using CarWorld.Web.ViewModels.Administration;
    using CarWorld.Web.ViewModels.Administration.Makes;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class MakesService : IMakesService
    {
        private readonly IDeletableEntityRepository<Make> makeRepo;
        private readonly IMapper mapper;
        public MakesService(IDeletableEntityRepository<Make> makeRepo)
        {
            this.makeRepo = makeRepo;
            this.mapper = AutoMapperConfig.MapperInstance;
        }

        public async Task CreateMakeAsync(CreateMakeInputModel model)
        {

            if (await IsMakeExistingByNameAsync(model.Name))
            {
                throw new InvalidOperationException($"Make with the name {model.Name} already exists.");
            }

            var newMake = new Make()
            {
                Name = model.Name,
            };

            await makeRepo.AddAsync(newMake);

            await makeRepo.SaveChangesAsync();
        }

        public async Task DeleteMakeAsync(int makeId)
        {
            var make = await makeRepo.AllWithDeleted()
                .FirstOrDefaultAsync(x => x.Id == makeId);

            makeRepo.Delete(make);

            await makeRepo.SaveChangesAsync();
        }

        public async Task EditMakeAsync(EditMakeInputModel model)
        {

            if (await IsMakeExistingByNameAsync(model.Name))
            {
                throw new InvalidOperationException($"Make with the name {model.Name} already exists.");
            }

            var make = await makeRepo.AllWithDeleted()
                .FirstOrDefaultAsync(x => x.Id == model.Id);

            make.Name = model.Name;

            await makeRepo.SaveChangesAsync();
        }

        public async Task<T> GetMakeByIdAsync<T>(int makeId)
        {
            return await makeRepo.AllWithDeleted()
                .Where(x => x.Id == makeId)
                .To<T>()
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<SelectListItem>> GetExistingMakesAsSelectListItemAsync()
        {
            return await makeRepo.AllAsNoTracking()
                .Select(x => new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = x.Name,
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<MakeInListViewModel>> GetMakesAsync(string searchText)
        {
            var makes = await makeRepo.AllWithDeleted()
                .OrderBy(x => x.Name)
                .To<MakeInListViewModel>()
                .ToListAsync();

            if (searchText != null)
            {
                makes = makes.Where(x => x.Name.Contains(searchText)).ToList();
            }

            return makes;
        }

        public async Task RecoverMakeAsync(int makeId)
        {
            var make = await makeRepo.AllWithDeleted()
                .FirstOrDefaultAsync(x => x.Id == makeId);

            makeRepo.Undelete(make);

            await makeRepo.SaveChangesAsync();
        }

        public async Task<bool> IsMakeExistingByNameAsync(string name)
            => await makeRepo.AllWithDeleted()
            .FirstOrDefaultAsync(x => x.Name == name) == null ? false : true;
         
        public async Task<bool> IsMakeExistingByIdAsync(int id)
            => await makeRepo.AllWithDeleted()
            .FirstOrDefaultAsync(x => x.Id == id) == null ? false : true;

        public async Task<List<SelectListItem>> GetMakesAsSelectListItemAsync()
        {
            return await makeRepo.AllAsNoTrackingWithDeleted()
                .Select(x => new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = x.Name,
                })
                .ToListAsync();
        }
    }
}
