using System;
using System.Collections.Generic;

namespace FinalProjectWebAPI.Model;

public partial class Order
{
    public int Id { get; set; }

    public DateTime OrderDate { get; set; }

    public int OrderNumber { get; set; }

    public int CustomerId { get; set; }

    public int TotalAmount { get; set; }
}
