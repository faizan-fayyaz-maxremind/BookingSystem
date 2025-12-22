using System;
using System.Collections.Generic;

namespace BookingSystem.Models;

public partial class LocationAvailability
{
    public long AvailabilityId { get; set; }

    public long LocationId { get; set; }

    public byte DayOfWeek { get; set; }

    public TimeOnly StartTime { get; set; }

    public TimeOnly EndTime { get; set; }

    public int SlotDurationMin { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual Location Location { get; set; } = null!;
}
