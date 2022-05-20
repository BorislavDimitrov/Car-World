using CarWorld.Web.ViewModels.Cars;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarWorld.Services.Contracts
{
    public interface ICarsService
    {
        Task CreateCarAsync(CreateCarInputModel model, string wwwrootPath);

        Task<IEnumerable<T>> GetUserCarsAsync<T>(string userId, string search, int? makeId, int? modelId, int? regionId, string orderBy);

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
