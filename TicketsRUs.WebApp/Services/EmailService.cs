using MimeKit;
using TicketsRUs.ClassLib.Services;
using MailKit.Net.Smtp;
using MimeKit.Utils;

namespace TicketsRUs.WebApp.Services;

public class EmailService(IConfiguration config) : IEmailService
{

    public async Task SendEmailAsync(string ReceiverEmail, string identifier)
    {
        var message = new MimeMessage();
        message.From.Add(new MailboxAddress("Auto Emailer", config["googleAccount"]));
        message.To.Add(new MailboxAddress("An Email in need of a Message", ReceiverEmail));
        message.Subject = "Automated Message System";

        BodyBuilder bodyBuilder = new BodyBuilder();
        bodyBuilder.HtmlBody = $@"<html>
                    <body>
                        <p>Thank your for your Purchase</p>
                        <p>We are very excited that you can come to the concert!!</p>
                        <p>-- TicketUR</p>
                    </body>
                </html>";

        message.Body = bodyBuilder.ToMessageBody();

        var attachment = new MimePart("image", "png")
        {
            Content = new MimeContent(File.OpenRead($"imgs/{identifier}.png")),
            ContentDisposition = new ContentDisposition(ContentDisposition.Attachment),
            ContentTransferEncoding = ContentEncoding.Base64,
            FileName = Path.GetFileName(identifier)
        };

        attachment.ContentId = MimeUtils.GenerateMessageId();
        bodyBuilder.Attachments.Add(attachment);

        bodyBuilder.HtmlBody = bodyBuilder.HtmlBody.Replace("{QRCode}", $"cid:{attachment.ContentId}");

        message.Body = bodyBuilder.ToMessageBody();

        using (var client = new SmtpClient())
        {
            client.Connect("smtp.gmail.com", 587, false);

            // Note: only needed if the SMTP server requires authentication
            client.Authenticate(config["googleAccount"], config["googlePassword"]);

            client.Send(message);
            client.Disconnect(true);
        }
    }
}
