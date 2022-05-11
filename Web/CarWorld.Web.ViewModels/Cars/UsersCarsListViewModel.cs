using System.Collections.Generic;

namespace CarWorld.Web.ViewModels.Cars
{
    public class UsersCarsListViewModel : PagingViewModel
    {
        public IEnumerable<UserCarsInListViewModel> Cars { get; set; }
    }
}
