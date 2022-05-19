using CarWorld.Web.ViewModels.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace CarWorld.Web.ViewModels.Cars
{
    public class SearchCarsListViewModel : PagingViewModel
    {
        public IEnumerable<SearchCarsInListViewModel> Cars { get; set; }
        public List<SelectListItem> Makes { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> Regions { get; set; } = new List<SelectListItem>();
        public List<ModelsDropDown> Models { get; set; } = new List<ModelsDropDown>();
    }
}
