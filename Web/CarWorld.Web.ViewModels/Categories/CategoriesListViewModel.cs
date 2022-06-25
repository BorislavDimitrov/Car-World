using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorld.Web.ViewModels.Categories
{
    public class CategoriesListViewModel
    {
        public IEnumerable<CategoriesInListViewModel> Categories { get; set; }
    }
}
