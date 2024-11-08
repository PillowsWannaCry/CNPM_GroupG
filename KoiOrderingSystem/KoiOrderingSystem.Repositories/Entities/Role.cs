using System;
using System.Collections.Generic;

namespace KoiOrderingSystem.Repositories.Entities;

public partial class Role
{
    public int RoleId { get; set; }

    public string RoleName { get; set; } = null!;

    public virtual ICollection<KoiOrderEmployee> KoiOrderEmployees { get; set; } = new List<KoiOrderEmployee>();
}
