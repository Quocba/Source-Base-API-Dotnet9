using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class VQuotationInfo
{
    public long Id { get; set; }

    public string? QuotationNo { get; set; }

    public DateTime? CreateDate { get; set; }

    public string? CompanyName { get; set; }

    public string? Customer { get; set; }

    public decimal? Total { get; set; }
}
