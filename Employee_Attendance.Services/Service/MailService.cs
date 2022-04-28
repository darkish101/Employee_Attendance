using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Employee_Attendance.Services
{
    public interface IMailService
    {
        void SendEmail(MailRequest mailRequest);
    }
    public class MailService : IMailService
    {
        private readonly MailSettings _mailSettings;
        public MailService(IOptions<MailSettings> mailSettings)
        {
            _mailSettings = mailSettings.Value;
        }

        public void SendEmail(MailRequest mailRequest)
        {
            var client = new SmtpClient(_mailSettings.Host, Convert.ToInt32(_mailSettings.Port))
            {
                Credentials = new NetworkCredential(_mailSettings.Mail, _mailSettings.Password),
                EnableSsl = true
            };

            MailMessage message = new MailMessage(_mailSettings.Mail, mailRequest.ToEmail);
            message.From = new MailAddress(_mailSettings.Mail, _mailSettings.DisplayName);

            message.IsBodyHtml = true;
            message.Body = mailRequest.Body;
            message.Subject = mailRequest.Subject;
            if (mailRequest.Attachments != null)
            {
                MemoryStream fileBytes;
                foreach (var file in mailRequest.Attachments)
                {
                    if (file.Length > 0)
                    {
                        using (var ms = new MemoryStream())
                        {
                            file.CopyTo(ms);
                            fileBytes = ms;
                        }
                        message.Attachments.Add(new Attachment(fileBytes, file.ContentType, file.FileName));
                    }
                }
            }
            client.Send(message);
            client.Dispose();
        }
    }
}