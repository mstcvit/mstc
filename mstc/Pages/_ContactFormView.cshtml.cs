using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace mstc.Pages
{
    public class _ContactFormViewModel : PageModel
    {
        [BindProperty]
        public ContactFormModel Contact { get; set; }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var mailbody = $@"
            This is a new contact request from your website:

            Name: {Contact.Name}
            Email: {Contact.Email}
            Message: ""{Contact.Message}""


            Regards,
            The Architect";

            SendMail(mailbody);

            return Page();
        }

        private void SendMail(string mailbody)
        {
            using (var message = new MailMessage(Contact.Email, "mstcvit@outlook.com"))
            {
                message.To.Add(new MailAddress("mstcvit@outlook.com"));
                message.From = new MailAddress(Contact.Email);
                message.Subject = "MSTC - Contact Form";
                message.Body = mailbody;

                using (var smtpClient = new SmtpClient("smtp-mail.outlook.com"))
                {
                    smtpClient.Send(message);
                }
            }
        }
    }

    //public class ContactFormModel

    //{
    //    [Required]
    //    public string Name { get; set; }

    //    [Required]
    //    public string Email { get; set; }

    //    [Required]
    //    public string Message { get; set; }
    //}
}