

using Hydra.Kernel.Interfaces;
using Hydra.Kernel.Models;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using Nitro.Core.Interfaces.Settings;
using Twilio.Clients;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace Nitro.Service.MessageSender
{
    public class MessageSender : IEmailSender, ISmsSender
    {
        private readonly ISmtpSetting _smtpSetting;
        private readonly ISmsSetting _smsSetting;
        public MessageSender(ISmtpSetting smtpSetting, ISmsSetting smsSetting)
        {
            _smtpSetting = smtpSetting;
            _smsSetting = smsSetting;
        }
        public async Task SendEmailAsync(EmailRequestRecord requestRecord)
        {
            var email = new MimeMessage();
            email.Sender = MailboxAddress.Parse(_smtpSetting.From);
            email.To.Add(MailboxAddress.Parse(requestRecord.ToEmail));
            email.Subject = requestRecord.Subject;
            var builder = new BodyBuilder();
            if (requestRecord.Attachments.Any())
            {
                foreach (var file in requestRecord.Attachments.Where(file => file.Length > 0))
                {
                    byte[] fileBytes;
                    await using (var ms = new MemoryStream())
                    {
                        await file.CopyToAsync(ms);
                        fileBytes = ms.ToArray();
                    }
                    builder.Attachments.Add(file.FileName, fileBytes, ContentType.Parse(file.ContentType));
                }
            }
            builder.HtmlBody = requestRecord.Body;
            email.Body = builder.ToMessageBody();
            using var smtp = new SmtpClient();
            await smtp.ConnectAsync(_smtpSetting.SmtpServer, _smtpSetting.Port, SecureSocketOptions.StartTls);
            await smtp.AuthenticateAsync(_smtpSetting.From, _smtpSetting.Password);
            await smtp.SendAsync(email);
            await smtp.DisconnectAsync(true);

        }

        public async Task SendSmsAsync(SmsRequestRecord requestRecord)
        {
            var client = new TwilioRestClient( _smsSetting.AccountSid, _smsSetting.AuthToken);

            // Pass the client into the resource method
            var message = await MessageResource.CreateAsync(
                to: new PhoneNumber(requestRecord.ToNumber),
                from: new PhoneNumber(_smsSetting.FromNumber),
                body: requestRecord.Message,
                client: client);

        }
    }
}
