namespace CarWorld.Web.ViewModels.Users
{
    using System.ComponentModel.DataAnnotations;
    using CarWorld.Data.Models;
    using CarWorld.Services.Mapping;
    using CarWorld.Web.Infrastructure.ValidationAttributes;
    using Microsoft.AspNetCore.Http;

    public class EditUserInputModel : IMapFrom<ApplicationUser>
    {
        [RegularExpression("[A-Z][a-z]*", ErrorMessage = "Name should start with upper letter")]
        [Display(Name = "First Name")]
        [StringLength(30, MinimumLength = 1, ErrorMessage = "Name can be long between 1 and 30 letters")]
        public string? FirstName { get; set; }

        [RegularExpression("[A-Z][a-z]*", ErrorMessage = "Name should start with upper letter")]
        [Display(Name = "Last Name")]
        [StringLength(30, MinimumLength = 1, ErrorMessage = "Name can be long between 1 and 30 letters")]
        public string? LastName { get; set; }

        [Range(0,1)]
        [FileSizeAndFormat(4, "jpg", "png", "jpeg")]
        [Display(Name = "User Image")]
        public IFormFile? Image { get; set; }

        [Phone(ErrorMessage = "Invalid phone number")]
        [Display(Name = "Phone Number")]
        public string? PhoneNumber { get; set; }

        public string ImagePath { get; set; }
    }
}
