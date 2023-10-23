using System;
using System.Collections.Generic;

namespace FinalProjectWebAPI.Model;

public partial class Unit
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string ShortName { get; set; } = null!;

    public virtual ICollection<Warehouse> Warehouses { get; set; } = new List<Warehouse>();
}
