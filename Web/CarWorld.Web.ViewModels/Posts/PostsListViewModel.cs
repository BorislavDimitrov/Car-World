using AutoMapper;
using CarWorld.Data.Models;
using CarWorld.Services.Mapping;
using CarWorld.Web.ViewModels.Cars;
using System.Collections.Generic;

namespace CarWorld.Web.ViewModels.Posts
{
    public class PostsListViewModel : PagingViewModel, IMapFrom<Category>, IHaveCustomMappings
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string ImagePath { get; set; }

        public string Search { get; set; }

        public string OrderBy { get; set; }

        public int CategoryId { get; set; }

        public IEnumerable<PostInListViewModel> CategoryPosts { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Category, PostsListViewModel>()
                .ForMember(x => x.CategoryId, options =>
                {
                    options.MapFrom(x => x.Id);
                });
        }
    }
}
