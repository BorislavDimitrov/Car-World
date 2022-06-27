using System.Collections.Generic;

namespace CarWorld.Web.ViewModels.Administration.Categories
{
    public class CategoriesForAdminListViewModel
    {
        public IEnumerable<CategoriesForAdminInListViewModel> Categories { get; set; }
    }
}
