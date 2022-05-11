using CarWorld.Web.ViewModels.Administration.Models;
using CarWorld.Web.ViewModels.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarWorld.Services.Contracts
{
    public interface IModelsService
    {
        Task<IEnumerable<ModelsDropDown>> GetModelsByMakeIdAsync(int makeId);

        Task<IEnumerable<ModelInListViewModel>> GetModelsAsync(string searchText, int makeId);

        Task CreateModelAsync(CreateModelModel model);

        Task<T> GetModelByIdAsync<T>(int modelId);

        Task EditModelAsync(EditModelInputModel model);

        Task DeleteModelAsync(int modelId);

        Task RecoverModelAsync(int modelId);

        Task<bool> IsModelExistingByNameAndMakeIdAsync(string name, int makeId);

        Task<bool> IsModelExistingByIdAsync(int id);
    }
}
