using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketsRUs.ClassLib;

public static class Constants
{
    public const string DataBaseFileName = "Local.db3";
    public static string DatabasePath => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData));
}
