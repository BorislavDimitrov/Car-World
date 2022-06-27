using CarWorld.Data.Models;
using CarWorld.Services.Mapping;

namespace CarWorld.Web.ViewModels.Administration.Categories
{
    public class CategoriesForAdminInListViewModel : IMapFrom<Category>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string ImagePath { get; set; }

        public int PostsCount { get; set; }

        public bool IsDeleted { get; set; }
    }
}
