using CarWorld.Data.Models;
using CarWorld.Services.Mapping;
using CarWorld.Web.Infrastructure.ValidationAttributes;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace CarWorld.Web.ViewModels.Administration.Categories
{
    public class CreateCategoryInputModel : IMapTo<Category>
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Display(Name = "Thumbnail Image")]
        [FileSizeAndFormat(4, "jpg", "png", "jpeg")]
        [Required]
        public IFormFile? Image { get; set; }
    }
}
