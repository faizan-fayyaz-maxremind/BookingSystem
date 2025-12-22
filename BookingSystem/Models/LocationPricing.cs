using System;
using System.Collections.Generic;

namespace BookingSystem.Models;

public partial class LocationPricing
{
    public long PricingId { get; set; }

    public long LocationId { get; set; }

    public string DayType { get; set; } = null!;

    public decimal Price { get; set; }

    public DateOnly EffectiveFrom { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual Location Location { get; set; } = null!;
}
