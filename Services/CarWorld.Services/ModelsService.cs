﻿namespace CarWorld.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using CarWorld.Data.Common.Repositories;
    using CarWorld.Data.Models;
    using CarWorld.Services.Contracts;
    using CarWorld.Services.Mapping;
    using CarWorld.Web.ViewModels.Administration.Models;
    using CarWorld.Web.ViewModels.Models;
    using Microsoft.EntityFrameworkCore;

    public class ModelsService : IModelsService
    {
        private readonly IDeletableEntityRepository<Model> modelsRepo;

        public ModelsService(IDeletableEntityRepository<Model> modelsRepo)
        {
            this.modelsRepo = modelsRepo;
        }

        public async Task CreateModelAsync(CreateModelModel model)
        {
            if (await IsModelExistingByNameAndMakeIdAsync(model.Name, model.MakeId))
            {
                throw new InvalidOperationException($"Model with the name {model.Name} of this make already exists.");
            }

            var newModel = new Model
            {
                Name = model.Name,
                MakeId = model.MakeId,
            };

            await modelsRepo.AddAsync(newModel);

            await modelsRepo.SaveChangesAsync();
        }

        public async Task DeleteModelAsync(int modelId)
        {
            var model = await modelsRepo.AllWithDeleted()
                 .SingleOrDefaultAsync(x => x.Id == modelId);

            modelsRepo.Delete(model);

            await modelsRepo.SaveChangesAsync();
        }

        public async Task EditModelAsync(EditModelInputModel model)
        {
            if (await IsModelExistingByNameAndMakeIdAsync(model.Name, model.MakeId))
            {
                throw new InvalidOperationException($"Model with the name {model.Name} of this make already exists.");
            }

            var modelToEdit = await modelsRepo.AllWithDeleted()
                .FirstOrDefaultAsync(x => x.Id == model.Id);

            modelToEdit.Name = model.Name;
            modelToEdit.MakeId = model.MakeId;

            await modelsRepo.SaveChangesAsync();
        }

        public async Task<T> GetModelByIdAsync<T>(int modelId)
        {
            return await modelsRepo.AllWithDeleted()
                .Where(x => x.Id == modelId)
                .To<T>()
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<ModelInListViewModel>> GetModelsAsync(string searchText, int makeId)
        {
            var models = await modelsRepo.AllWithDeleted()
                .OrderBy(x => x.Make.Name)
                .To<ModelInListViewModel>()
                .ToListAsync();

            if (searchText != null)
            {
                models = models.Where(x => x.Name.Contains(searchText)).ToList();
            }

            if (makeId > 0)
            {
                models = models.Where(x => x.MakeId == makeId).ToList();
            }

            return models;
        }

        public async Task<IEnumerable<ModelsDropDown>> GetModelsByMakeIdAsync(int makeId)
        {
            return await modelsRepo.AllAsNoTracking()
                .Where(x => x.MakeId == makeId)
                .To<ModelsDropDown>()
                .ToListAsync();
        }

        public async Task RecoverModelAsync(int modelId)
        {
            var model = await modelsRepo.AllWithDeleted()
                .FirstOrDefaultAsync(x => x.Id == modelId);

            modelsRepo.Undelete(model);

            await modelsRepo.SaveChangesAsync();
        }

        public async Task<bool> IsModelExistingByNameAndMakeIdAsync(string name, int makeId)
            => await modelsRepo.AllWithDeleted()
            .FirstOrDefaultAsync(x => x.Name == name && x.MakeId == makeId) == null ? false : true;

        public async Task<bool> IsModelExistingByIdAsync(int id)
            => await modelsRepo.AllWithDeleted()
            .FirstOrDefaultAsync(x => x.Id == id) == null ? false : true;

    }
}
