using MimeKit.Text;
using MimeKit;
using MailKit.Net.Smtp;
using MailKit.Search;
using MailKit;
using MailKit.Net.Imap;
using MailKit.Security;
using Hydra.Infrastructure.Email.Models;

namespace Hydra.Infrastructure.Email.Service
{
    public class EmailService : IEmailService
    {
        private readonly IEmailConfiguration _emailConfiguration;

        public EmailService(IEmailConfiguration emailConfiguration)
        {
            _emailConfiguration = emailConfiguration;
        }

        public List<EmailMessage> ReceiveEmail()
        {
            using (var client = new ImapClient())
            {
                client.Connect(_emailConfiguration.ImapServer, _emailConfiguration.ImapPort, SecureSocketOptions.SslOnConnect);

                // Authenticate with the server
                client.Authenticate(_emailConfiguration.ImapUsername, _emailConfiguration.ImapPassword);

                // Select the INBOX folder
                client.Inbox.Open(FolderAccess.ReadOnly);

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
                    emailMessage.ToAddresses.AddRange(message.To.Select(x => (MailboxAddress)x).Select(x => new EmailAddress { Address = x.Address, Name = x.Name }));
                    emailMessage.FromAddresses.AddRange(message.From.Select(x => (MailboxAddress)x).Select(x => new EmailAddress { Address = x.Address, Name = x.Name }));
                    emails.Add(emailMessage);
                }

                // Disconnect from the server
                client.Disconnect(true);

                return emails;
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
                emailClient.Connect(_emailConfiguration.SmtpServer, _emailConfiguration.SmtpPort, true);

                //Remove any OAuth functionality as we won't be using it. 
                emailClient.AuthenticationMechanisms.Remove("XOAUTH2");

                emailClient.Authenticate(_emailConfiguration.SmtpUsername, _emailConfiguration.SmtpPassword);

                emailClient.Send(message);

                emailClient.Disconnect(true);
            }
        }
    }
}
