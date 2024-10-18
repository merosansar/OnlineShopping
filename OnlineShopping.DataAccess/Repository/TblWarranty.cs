using System;
using System.Collections.Generic;

namespace OnlineShopping.DataAccess.Repository;

public partial class TblWarranty
{
    public int Id { get; set; }

    public string Period { get; set; } = null!;

    public string Type { get; set; } = null!;

    public string? CoverageDetails { get; set; }

    public string? TermsConditions { get; set; }

    public string? ServiceInfo { get; set; }
}
