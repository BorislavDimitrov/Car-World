﻿namespace CarWorld.Services.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using CarWorld.Data.Models;
    using CarWorld.Web.ViewModels.Administration.Users;
    using CarWorld.Web.ViewModels.Users;

    public interface IUsersService
    {
        Task<EditUserInputModel> GetUserSelfInfoAsync(string userId);

        Task<ApplicationUser> GetUserByIdAsync(string userId);

        Task DeleteAccountAsync(string userId);

        Task EditAccountAsync(string userId, EditUserInputModel editModel, string wwwrootPath);

        Task<IEnumerable<T>> GetUsersAsync<T>(string searchText, string orderBy);

        Task RecoverAccountAsync(string userId);
    }
}
