using CarWorld.Web.ViewModels.Cars;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace CarWorld.Web.ViewModels.Administration.Models
{
    public class ModelListViewModel : PagingViewModel
    {
        public IEnumerable<ModelInListViewModel> Models { get; set; }

        public List<SelectListItem> Makes { get; set; } = new List<SelectListItem>();

        public int? MakeId { get; set; }
    }
}
