using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class VQuotationList
{
    public long Id { get; set; }

    public string? QuotationNo { get; set; }

    public int? CustomerId { get; set; }

    public DateTime? CreateDate { get; set; }

    public int? CreateBy { get; set; }

    public DateTime? ModifyDate { get; set; }

    public int? ModifyBy { get; set; }

    public DateTime? ExpiryDate { get; set; }

    public decimal? Total { get; set; }

    public string? Note { get; set; }

    public byte? Status { get; set; }

    public byte? Discount { get; set; }

    public decimal? Vat { get; set; }

    public decimal? Paid { get; set; }

    public string? Customer { get; set; }
}
