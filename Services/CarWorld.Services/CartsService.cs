using CarWorld.Data.Common.Repositories;
using CarWorld.Data.Models;
using CarWorld.Services.Contracts;
using System.Threading.Tasks;

namespace CarWorld.Services
{
    public class CartsService : ICartsService
    {
        private readonly IRepository<Cart> cartsRepo;

        public CartsService(IRepository<Cart> cartsRepo)
        {
            this.cartsRepo = cartsRepo;
        }

        public async Task CreateAsync(string userId)
        {
            var cart = new Cart
            {
                UserId = userId,
            };

            await cartsRepo.AddAsync(cart);
            await cartsRepo.SaveChangesAsync();
        }
    }
}
