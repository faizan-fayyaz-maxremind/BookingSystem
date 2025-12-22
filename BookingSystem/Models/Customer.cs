using System;
using System.Collections.Generic;

namespace BookingSystem.Models;

public partial class Customer
{
    public long CustomerId { get; set; }

    public string FullName { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public string? Email { get; set; }

    public bool IsVerified { get; set; }

    public string? TimeZone { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();

    public virtual ICollection<CustomerOtp> CustomerOtps { get; set; } = new List<CustomerOtp>();
}
