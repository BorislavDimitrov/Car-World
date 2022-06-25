using System.Collections.Generic;

namespace CarWorld.Web.ViewModels.Categories
{
    public class UserCategoriesListViewModel
    {
        public IEnumerable<UserCategoriesInListViewModel> Categories { get; set; }
    }
}
