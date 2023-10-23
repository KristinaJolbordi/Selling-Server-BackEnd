using System;
using System.Collections.Generic;

namespace FinalProjectWebAPI.Model;

public partial class CustomersPhoneNumber
{
    public string Id { get; set; } = null!;

    public int PhoneTypeId { get; set; }

    public string PhoneNumber { get; set; } = null!;

    public int CustomerId { get; set; }

    public string IsMain { get; set; } = null!;
}
