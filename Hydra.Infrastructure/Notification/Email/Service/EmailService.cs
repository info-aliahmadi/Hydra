using MimeKit.Text;
using MimeKit;
using MailKit.Net.Smtp;
using MailKit.Search;
using MailKit;
using MailKit.Net.Imap;
using MailKit.Security;
using Serilog;
using Hydra.Infrastructure.Notification.Email.Interface;
using Hydra.Infrastructure.Notification.Email.Models;
using Hydra.Infrastructure.Notification.Email.Setting;
using Hydra.Infrastructure.Notification.Sms.Interface;

namespace Hydra.Infrastructure.Notification.Email.Service
{
    public class EmailService : IEmailService
    {
        private readonly IEmailSetting _emailSetting;

        public EmailService(IEmailSetting emailSetting)
        {
            _emailSetting = emailSetting;
        }
        public bool IsEnabled()
        {
            return _emailSetting.IsEnabled;
        }

        public List<EmailMessage> ReceiveEmail()
        {
            using (var client = new ImapClient())
            {
                try
                {
                    client.Connect(_emailSetting.ImapServer, _emailSetting.ImapPort, SecureSocketOptions.None);

                    // Authenticate with the server
                    client.Authenticate(_emailSetting.ImapUsername, _emailSetting.ImapPassword);

                    // Select the INBOX folder
                    client.Inbox.Open(FolderAccess.ReadWrite);

                    List<EmailMessage> emails = new List<EmailMessage>();

                    // Search for unread messages
                    foreach (var uid in client.Inbox.Search(SearchQuery.NotSeen))
                    {
                        var message = client.Inbox.GetMessage(uid);

                        var emailMessage = new EmailMessage
                        {
                            UID = uid.ToString(),
                            Subject = message.Subject,
                            Date = message.Date,
                            Content = !string.IsNullOrEmpty(message.HtmlBody) ? message.HtmlBody : message.TextBody,
                            FromAddresses = message.From.Mailboxes.Select(x => new EmailAddress { Address = x.Address, Name = x.Name }).ToList(),
                            ToAddresses = message.To.Mailboxes.Select(x => new EmailAddress { Address = x.Address, Name = x.Name }).ToList(),
                            Attachments = message.Attachments.ToList()
                        };
                        emails.Add(emailMessage);

                        client.Inbox.AddFlags(uid, MessageFlags.Seen, true);
                    }

                    // Disconnect from the server
                    client.Disconnect(true);

                    return emails;
                }
                catch (Exception e)
                {
                    string inform = " | Load Emails : " + e.Message + "----------------------" + e.InnerException.Message;
                    Log.Fatal(inform);
                    throw;
                }

            }
        }

        public void Send(EmailMessage emailMessage)
        {
            var message = new MimeMessage();
            message.To.AddRange(emailMessage.ToAddresses.Select(x => new MailboxAddress(x.Name, x.Address)));
            message.From.AddRange(emailMessage.FromAddresses.Select(x => new MailboxAddress(x.Name, x.Address)));

            message.Subject = emailMessage.Subject;

            message.Date = emailMessage.Date;


            //We will say we are sending HTML. But there are options for plaintext etc. 
            message.Body = new TextPart(TextFormat.Html)
            {
                Text = emailMessage.Content
            };


            if (emailMessage.AttachmentPaths.Any())
            {
                var builder = new BodyBuilder();
                foreach (var attachmentPath in emailMessage.AttachmentPaths)
                {
                    builder.Attachments.Add(attachmentPath);
                }
                message.Body = builder.ToMessageBody();
            }

            //Be careful that the SmtpClient class is the one from Mailkit not the framework!
            using (var emailClient = new SmtpClient())
            {
                //The last parameter here is to use SSL (Which you should!)
                emailClient.Connect(_emailSetting.SmtpServer, _emailSetting.SmtpPort, true);

                //Remove any OAuth functionality as we won't be using it. 
                emailClient.AuthenticationMechanisms.Remove("XOAUTH2");

                emailClient.Authenticate(_emailSetting.SmtpUsername, _emailSetting.SmtpPassword);

                emailClient.Send(message);

                emailClient.Disconnect(true);
            }
        }
    }
}
