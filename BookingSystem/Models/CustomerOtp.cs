using System;
using System.Collections.Generic;

namespace BookingSystem.Models;

public partial class CustomerOtp
{
    public long OtpId { get; set; }

    public long CustomerId { get; set; }

    public string OtpCode { get; set; } = null!;

    public DateTime ExpiresAt { get; set; }

    public int AttemptCount { get; set; }

    public bool IsUsed { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual Customer Customer { get; set; } = null!;
}
