using System;
using System.Collections.Generic;

namespace WebApplication2.Models;

public partial class Driver
{
    public int DriverId { get; set; }

    public string? DriverName { get; set; }

    public int VehicleId { get; set; }

    public virtual ICollection<Ride> Rides { get; set; } = new List<Ride>();

    public virtual Vehicle Vehicle { get; set; } = null!;
}
