using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketsRUs.ClassLib.Data
{
    public class Web<T> where T : Ticket

    {
        public T MauiaApp { get; set; }
        public T ApiApp { get; set; }
        public Web(T maui_app, T api_app)

        {
            MauiaApp = maui_app;
            ApiApp = api_app;
        }

    }
}
