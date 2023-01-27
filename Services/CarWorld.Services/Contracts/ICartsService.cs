using System.Threading.Tasks;

namespace CarWorld.Services.Contracts
{
    public interface ICartsService
    {
        Task CreateAsync(string userId);

        Task AddProductToCartAsync(int id, string userId, int quanity);
    }
}
