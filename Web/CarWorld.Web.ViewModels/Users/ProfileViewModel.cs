using CarWorld.Web.ViewModels.Cars;
using System.Collections.Generic;

namespace CarWorld.Web.ViewModels.Users
{
    public class ProfileViewModel : PagingViewModel
    {
        public string UserName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public string ImagePath { get; set; }

        public string Email { get; set; }

        public IEnumerable<UserCarsInListViewModel> Cars { get; set; }


    }
}
