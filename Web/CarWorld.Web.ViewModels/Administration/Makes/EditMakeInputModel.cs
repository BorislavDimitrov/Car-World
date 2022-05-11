using CarWorld.Data.Models;
using CarWorld.Services.Mapping;
using System.ComponentModel.DataAnnotations;

namespace CarWorld.Web.ViewModels.Administration.Makes
{
    public class EditMakeInputModel : IMapFrom<Make>
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 1)]
        [Display(Name = "Name")]
        public string Name { get; set; }
    }
}
