using CarWorld.Web.ViewModels.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace CarWorld.Web.ViewModels.Cars
{
    public class CarsListViewModel : PagingViewModel
    {
        public IEnumerable<CarsInListViewModel> Cars { get; set; }

        public string Search { get; set; }

        public string OrderBy { get; set; }

        public int? MakeId { get; set; }

        public int? ModelId { get; set; }

        public int? RegionId { get; set; }

        public List<SelectListItem> Makes { get; set; } = new List<SelectListItem>();

        public List<SelectListItem> Regions { get; set; } = new List<SelectListItem>();

        public List<ModelsDropDown> Models { get; set; } = new List<ModelsDropDown>();
    }
}
