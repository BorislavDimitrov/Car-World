using CarWorld.Data.Models;
using CarWorld.Services.Mapping;

namespace CarWorld.Web.ViewModels.Administration.Regions
{
    public class RegionsInListViewModel : IMapFrom<Region>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public bool IsDeleted { get; set; }
    }
}
