﻿using CarWorld.Web.ViewModels.Posts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorld.Services.Contracts
{
    public interface IPostsService
    {
        Task<int> CreatePostAsync(CreatePostInputModel model);

        Task<bool> IsPostExistingForUserByIdAsync(int id);

        Task<DetailsPostViewModel> GetPostDetailsByIdAsync(int id);
    }
}
