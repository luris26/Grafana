using Microsoft.AspNetCore.Mvc;
using TicketsRUs.ClassLib.Data;
using TicketsRUs.ClassLib.Services;

namespace TicketsRUs.ClassLib.Controllers;

[Route("[controller]")]
[ApiController]
public class ApiTicketController : ControllerBase
{
    ITicketService _service;
    public ApiTicketController(ITicketService service)
    {
        _service = service;
    }

    [HttpGet("events")]
    public async Task<IEnumerable<AvailableEvent>> GetAllAvailableEvents()
    {
        return await _service.GetAllAvailableEvents();
    }

    [HttpGet("tickets")]
    public async Task<IEnumerable<Ticket>> GetAllTickets()
    {
        return await _service.GetAllTickets();
    }

    [HttpGet("event/{id}")]
    public async Task<AvailableEvent> GetAvailableEvent(int id)
    {
        return await _service.GetAvailableEvent(id);
    }

    [HttpGet("ticket/{id}")]
    public async Task<Ticket> GetTicket(int id)
    {
        return await _service.GetTicket(id);
    }

    [HttpPost("update/ticket")]
    public async Task UpdateTicket(Ticket t)
    {
        await _service.UpdateTicket(t);
    }

    [HttpGet("ticket/create/{event_id}")]
    public async Task<Ticket> CreateTicket(int event_id)
    {
        return await _service.CreateTicket(event_id);
    }
}
