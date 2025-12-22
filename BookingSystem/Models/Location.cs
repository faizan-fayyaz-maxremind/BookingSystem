using System;
using System.Collections.Generic;

namespace BookingSystem.Models;

public partial class Location
{
    public long LocationId { get; set; }

    public long BusinessId { get; set; }

    public string Name { get; set; } = null!;

    public string Address { get; set; } = null!;

    public bool InheritBankAccount { get; set; }

    public string? BankAccountInfo { get; set; }

    public string Status { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public virtual Business Business { get; set; } = null!;

    public virtual ICollection<LocationAvailability> LocationAvailabilities { get; set; } = new List<LocationAvailability>();

    public virtual ICollection<LocationPricing> LocationPricings { get; set; } = new List<LocationPricing>();

    public virtual ICollection<Slot> Slots { get; set; } = new List<Slot>();
}
