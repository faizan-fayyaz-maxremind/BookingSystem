using System;
using System.Collections.Generic;

namespace BookingSystem.Models;

public partial class Slot
{
    public long SlotId { get; set; }

    public long LocationId { get; set; }

    public DateOnly SlotDate { get; set; }

    public TimeOnly StartTime { get; set; }

    public TimeOnly EndTime { get; set; }

    public decimal Price { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();

    public virtual Location Location { get; set; } = null!;
}
