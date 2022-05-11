namespace CarWorld.Web.ViewModels.Administration
{
    using CarWorld.Data.Models;
    using CarWorld.Services.Mapping;

    public class MakeInListViewModel : IMapFrom<Make>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public bool IsDeleted { get; set; }
    }
}
