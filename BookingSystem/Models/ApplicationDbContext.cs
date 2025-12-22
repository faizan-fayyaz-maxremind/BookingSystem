using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BookingSystem.Models;

public partial class ApplicationDbContext : DbContext
{
    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Booking> Bookings { get; set; }

    public virtual DbSet<Business> Businesses { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<CustomerOtp> CustomerOtps { get; set; }

    public virtual DbSet<Location> Locations { get; set; }

    public virtual DbSet<LocationAvailability> LocationAvailabilities { get; set; }

    public virtual DbSet<LocationPricing> LocationPricings { get; set; }

    public virtual DbSet<Slot> Slots { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=MREMIND-62\\SQLSERVER01;Database=BookingApp;User=sa;Password=poiu1234;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Booking>(entity =>
        {
            entity.HasKey(e => e.BookingId).HasName("PK__Bookings__73951AEDC1B6EE9F");

            entity.Property(e => e.BookingStatus).HasMaxLength(20);
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysutcdatetime())");
            entity.Property(e => e.CustomerEmailSnap).HasMaxLength(200);
            entity.Property(e => e.CustomerNameSnap).HasMaxLength(200);
            entity.Property(e => e.CustomerPhoneSnap).HasMaxLength(20);
            entity.Property(e => e.PaymentStatus).HasMaxLength(20);
            entity.Property(e => e.VerificationNote).HasMaxLength(300);

            entity.HasOne(d => d.Customer).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Booking_Customer");

            entity.HasOne(d => d.Slot).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.SlotId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Booking_Slot");
        });

        modelBuilder.Entity<Business>(entity =>
        {
            entity.HasKey(e => e.BusinessId).HasName("PK__Business__F1EAA36E1D5387F4");

            entity.Property(e => e.BusinessType).HasMaxLength(100);
            entity.Property(e => e.ContactEmail).HasMaxLength(200);
            entity.Property(e => e.ContactPhone).HasMaxLength(20);
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysutcdatetime())");
            entity.Property(e => e.DefaultBankInfo).HasMaxLength(500);
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.Name).HasMaxLength(200);
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .HasDefaultValue("Active");

            entity.HasOne(d => d.Owner).WithMany(p => p.Businesses)
                .HasForeignKey(d => d.OwnerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Business_Owner");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PK__Customer__A4AE64D834427D83");

            entity.HasIndex(e => e.PhoneNumber, "UQ__Customer__85FB4E38941E4D6F").IsUnique();

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysutcdatetime())");
            entity.Property(e => e.Email).HasMaxLength(200);
            entity.Property(e => e.FullName).HasMaxLength(200);
            entity.Property(e => e.PhoneNumber).HasMaxLength(20);
            entity.Property(e => e.TimeZone).HasMaxLength(50);
        });

        modelBuilder.Entity<CustomerOtp>(entity =>
        {
            entity.HasKey(e => e.OtpId).HasName("PK__Customer__3143C4A3A4036CAC");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysutcdatetime())");
            entity.Property(e => e.OtpCode).HasMaxLength(10);

            entity.HasOne(d => d.Customer).WithMany(p => p.CustomerOtps)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Otp_Customer");
        });

        modelBuilder.Entity<Location>(entity =>
        {
            entity.HasKey(e => e.LocationId).HasName("PK__Location__E7FEA4978BC13E45");

            entity.Property(e => e.Address).HasMaxLength(500);
            entity.Property(e => e.BankAccountInfo).HasMaxLength(500);
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysutcdatetime())");
            entity.Property(e => e.InheritBankAccount).HasDefaultValue(true);
            entity.Property(e => e.Name).HasMaxLength(200);
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .HasDefaultValue("Active");

            entity.HasOne(d => d.Business).WithMany(p => p.Locations)
                .HasForeignKey(d => d.BusinessId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Location_Business");
        });

        modelBuilder.Entity<LocationAvailability>(entity =>
        {
            entity.HasKey(e => e.AvailabilityId).HasName("PK__Location__DA3979B1839F08BF");

            entity.ToTable("LocationAvailability");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysutcdatetime())");

            entity.HasOne(d => d.Location).WithMany(p => p.LocationAvailabilities)
                .HasForeignKey(d => d.LocationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Availability_Location");
        });

        modelBuilder.Entity<LocationPricing>(entity =>
        {
            entity.HasKey(e => e.PricingId).HasName("PK__Location__EC306B12D1236436");

            entity.ToTable("LocationPricing");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysutcdatetime())");
            entity.Property(e => e.DayType).HasMaxLength(20);
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.Location).WithMany(p => p.LocationPricings)
                .HasForeignKey(d => d.LocationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Pricing_Location");
        });

        modelBuilder.Entity<Slot>(entity =>
        {
            entity.HasKey(e => e.SlotId).HasName("PK__Slots__0A124AAF89B9C95D");

            entity.HasIndex(e => new { e.LocationId, e.SlotDate, e.StartTime, e.EndTime }, "UQ_Location_Slot").IsUnique();

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysutcdatetime())");
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.Location).WithMany(p => p.Slots)
                .HasForeignKey(d => d.LocationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Slot_Location");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__1788CC4C88D7DD6C");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysutcdatetime())");
            entity.Property(e => e.Email).HasMaxLength(200);
            entity.Property(e => e.FullName).HasMaxLength(200);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.PhoneNumber).HasMaxLength(20);
            entity.Property(e => e.Role).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
