using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelBooking.Utils
{
    public class EmailSender
    {
        // Please use your API KEY here.
        private const String API_KEY = "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";

        public void Send(String toEmail, String subject, String contents, String Attachment)
        {
            var client = new SendGridClient(API_KEY);
            var from = new EmailAddress(toEmail, "From jin app contact me");
            var to = new EmailAddress("jinchen835498158@gmail.com", "");
            var plainTextContent = contents;
            var htmlContent = "<p>" + contents + "</p>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var bytes = File.ReadAllBytes(Attachment);
            var file = Convert.ToBase64String(bytes);
            string filename = Path.GetFileName(Attachment);
            msg.AddAttachment(filename, file);
            var response = client.SendEmailAsync(msg);
        }

    }
}