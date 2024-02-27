using TicketsRUs.ClassLib.Data;

namespace TicketsRUs.ClassLib.Services;

public interface ITicketService
{
    Task<IEnumerable<Ticket>> GetAllTickets();
    Task<Ticket> GetTicket(int id);
    Task<Ticket> GetTicket(string identifier);
    Task<Ticket> CreateTicket(int event_id);
    Task<Ticket> CreateTicket(Ticket t);
    Task UpdateTicket(Ticket t);

    Task<IEnumerable<AvailableEvent>> GetAllAvailableEvents();
    Task<AvailableEvent> GetAvailableEvent(int id);
    Task<AvailableEvent> CreateAvailableEvent(AvailableEvent ai);
    Task UpdateAvailableEvent(AvailableEvent ai);
}
