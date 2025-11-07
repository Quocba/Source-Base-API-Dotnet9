using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Transaction
{
    public long Id { get; set; }

    public int? CustomerId { get; set; }

    public long? ContractId { get; set; }

    public long? WarehouseId { get; set; }

    public int? BankAccountId { get; set; }

    public DateTime? TransactionDate { get; set; }

    /// <summary>
    /// Số tiền thanh toán
    /// </summary>
    public decimal? Cost { get; set; }

    /// <summary>
    /// Hình thức thanh toán
    /// </summary>
    public string? Mode { get; set; }

    public string? Note { get; set; }
}
