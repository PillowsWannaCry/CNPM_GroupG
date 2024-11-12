using System;
using System.Collections.Generic;

namespace KoiOrderingSystem.Repositories.Entities​;

public partial class Tour
{
    public int TourId { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public decimal Price { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();

    public virtual ICollection<Feedback> Feedbacks { get; set; } = new List<Feedback>();

    public virtual ICollection<TourDetail> TourDetails { get; set; } = new List<TourDetail>();
}
