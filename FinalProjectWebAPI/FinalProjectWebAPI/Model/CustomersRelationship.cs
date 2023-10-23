using System;
using System.Collections.Generic;

namespace FinalProjectWebAPI.Model;

public partial class CustomersRelationship
{
    public int Id { get; set; }

    public int RelationshipTypeId { get; set; }

    public int StartCustomerId { get; set; }

    public int EndCustomerId { get; set; }

    public string Comment { get; set; } = null!;
}
