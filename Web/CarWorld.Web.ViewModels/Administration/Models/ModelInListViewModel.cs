using CarWorld.Data.Models;
using CarWorld.Services.Mapping;

namespace CarWorld.Web.ViewModels.Administration.Models
{
    public class ModelInListViewModel : IMapFrom<Model>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string MakeName { get; set; }

        public bool IsDeleted { get; set; }

        public int MakeId { get; set; }
    }
}
