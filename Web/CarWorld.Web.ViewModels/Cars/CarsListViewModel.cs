using System.Collections.Generic;

namespace CarWorld.Web.ViewModels.Cars
{
    public class CarsListViewModel : PagingViewModel
    {
        public IEnumerable<CarsInListViewModel> Cars { get; set; }      
    }
}
