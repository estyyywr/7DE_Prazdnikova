using System;
using System.Collections.Generic;

namespace _7DE_Prazdnikova.Models;

public partial class MaterialType
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public double DefectedPercent { get; set; }

    public virtual ICollection<Material> Materials { get; } = new List<Material>();
}
