namespace CarWorld.Web.ViewModels.Administration.Regions
{
    using System.ComponentModel.DataAnnotations;

    public class CreateRegionInputModel
    {
        [Required]
        [StringLength(100, MinimumLength = 1)]
        public string Name { get; set; }
    }
}
