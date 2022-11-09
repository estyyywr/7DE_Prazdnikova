using System;
using System.Collections.Generic;

namespace _7DE_Prazdnikova.Models;

public partial class Supplier
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string Inn { get; set; } = null!;

    public DateTime StartDate { get; set; }

    public int? QualityRating { get; set; }

    public string? SupplierType { get; set; }

    public virtual ICollection<Material> Materials { get; } = new List<Material>();
}
