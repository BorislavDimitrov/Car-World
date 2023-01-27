using CarWorld.Data.Common.Repositories;
using CarWorld.Data.Models;
using CarWorld.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CarWorld.Services
{
    public class CartsService : ICartsService
    {
        private readonly IRepository<Cart> cartsRepo;
        private readonly IRepository<Product> productsRepo;
        private readonly IRepository<Item> itemsRepo;

        public CartsService(IRepository<Cart> cartsRepo,
            IRepository<Product> productsRepo)
        {
            this.cartsRepo = cartsRepo;
            this.productsRepo = productsRepo;
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

        public async Task AddProductToCartAsync(int id, string userId, int quanity)
        {
            var cart = await cartsRepo.All()
                .FirstOrDefaultAsync(x => x.UserId == userId);

            var product = await productsRepo.All()
                .FirstOrDefaultAsync(x => x.Id == id);

            var item = await CreateItemAsync(product, cart.Id, quanity);

            cart.Items.Add(item);

            await cartsRepo.SaveChangesAsync();
        }

        private async Task<Item> CreateItemAsync(Product product, int cartId, int quanity)
        {
            var item = new Item
            {
                CartId = cartId,
                Product = product,
                ProductId = cartId,
                Quanity = quanity,
            };

            await itemsRepo.AddAsync(item);
            await itemsRepo.SaveChangesAsync();
            return item;
        }
    }
}
