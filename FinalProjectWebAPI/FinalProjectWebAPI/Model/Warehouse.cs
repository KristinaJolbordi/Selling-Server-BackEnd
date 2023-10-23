using System;
using System.Collections.Generic;

namespace FinalProjectWebAPI.Model;

public partial class Warehouse
{
    public int Id { get; set; }

    public DateTime OperationDate { get; set; }

    public string DocNumber { get; set; } = null!;

    public int ProductId { get; set; }

    public int SupplierId { get; set; }

    public int UnitId { get; set; }

    public int Quantity { get; set; }

    public DateTime ExpiryDate { get; set; }

    public decimal UnitPrice { get; set; }

    public decimal RealizationPrice { get; set; }

    public virtual Unit Unit { get; set; } = null!;
}
