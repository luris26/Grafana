using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using TicketsRUs.ClassLib.Data;
using TicketsRUs.ClassLib.Services;

namespace TicketsRUs.Maui.Controllers;

public class Sync
{
    HttpClient client = new();
    public string ConnectionString { get; set; } = "";
    private ITicketService localTicketService;


    public Sync(ITicketService localTicketService)
    {
        this.localTicketService = localTicketService;
        ConnectionString = Preferences.Default.Get("addres", "https://ticketsruswebapp20240216164850.azurewebsites.net/");
    }

    public async Task Start()
    {
        var timer = new PeriodicTimer(TimeSpan.FromSeconds(5));
        while( await timer.WaitForNextTickAsync() )
        {
           await SyncMethod();
        }
    }

    public async Task SyncMethod()
    {
        try
        {
            List<AvailableEvent>? apiEvents = await client.GetFromJsonAsync<List<AvailableEvent>>($"{ConnectionString}/ApiTicket/events/");
            List<Ticket>? apiTickets = await client.GetFromJsonAsync<List<Ticket>>($"{ConnectionString}/ApiTicket/tickets/");

            if (apiEvents == null || apiTickets == null)
            {
                return;
            }

            await SyncEvents(apiEvents);
            await SyncTickets(apiTickets);
        }
        catch (Exception ex)
        {
            throw new Exception($"Error in the sync method {ex.Message}");
        }
    }

    private async Task SyncEvents(List<AvailableEvent> apiEvents)
    {
        var localEvents = await localTicketService.GetAllAvailableEvents();

        foreach (var ae in apiEvents)
        {
            var le = localEvents.Where(t => t.Id == ae.Id).Single();

            if (le == null)
            {
                await localTicketService.CreateAvailableEvent(ae);
            }
        }
    }

    private async Task SyncTickets(List<Ticket> apiTickets)
    {
        var localTickets = await localTicketService.GetAllTickets();
        foreach (Ticket at in apiTickets)
        {
            var lt = localTickets.Where(t => t.Id == at.Id).Single();

            if (lt == null)
            {
                await localTicketService.CreateTicket(at);
                continue;
            }

            bool isScanned = (lt.Scanned ?? false) || (at.Scanned ?? false);
            bool isDuplicateScan = (lt.Scanned ?? false) && (at.Scanned ?? false);

            if (isScanned)
            {
                lt.Scanned = true;
                await localTicketService.UpdateTicket(lt);
            }
        }
    }
}
