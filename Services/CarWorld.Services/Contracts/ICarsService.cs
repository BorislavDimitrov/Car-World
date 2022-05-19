using CarWorld.Data.Models;
using CarWorld.Web.ViewModels.Administration.Cars;
using CarWorld.Web.ViewModels.Cars;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarWorld.Services.Contracts
{
    public interface ICarsService
    {
        Task CreateCarAsync(CreateCarInputModel model, string wwwrootPath);

        Task<IEnumerable<UserCarsInListViewModel>> GetUserCarsAsync(string userId);

        Task<T> GetCarByIdAsync<T>(int carId);

        Task EditCarAsync(EditCarInputModel model, string wwwrootPath);

        Task DeleteCarAsync(int carId);

        Task<DetailsCarViewModel> GetCarDetails(int carId);

        Task<IEnumerable<T>> GetCarsForAdminAsync<T>(string search, int? makeId, int? modelId, int? regionId, string orderBy);

        Task<IEnumerable<T>> GetSearchCarsAsync<T>(string search, int? makeId, int? modelId, int? regionId, string orderBy);

        Task<bool> IsCarExistingForUserByIdAsync(int carId);

        Task<bool> IsCarExistingForAdminByIdAsync(int carId);

        Task<bool> IsCarMadeByUserAsync(int carId, string userId);  
    }
}
