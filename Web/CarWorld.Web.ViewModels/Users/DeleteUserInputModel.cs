using System.ComponentModel.DataAnnotations;

namespace CarWorld.Web.ViewModels.Users
{
    public class DeleteUserInputModel
    {
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
