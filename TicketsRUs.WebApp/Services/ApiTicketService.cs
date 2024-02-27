using Microsoft.EntityFrameworkCore;
using TicketsRUs.ClassLib.Data;

namespace TicketsRUs.ClassLib.Services;

public class ApiTicketService(IDbContextFactory<PostgresContext> factory) : ITicketService
{
    public async Task<Ticket> CreateTicket(int event_id)
    {
        var context = factory.CreateDbContext();

        Ticket ticket = new Ticket()
        {
            Id = await context.Tickets.CountAsync() + 1,
            EventId = event_id,
            Scanned = false,
            Identifier = GetIdentifier()
        };

        context.Tickets.Add(ticket);
        await context.SaveChangesAsync();

        return ticket;
    }

    public async Task<Ticket> CreateTicket(Ticket t)
    {
        var context = factory.CreateDbContext();

        context.Tickets.Add(t);
        await context.SaveChangesAsync();

        return t;
    }

    public async Task<AvailableEvent> CreateAvailableEvent(AvailableEvent ai)
    {
        var context = factory.CreateDbContext();

        context.AvailableEvents.Add(ai);
        await context.SaveChangesAsync();

        return ai;
    }

    public async Task<IEnumerable<AvailableEvent>> GetAllAvailableEvents()
    {
        var context = factory.CreateDbContext();
        return await context.AvailableEvents.ToListAsync();
    }

    public async Task<IEnumerable<Ticket>> GetAllTickets()
    {
        var context = factory.CreateDbContext();
        return await context.Tickets.Include(t => t.Event).ToListAsync();
    }

    public async Task<AvailableEvent> GetAvailableEvent(int id)
    {
        var context = factory.CreateDbContext();
        return await context.AvailableEvents
            .Where(e => e.Id == id)
            .FirstOrDefaultAsync();
    }

    public async Task<Ticket> GetTicket(int id)
    {
        var context = factory.CreateDbContext();
        return await context.Tickets
            .Where(e => e.Id == id)
            .FirstOrDefaultAsync();
    }

    public async Task<Ticket> GetTicket(string identifier)
    {
        var context = factory.CreateDbContext();
        return await context.Tickets
            .Where(e => e.Identifier == identifier)
            .FirstOrDefaultAsync();
    }

    public async Task UpdateTicket(Ticket t)
    {
        var context = factory.CreateDbContext();
        context.Update(t);

        await context.SaveChangesAsync();
    }

    public async Task UpdateAvailableEvent(AvailableEvent ai)
    {
        var context = factory.CreateDbContext();
        context.Update(ai);

        await context.SaveChangesAsync();
    }

    private string GetIdentifier()
    {
        return $"{Math.Abs(DateTime.Now.ToString().GetHashCode())}{Math.Abs(DateTime.Now.Microsecond.ToString().GetHashCode())}{DateTime.Now.Millisecond}";
    }
}
