using CarWorld.Common;
using CarWorld.Data.Models;
using CarWorld.Services.Messaging;
using CarWorld.Web.ViewModels.Emails;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CarWorld.Web.Controllers
{
    public class EmailsController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IEmailSender emailSender;

        public EmailsController(UserManager<ApplicationUser> userManager,
            IEmailSender emailSender)
        {
            this.userManager = userManager;
            this.emailSender = emailSender;
        }

        [HttpGet]
        public async Task<IActionResult> SendEmailToUser(string id)
        {
            var senderEmail = User.FindFirstValue(ClaimTypes.Email);
            var senderUsername = User.FindFirstValue(ClaimTypes.Name);

            var reciever = await userManager.FindByIdAsync(id);

            if (reciever == null)
            {
                TempData["ErrorMessage"] = GlobalConstants.RedirectToHomepageAlertMessage;
                return Redirect("/Home/Index");
            }

            var recieverEmail = reciever.Email;

            var model = new SendEmailInputModel
            {
                SenderEmail = senderEmail,
                SenderUsername = senderUsername,
                RecieverEmail = recieverEmail
            };

            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> SendEmailToUser(SendEmailInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await emailSender.SendEmailAsync(model.SenderEmail, model.SenderUsername, model.RecieverEmail, model.Subject, model.Content);

            return Redirect("/Home/Index");
        }
    }
}
