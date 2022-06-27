using CarWorld.Data.Models;
using CarWorld.Services.Mapping;
using CarWorld.Web.Infrastructure.ValidationAttributes;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace CarWorld.Web.ViewModels.Administration.Categories
{
    public class EditCategoryInputModel : IMapFrom<Category>
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Display(Name = "Thumbnail Image")]
        [FileSizeAndFormat(4, "jpg", "png", "jpeg")]
        public IFormFile? Image { get; set; }
    }
}
