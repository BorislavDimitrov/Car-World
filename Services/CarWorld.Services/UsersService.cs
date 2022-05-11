namespace CarWorld.Services
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    using CarWorld.Data.Common.Repositories;
    using CarWorld.Data.Models;
    using CarWorld.Services.Contracts;
    using CarWorld.Services.Mapping;
    using CarWorld.Web.ViewModels.Administration.Users;
    using CarWorld.Web.ViewModels.Users;
    using Microsoft.EntityFrameworkCore;

    public class UsersService : IUsersService
    {
        private readonly IDeletableEntityRepository<ApplicationUser> userRepo;

        public UsersService(IDeletableEntityRepository<ApplicationUser> userRepo)
        {
            this.userRepo = userRepo;
        }

        public async Task DeleteAccountAsync(string userId)
        {
            var user = await userRepo.All()
                .FirstOrDefaultAsync(x => x.Id == userId);

            userRepo.Delete(user);

            await userRepo.SaveChangesAsync();
        }

        public async Task EditAccountAsync(string userId, EditUserInputModel editModel, string wwwrootPath)
        {
            var user = await userRepo.All()
                .FirstOrDefaultAsync(x => x.Id == userId);

            user.FirstName = editModel.FirstName;
            user.LastName = editModel.LastName;
            user.PhoneNumber = editModel.PhoneNumber;

            if (editModel.Image != null)
            {
                string imagePath = "/img/users/" + Guid.NewGuid().ToString() + ".jpeg";

                using (FileStream fs = new FileStream(wwwrootPath + imagePath, FileMode.Create))
                {
                    await editModel.Image.CopyToAsync(fs);
                }
                user.ImagePath = imagePath;
            }

            await userRepo.SaveChangesAsync();
        }

        public async Task<ApplicationUser> GetUserByIdAsync(string userId)
        {
            return await userRepo.AllWithDeleted()
                .FirstOrDefaultAsync(x => x.Id == userId);
        }

        public async Task<IEnumerable<UserInListViewModel>> GetUsersAsync()
        {
            return await userRepo.AllWithDeleted()
                .To<UserInListViewModel>()
                .ToListAsync();
        }

        public async Task<EditUserInputModel> GetUserSelfInfoAsync(string userId)
        {
             return await userRepo.AllAsNoTracking()
                .Where(x => x.Id == userId)
                .To<EditUserInputModel>()
                .FirstOrDefaultAsync();      
        }

        public async Task RecoverAccountAsync(string userId)
        {
            var user = await userRepo.AllWithDeleted()
                .FirstOrDefaultAsync(x => x.Id == userId);

            userRepo.Undelete(user);

            await userRepo.SaveChangesAsync();
        }
    }
}
