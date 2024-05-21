using System;
using System.Collections.Generic;

namespace WebApplication2.Models;

public partial class City
{
    public int CityId { get; set; }

    public string? CityName { get; set; }

    public string? Country { get; set; }

    public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();

    public virtual ICollection<Ride> RideEndCityNavigations { get; set; } = new List<Ride>();

    public virtual ICollection<Ride> RideStartCityNavigations { get; set; } = new List<Ride>();
}
