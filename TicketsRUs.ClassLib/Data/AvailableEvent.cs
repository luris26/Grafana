using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;

namespace TicketsRUs.ClassLib.Data;

public partial class AvailableEvent
{
    [PrimaryKey]
    public int Id { get; set; }

    public DateTime? StartTime { get; set; }

    public string? Name { get; set; }

    [ManyToMany (typeof(Ticket))]
    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
}
