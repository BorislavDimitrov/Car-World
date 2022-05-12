namespace CarWorld.Web.ViewModels.Administration.Regions
{
    using CarWorld.Data.Models;
    using CarWorld.Services.Mapping;
    using System.ComponentModel.DataAnnotations;

    public class CreateRegionInputModel : IMapTo<Region>
    {
        [Required]
        [StringLength(100, MinimumLength = 1)]
        public string Name { get; set; }
    }
}
