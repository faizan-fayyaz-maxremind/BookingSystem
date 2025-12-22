using System;
using System.Collections.Generic;

namespace BookingSystem.Models;

public partial class Booking
{
    public long BookingId { get; set; }

    public long SlotId { get; set; }

    public long CustomerId { get; set; }

    public string BookingStatus { get; set; } = null!;

    public string PaymentStatus { get; set; } = null!;

    public string CustomerNameSnap { get; set; } = null!;

    public string CustomerPhoneSnap { get; set; } = null!;

    public string? CustomerEmailSnap { get; set; }

    public string? VerificationNote { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? ExpiresAt { get; set; }

    public virtual Customer Customer { get; set; } = null!;

    public virtual Slot Slot { get; set; } = null!;
}
