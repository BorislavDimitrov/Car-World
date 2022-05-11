namespace CarWorld.Web.ViewModels.Administration.Regions
{
    using System.ComponentModel.DataAnnotations;

    using CarWorld.Data.Models;
    using CarWorld.Services.Mapping;

    public class EditRegionInputModel : IMapFrom<Region>
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 1)]
        public string Name { get; set; }
    }
}
