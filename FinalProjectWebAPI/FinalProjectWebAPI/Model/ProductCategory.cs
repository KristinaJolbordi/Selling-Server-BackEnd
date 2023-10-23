using System;
using System.Collections.Generic;

namespace FinalProjectWebAPI.Model;

public partial class ProductCategory
{
    public int Id { get; set; }

    public string Code { get; set; } = null!;

    public string Name { get; set; } = null!;
}
