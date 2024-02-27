using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketsRUs.ClassLib.Services
{
    public interface IDatabaseLocation
    {
        public string DatabaseDirectory { get; }
        public string DatabaseName { get; }
    }
}
