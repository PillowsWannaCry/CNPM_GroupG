using System;
using System.Collections.Generic;

namespace KoiOrderingSystem.Repositories.Entities​;

public partial class Feedback
{
    public int FeedbackId { get; set; }

    public int? CustomerId { get; set; }

    public int? TourId { get; set; }

    public string? Content { get; set; }

    public int? Rating { get; set; }

    public DateTime? CreatedDate { get; set; }

    public virtual KoiOrderCustomer? Customer { get; set; }

    public virtual Tour? Tour { get; set; }
}
