﻿namespace CarWorld.Services.Contracts
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using CarWorld.Web.ViewModels.Administration.Regions;
    using Microsoft.AspNetCore.Mvc.Rendering;

    public interface IRegionsService
    {
        Task<List<SelectListItem>> GetExistingRegionsAsSelectItemListAsync();

        Task<List<SelectListItem>> GetRegionsForAdminAsSelectItemListAsync();

        Task<IEnumerable<T>> GetRegionsAsync<T>(string search, string orderBy);

        Task CreateRegionAsync(CreateRegionInputModel model);

        Task DeleteRegionAsync(int regionId);

        Task RecoverRegionAsync(int regionId);

        Task<T> GetRegionByIdAsync<T>(int regionId);

        Task EditRegionAsync(EditRegionInputModel model);

        Task<bool> IsRegionExistingByNameAsync(string name);

        Task<bool> IsRegionExistingByIdAsync(int id);
    }
}
