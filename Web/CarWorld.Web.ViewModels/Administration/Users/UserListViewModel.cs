using CarWorld.Web.ViewModels.Cars;
using System.Collections.Generic;

namespace CarWorld.Web.ViewModels.Administration.Users
{
    public class UserListViewModel : PagingViewModel
    {
        public IEnumerable<UserInListViewModel> Users { get; set; }

        public string Search { get; set; }

        public string OrderBy { get; set; }
    }
}
