namespace CarWorld.Web.ViewModels.Administration
{
    using System.ComponentModel.DataAnnotations;

    public class CreateMakeInputModel
    {
        [Required]
        [StringLength(100, MinimumLength = 1)]
        public string Name { get; set; }
    }
}
