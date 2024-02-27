using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketsRUs.ClassLib.Data;
using TicketsRUs.ClassLib.Services;

namespace TicketsRUs.WebApp.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EmailController : ControllerBase
{
    private readonly IEmailService emailSender;

    public EmailController(IEmailService emailSender)
    {
        this.emailSender = emailSender;
    }
    [HttpPost("postemail")]
    public async Task SendEmail(string receiverEmail, string identifier)
    {
        await emailSender.SendEmailAsync(receiverEmail, identifier);
    }
}
