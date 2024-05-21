using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;

namespace WebApplication2.Data;

public partial class TestdbContext : DbContext
{
    public TestdbContext()
    {
    }

    public TestdbContext(DbContextOptions<TestdbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<City> Cities { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Driver> Drivers { get; set; }

    public virtual DbSet<Notstudent> Notstudents { get; set; }

    public virtual DbSet<Ride> Rides { get; set; }

    public virtual DbSet<Ticket> Tickets { get; set; }

    public virtual DbSet<Vehicle> Vehicles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
       => optionsBuilder.UseSqlServer("Data Source=HATEM-PC\\SQLEXPRESS;Initial Catalog=Busdb;Integrated Security=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<City>(entity =>
        {
            entity.HasKey(e => e.CityId).HasName("PK__city__031491A896834912");

            entity.ToTable("city");

            entity.Property(e => e.CityId).HasColumnName("city_id");
            entity.Property(e => e.CityName)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("city_name");
            entity.Property(e => e.Country)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("country");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PK__customer__CD65CB8540B8FE0C");

            entity.ToTable("customer");

            entity.Property(e => e.CustomerId).HasColumnName("customer_id");
            entity.Property(e => e.CityId).HasColumnName("city_id");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.FirstName)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("first_name");
            entity.Property(e => e.LastName)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("last_name");
            entity.Property(e => e.Phone).HasColumnName("phone");

            entity.HasOne(d => d.City).WithMany(p => p.Customers)
                .HasForeignKey(d => d.CityId)
                .HasConstraintName("FK__customer__city_i__412EB0B6");
        });

        modelBuilder.Entity<Driver>(entity =>
        {
            entity.HasKey(e => e.DriverId).HasName("PK_Drivers");

            entity.ToTable("driver");

            entity.Property(e => e.DriverId).HasColumnName("driver_id");
            entity.Property(e => e.DriverName)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("driver_name");
            entity.Property(e => e.VehicleId).HasColumnName("vehicle_id");

            entity.HasOne(d => d.Vehicle).WithMany(p => p.Drivers)
                .HasForeignKey(d => d.VehicleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_driver_vehicle");
        });

        modelBuilder.Entity<Notstudent>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("notstudent");

            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.JoinDate).HasColumnName("join_date");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Ride>(entity =>
        {
            entity.HasKey(e => e.RideId).HasName("PK__Rides__C5B8C4F48EEB3DD3");

            entity.ToTable("ride");

            entity.Property(e => e.RideId).HasColumnName("ride_id");
            entity.Property(e => e.DriverId).HasColumnName("driver_id");
            entity.Property(e => e.EndCity).HasColumnName("end_city");
            entity.Property(e => e.EndTime).HasColumnName("end_time");
            entity.Property(e => e.StartCity).HasColumnName("start_city");
            entity.Property(e => e.StartTime).HasColumnName("start_time");
            entity.Property(e => e.VehicleId).HasColumnName("vehicle_id");

            entity.HasOne(d => d.Driver).WithMany(p => p.Rides)
                .HasForeignKey(d => d.DriverId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ride_driver");

            entity.HasOne(d => d.EndCityNavigation).WithMany(p => p.RideEndCityNavigations)
                .HasForeignKey(d => d.EndCity)
                .HasConstraintName("FK__Rides__End_City__3F466844");

            entity.HasOne(d => d.StartCityNavigation).WithMany(p => p.RideStartCityNavigations)
                .HasForeignKey(d => d.StartCity)
                .HasConstraintName("FK__Rides__Start_Cit__3E52440B");

            entity.HasOne(d => d.Vehicle).WithMany(p => p.Rides)
                .HasForeignKey(d => d.VehicleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Rides_Vehicles");
        });

        modelBuilder.Entity<Ticket>(entity =>
        {
            entity.HasKey(e => e.TicketId).HasName("PK_Tickets");

            entity.ToTable("ticket");

            entity.Property(e => e.TicketId).HasColumnName("ticket_id");
            entity.Property(e => e.CustomerId).HasColumnName("customer_id");
            entity.Property(e => e.RideId).HasColumnName("ride_id");

            entity.HasOne(d => d.Customer).WithMany(p => p.Tickets)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Tickets_customers");

            entity.HasOne(d => d.Ride).WithMany(p => p.Tickets)
                .HasForeignKey(d => d.RideId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Tickets_Rides");
        });

        modelBuilder.Entity<Vehicle>(entity =>
        {
            entity.HasKey(e => e.VehicleId).HasName("PK__Vehicles__476B54923333A483");

            entity.ToTable("vehicle");

            entity.Property(e => e.VehicleId).HasColumnName("vehicle_id");
            entity.Property(e => e.DriverId).HasColumnName("driver_id");
            entity.Property(e => e.Seat).HasColumnName("seat");
            entity.Property(e => e.TopSpeed).HasColumnName("top_speed");
            entity.Property(e => e.VehicleType)
                .HasMaxLength(50)
                .HasColumnName("vehicle_type");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
