using System;
using System.Collections.Generic;

namespace BookingSystem.Models;

public partial class User
{
    public long UserId { get; set; }

    public string FullName { get; set; } = null!;

    public string? Email { get; set; }

    public string? PhoneNumber { get; set; }

    public string Role { get; set; } = null!;

    public bool IsActive { get; set; }

    public DateTime CreatedAt { get; set; }
    public string PasswordHash { get; set; }

    public virtual ICollection<Business> Businesses { get; set; } = new List<Business>();
}
