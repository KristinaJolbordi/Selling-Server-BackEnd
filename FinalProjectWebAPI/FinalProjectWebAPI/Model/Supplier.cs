using System;
using System.Collections.Generic;

namespace FinalProjectWebAPI.Model;

public partial class Supplier
{
    public int Id { get; set; }

    public string CompanyCode { get; set; } = null!;

    public string CompanyName { get; set; } = null!;

    public string CompanyFullName { get; set; } = null!;

    public int CityId { get; set; }

    public int CountryId { get; set; }

    public string Phone { get; set; } = null!;

    public string Fax { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Address { get; set; } = null!;
}
