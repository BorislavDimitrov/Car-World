// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using CarWorld.Data;
using CarWorld.Data.Models;
using CarWorld.Services.Messaging;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace CarWorld.Web.Areas.Identity.Pages.Account.Manage
{
    public class EmailModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IEmailSender emailSender;
        private readonly ApplicationDbContext repo;

        public EmailModel(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IEmailSender emailSender,
            ApplicationDbContext repo)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            this.emailSender = emailSender;
            this.repo = repo;
        }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public bool IsEmailConfirmed { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [TempData]
        public string StatusMessage { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [BindProperty]
        public InputModel Input { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public class InputModel
        {
            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
            [Required]
            [EmailAddress]
            [Display(Name = "New email")]
            public string NewEmail { get; set; }
        }

        private async Task LoadAsync(ApplicationUser user)
        {
            var email = await _userManager.GetEmailAsync(user);
            Email = email;

            Input = new InputModel
            {
                NewEmail = email,
            };

            IsEmailConfirmed = await _userManager.IsEmailConfirmedAsync(user);
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            await LoadAsync(user);
            return Page();
        }

        public async Task<IActionResult> OnPostChangeEmailAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                return Page();
            }

            var email = await _userManager.GetEmailAsync(user);
            if (Input.NewEmail != email)
            {
                var userWithNewEmail = repo.Users
               .FirstOrDefault(u => u.Email == Input.NewEmail);

                if (userWithNewEmail != null)
                {
                    StatusMessage = "The email is already used.";
                    return RedirectToPage();
                }

                var userId = await _userManager.GetUserIdAsync(user);
                var token = await _userManager.GenerateChangeEmailTokenAsync(user, Input.NewEmail);
                token = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(token));

                var confirmationLink = Url.Action("ConfirmEmailChange", "Users", new { Area = "", userId = user.Id, token = token, oldEmail = email, newEmail = Input.NewEmail }, Request.Scheme);

                await emailSender.SendEmailAsync("bdimitorv@gmail.com", "Admin", Input.NewEmail, "Email change confirmation", $"Confirm your new email in Car World by clicking this link <a href=\"{confirmationLink}\"> Confirm email</a>");

                StatusMessage = "Confirmation link to change email sent. Please check your email.";
                return RedirectToPage();
            }

            StatusMessage = "Your email is unchanged.";
            return RedirectToPage();
        }

    }
}
