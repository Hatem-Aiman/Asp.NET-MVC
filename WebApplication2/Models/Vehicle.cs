using System;
using System.Collections.Generic;

namespace WebApplication2.Models;

public partial class Vehicle
{
    public int VehicleId { get; set; }

    public string VehicleType { get; set; } = null!;

    public int? Seat { get; set; }

    public int? TopSpeed { get; set; }

    public int DriverId { get; set; }

    public virtual ICollection<Driver> Drivers { get; set; } = new List<Driver>();

    public virtual ICollection<Ride> Rides { get; set; } = new List<Ride>();
}
