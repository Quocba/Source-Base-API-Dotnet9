using System;
using System.Collections.Generic;

namespace Domain.Entities;

/// <summary>
/// Thông tin người/công ty đang dùng phần mềm
/// </summary>
public partial class Company
{
    public int Id { get; set; }

    public int? CustomerId { get; set; }

    public string? TaxCode { get; set; }

    public string? Phone { get; set; }

    public string? CompanyName { get; set; }

    public string? Representative { get; set; }

    public string? Title { get; set; }

    public string? Email { get; set; }

    /// <summary>
    /// Dùng hiển thị lên hợp đồng
    /// </summary>
    public string? BankAccount { get; set; }

    /// <summary>
    /// Dùng hiển thị lên hợp đồng
    /// </summary>
    public string? BankName { get; set; }

    public string? Address { get; set; }

    public DateTime? CreateDate { get; set; }

    public int? CreateBy { get; set; }

    public virtual Customer? Customer { get; set; }
}
