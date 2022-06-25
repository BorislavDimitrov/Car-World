using CarWorld.Web.ViewModels.Cars;
using CarWorld.Web.ViewModels.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace CarWorld.Web.ViewModels.Users
{
    public class ProfileViewModel : PagingViewModel
    {
        public IEnumerable<UserCarsInListViewModel> Cars { get; set; }

        public string UserName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public string ImagePath { get; set; }

        public string Email { get; set; }

        public string Search { get; set; }

        public int? MakeId { get; set; }

        public int? ModelId { get; set; }

        public int? RegionId { get; set; }

        public int CategoryId { get; set; }

        public string OrderBy { get; set; }

        public string UserId { get; set; }

        public List<SelectListItem> Makes { get; set; } = new List<SelectListItem>();

        public List<SelectListItem> Regions { get; set; } = new List<SelectListItem>();

        public List<ModelsDropDown> Models { get; set; } = new List<ModelsDropDown>();


    }
}
