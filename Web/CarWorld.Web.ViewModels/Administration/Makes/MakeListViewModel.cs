namespace CarWorld.Web.ViewMod.els.Administration.Makes
{
    using System.Collections.Generic;

    using CarWorld.Web.ViewModels.Administration;
    using CarWorld.Web.ViewModels.Cars;

    public class MakeListViewModel : PagingViewModel
    {
        public IEnumerable<MakeInListViewModel> Makes { get; set; }
    }
}
