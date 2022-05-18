namespace CarWorld.Services.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using CarWorld.Web.ViewModels.Administration;
    using CarWorld.Web.ViewModels.Administration.Makes;
    using Microsoft.AspNetCore.Mvc.Rendering;

    public interface IMakesService
    {
        Task<IEnumerable<SelectListItem>> GetExistingMakesAsSelectListItemAsync();

        Task DeleteMakeAsync(int makeId);

        Task CreateMakeAsync(CreateMakeInputModel model);

        Task<IEnumerable<T>> GetMakesAsync<T>(string search, string orderBy);

        Task RecoverMakeAsync(int makeId);

        Task EditMakeAsync(EditMakeInputModel model);

        Task<List<SelectListItem>> GetMakesAsSelectListItemAsync();

        Task<T> GetMakeByIdAsync<T>(int makeId);

        Task<bool> IsMakeExistingByNameAsync(string name);

        Task<bool> IsMakeExistingByIdAsync(int makeId);
    }
}
