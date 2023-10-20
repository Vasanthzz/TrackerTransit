using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace test.lib.Entity;

public partial class LocationContext : DbContext
{
    public LocationContext()
    {
    }

    public LocationContext(DbContextOptions<LocationContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Control> Controls { get; set; }

    public virtual DbSet<Driver> Drivers { get; set; }

    public virtual DbSet<UserLocation> UserLocations { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=VASANTH\\SQLEXPRESS;Database=location;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Control>(entity =>
        {
            entity.ToTable("Control");

            entity.Property(e => e.ControlName).HasMaxLength(100);
            entity.Property(e => e.ControlValue).HasMaxLength(100);
        });

        modelBuilder.Entity<Driver>(entity =>
        {
            entity.ToTable("Driver");

            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.Mobile).HasMaxLength(100);
            entity.Property(e => e.ModifiedAt).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Route).HasMaxLength(100);
            entity.Property(e => e.UniqueId).HasMaxLength(100);
        });

        modelBuilder.Entity<UserLocation>(entity =>
        {
            entity.Property(e => e.Latitude).HasColumnName("latitude");
            entity.Property(e => e.Longitude).HasColumnName("longitude");
            entity.Property(e => e.UserId).HasColumnName("userId");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
