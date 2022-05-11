namespace CarWorld.Web.ViewModels.Administration.Users
{
    using System.ComponentModel.DataAnnotations;

    public class CreateRoleModel
    {
        [Required]
        public string Name { get; set; }
    }
}
