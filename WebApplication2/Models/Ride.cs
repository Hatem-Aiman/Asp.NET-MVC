using System;
using System.Collections.Generic;

namespace WebApplication2.Models;

public partial class Ride
{
    public int RideId { get; set; }

    public int? StartCity { get; set; }

    public int? EndCity { get; set; }

    public TimeOnly? StartTime { get; set; }

    public TimeOnly? EndTime { get; set; }

    public int VehicleId { get; set; }

    public int DriverId { get; set; }

    public virtual Driver Driver { get; set; } = null!;

    public virtual City? EndCityNavigation { get; set; }

    public virtual City? StartCityNavigation { get; set; }

    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();

    public virtual Vehicle Vehicle { get; set; } = null!;
}
