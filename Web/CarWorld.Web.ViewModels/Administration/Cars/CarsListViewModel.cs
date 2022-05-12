using CarWorld.Web.ViewModels.Cars;
using System.Collections.Generic;

namespace CarWorld.Web.ViewModels.Administration.Cars
{
    public class CarsListViewModel : PagingViewModel
    {
        public IEnumerable<CarsForAdminInListViewModel> Cars { get; set; }
    }
}
