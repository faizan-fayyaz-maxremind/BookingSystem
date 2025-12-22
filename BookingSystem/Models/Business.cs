using System;
using System.Collections.Generic;

namespace BookingSystem.Models;

public partial class Business
{
    public long BusinessId { get; set; }

    public long OwnerId { get; set; }

    public string Name { get; set; } = null!;

    public string BusinessType { get; set; } = null!;

    public string? Description { get; set; }

    public string? ContactEmail { get; set; }

    public string? ContactPhone { get; set; }

    public string DefaultBankInfo { get; set; } = null!;

    public string Status { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public virtual ICollection<Location> Locations { get; set; } = new List<Location>();

    public virtual User Owner { get; set; } = null!;
}
