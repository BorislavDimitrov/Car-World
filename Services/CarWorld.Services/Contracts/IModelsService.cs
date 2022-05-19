using CarWorld.Web.ViewModels.Administration.Models;
using CarWorld.Web.ViewModels.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarWorld.Services.Contracts
{
    public interface IModelsService
    {
        Task<List<ModelsDropDown>> GetModelsForDropdownByMakeIdAsync(int? makeId);

        Task<List<ModelsDropDown>> GetModelsByMakeIdForAdminAsync(int? makeId);

        Task<List<T>> GetModelsAsync<T>(string search, int? MakeId);

        Task CreateModelAsync(CreateModelModel model);

        Task<T> GetModelByIdAsync<T>(int modelId);

        Task EditModelAsync(EditModelInputModel model);

        Task DeleteModelAsync(int modelId);

        Task RecoverModelAsync(int modelId);

        Task<bool> IsModelExistingByNameAndMakeIdAsync(string name, int makeId);

        Task<bool> IsModelExistingByIdAsync(int id);
    }
}
