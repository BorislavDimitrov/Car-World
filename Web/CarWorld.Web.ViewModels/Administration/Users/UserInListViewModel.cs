namespace CarWorld.Web.ViewModels.Administration.Users
{
    using CarWorld.Data.Models;
    using CarWorld.Services.Mapping;

    public class UserInListViewModel : IMapFrom<ApplicationUser>
    {
        public string Id { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public bool IsDeleted { get; set; }
    }
}
