using System.Collections.Generic;

namespace CarWorld.Web.ViewModels.Cars
{
    public class SearchCarsListViewModel : PagingViewModel
    {
        public IEnumerable<SearchCarsInListViewModel> Cars { get; set; }      
    }
}
