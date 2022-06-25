using CarWorld.Web.ViewModels.Cars;
using System.Collections.Generic;

namespace CarWorld.Web.ViewModels.Administration.Regions
{
    public class RegionsListViewModel : PagingViewModel
    {
        public IEnumerable<RegionsInListViewModel> Regions { get; set; }

        public string Search { get; set; }

        public string OrderBy { get; set; }
    }
}
