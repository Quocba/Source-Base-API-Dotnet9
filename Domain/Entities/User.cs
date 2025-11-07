using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class User
{
    public int Id { get; set; }

    public string? Username { get; set; }

    public string? Fullname { get; set; }

    public string? Password { get; set; }

    public DateTime? CreateDate { get; set; }

    public DateTime? LastLogin { get; set; }

    public bool Deleted { get; set; }

    public byte? UserType { get; set; }

    public int? EmployeeId { get; set; }

    public bool Lock { get; set; }

    public virtual ICollection<Contract> ContractCreateByNavigations { get; set; } = new List<Contract>();

    public virtual ICollection<Contract> ContractModifyByNavigations { get; set; } = new List<Contract>();

    public virtual ICollection<ContractSup> ContractSupCreateByNavigations { get; set; } = new List<ContractSup>();

    public virtual ICollection<ContractSup> ContractSupModifyByNavigations { get; set; } = new List<ContractSup>();

    public virtual ICollection<Customer> CustomerCreateByNavigations { get; set; } = new List<Customer>();

    public virtual ICollection<Customer> CustomerModifyByNavigations { get; set; } = new List<Customer>();

    public virtual Employee? Employee { get; set; }

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();

    public virtual ICollection<Login> Logins { get; set; } = new List<Login>();

    public virtual ICollection<ProductCategory> ProductCategoryCreateByNavigations { get; set; } = new List<ProductCategory>();

    public virtual ICollection<ProductCategory> ProductCategoryModifyByNavigations { get; set; } = new List<ProductCategory>();

    public virtual ICollection<Product> ProductCreateByNavigations { get; set; } = new List<Product>();

    public virtual ICollection<Product> ProductModifyByNavigations { get; set; } = new List<Product>();

    public virtual ICollection<Quotation> QuotationCreateByNavigations { get; set; } = new List<Quotation>();

    public virtual ICollection<Quotation> QuotationModifyByNavigations { get; set; } = new List<Quotation>();

    public virtual ICollection<Receipt> ReceiptCreateByNavigations { get; set; } = new List<Receipt>();

    public virtual ICollection<Receipt> ReceiptModifyByNavigations { get; set; } = new List<Receipt>();

    public virtual ICollection<Supplier> SupplierCreateByNavigations { get; set; } = new List<Supplier>();

    public virtual ICollection<Supplier> SupplierModifyByNavigations { get; set; } = new List<Supplier>();

    public virtual ICollection<Transfer> TransferCreateByNavigations { get; set; } = new List<Transfer>();

    public virtual ICollection<Transfer> TransferModifyByNavigations { get; set; } = new List<Transfer>();

    public virtual UserType? UserTypeNavigation { get; set; }

    public virtual ICollection<WarehouseExport> WarehouseExportCreateByNavigations { get; set; } = new List<WarehouseExport>();

    public virtual ICollection<WarehouseExport> WarehouseExportModifyByNavigations { get; set; } = new List<WarehouseExport>();

    public virtual ICollection<WarehouseImport> WarehouseImportCreateByNavigations { get; set; } = new List<WarehouseImport>();

    public virtual ICollection<WarehouseImport> WarehouseImportModifyByNavigations { get; set; } = new List<WarehouseImport>();
    public virtual ICollection<UserPermissions> UserPermissions { get; set; } = new List<UserPermissions>();
}
