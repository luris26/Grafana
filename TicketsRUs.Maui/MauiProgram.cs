using Microsoft.Extensions.Logging;
using TicketsRUs.ClassLib.Services;
using TicketsRUs.Maui.Services;
using ZXing.Net.Maui.Controls;

namespace TicketsRUs.Maui
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseBarcodeReader()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });

            builder.Services.AddMauiBlazorWebView();
            builder.Services.AddSingleton<ITicketService, MauiTicketService>();
            builder.Services.AddSingleton<IDatabaseLocation, LocalDatabaseService>();
            // TODO: Add SyncController with MauiTicketController instance

#if DEBUG
    		builder.Services.AddBlazorWebViewDeveloperTools();
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
