using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Mail;
using System.Net;

namespace mstc.Pages
{

    public class indexModel : PageModel
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
            using (var message = new MailMessage("mstcvit@outlook.com", "mstcvit@outlook.com"))
            {
                message.To.Add(new MailAddress("mstcvit@outlook.com"));
                message.Subject = "MSTC - Contact Form";
                message.Body = mailbody;

                using (var smtpClient = new SmtpClient("smtp.office365.com"))
                {
                    smtpClient.UseDefaultCredentials = false;
                    smtpClient.Credentials = new NetworkCredential("UserName","Password"); //MSTC account username and password
                    smtpClient.Port = 587; //587, 465, 25 are common smtp ports
                    smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtpClient.EnableSsl = true;
                    smtpClient.Send(message);
                }
            }
        }
    }

    public class ContactFormModel

    {
        [Required]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Message { get; set; }
    }

}