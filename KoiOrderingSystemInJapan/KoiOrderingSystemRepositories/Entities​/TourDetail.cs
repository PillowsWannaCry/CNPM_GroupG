using System;
using System.Collections.Generic;

namespace KoiOrderingSystem.Repositories.Entities​;

public partial class TourDetail
{
    public int TourDetailId { get; set; }

    public int? TourId { get; set; }

    public string? Farm { get; set; }

    public string? FishType { get; set; }

    public string? Schedule { get; set; }

    public virtual Tour? Tour { get; set; }
}
