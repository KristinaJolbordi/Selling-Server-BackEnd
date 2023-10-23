using System;
using System.Collections.Generic;

namespace FinalProjectWebAPI.Model;

public partial class OrderItem
{
    public int Id { get; set; }

    public int OrderId { get; set; }

    public int ProductId { get; set; }

    public decimal UnitPrice { get; set; }

    public int Quantity { get; set; }

    public int IsDiscounted { get; set; }

    public decimal DiscountPrice { get; set; }
}
