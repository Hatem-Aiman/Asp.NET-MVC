using System;
using System.Collections.Generic;

namespace WebApplication2.Models;

public partial class Ticket
{
    public int TicketId { get; set; }

    public int CustomerId { get; set; }

    public int RideId { get; set; }

    public virtual Customer Customer { get; set; } = null!;

    public virtual Ride Ride { get; set; } = null!;
}
