using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketsRUs.ClassLib.Services;

namespace TicketsRUs.Maui.Services
{
    internal class LocalDatabaseService : IDatabaseLocation
    {
        public string DatabaseDirectory { get => "Local.db3"; }

        public string DatabaseName {get => FileSystem.Current.AppDataDirectory;}
    }
}
