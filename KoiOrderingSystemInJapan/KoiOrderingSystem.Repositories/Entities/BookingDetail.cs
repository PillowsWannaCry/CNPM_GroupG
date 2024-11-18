using System;
using System.Collections.Generic;

namespace KoiOrderingSystem.Repositories.Entities;

public partial class BookingDetail
{
    public int BookingDetailId { get; set; }

    public int? BookingId { get; set; }

    public string Step { get; set; } = null!;

    public string Status { get; set; } = null!;

    public DateTime? UpdateDate { get; set; }

    public string? Notes { get; set; }

    public virtual Booking? Booking { get; set; }
}
