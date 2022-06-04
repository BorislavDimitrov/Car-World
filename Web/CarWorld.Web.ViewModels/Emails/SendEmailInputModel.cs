using System.ComponentModel.DataAnnotations;

namespace CarWorld.Web.ViewModels.Emails
{
    public class SendEmailInputModel
    {
        public string SenderEmail { get; set; }

        public string RecieverEmail { get; set; }

        public string SenderUsername { get; set; }

        [Required]
        [StringLength(50)]
        public string Subject { get; set; }

        [Required]
        [StringLength(500)]
        public string Content { get; set; }
    }
}
