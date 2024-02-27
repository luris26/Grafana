using MimeKit;
using MailKit.Net.Smtp;
using System.Net.Mail;
using SmtpClient = MailKit.Net.Smtp.SmtpClient;
using TicketsRUs.ClassLib.Data;

namespace TicketsRUs.ClassLib.Services;

public interface  IEmailService
{
    Task SendEmailAsync(string receiverEmail, string identifier);
}
