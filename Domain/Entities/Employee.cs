using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Employee
{
    public Guid Id { get; set; }

    public string? Code { get; set; }

    public string? FullName { get; set; }

    public string? Gener { get; set; }

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public string? Address { get; set; }

    public string? MaritalStatus { get; set; }

    public string? Nationality { get; set; }

    public string? Avatar { get; set; }

    public string? HireDate { get; set; }

    public string? Status { get; set; }

    public Guid DepartmentId { get; set; }

    public Guid PositionId { get; set; }

    public Guid UserId { get; set; }

    public bool? IsDeleted { get; set; }

    public DateTime? CreatedDate { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    public Guid? CreatedBy { get; set; }

    public Guid? LastModifiedBy { get; set; }

    public virtual ICollection<BrokeFeeReceipt> BrokeFeeReceipts { get; set; } = new List<BrokeFeeReceipt>();

    public virtual ICollection<BusinessPartner> BusinessPartnerCreatedByNavigations { get; set; } = new List<BusinessPartner>();

    public virtual ICollection<BusinessPartner> BusinessPartnerLastModifiedByNavigations { get; set; } = new List<BusinessPartner>();

    public virtual Employee? CreatedByNavigation { get; set; }

    public virtual Department Department { get; set; } = null!;

    public virtual ICollection<Department> DepartmentCreatedByNavigations { get; set; } = new List<Department>();

    public virtual ICollection<Department> DepartmentLastModifiedByNavigations { get; set; } = new List<Department>();

    public virtual ICollection<InventoryReceipt> InventoryReceiptCreatedByNavigations { get; set; } = new List<InventoryReceipt>();

    public virtual ICollection<InventoryReceipt> InventoryReceiptFirstCheckerNavigations { get; set; } = new List<InventoryReceipt>();

    public virtual ICollection<InventoryReceipt> InventoryReceiptLastModifiedByNavigations { get; set; } = new List<InventoryReceipt>();

    public virtual ICollection<InventoryReceipt> InventoryReceiptSecondCheckerNavigations { get; set; } = new List<InventoryReceipt>();

    public virtual ICollection<InventoryReceipt> InventoryReceiptThirdCheckerNavigations { get; set; } = new List<InventoryReceipt>();

    public virtual ICollection<Employee> InverseCreatedByNavigation { get; set; } = new List<Employee>();

    public virtual ICollection<Employee> InverseLastModifiedByNavigation { get; set; } = new List<Employee>();

    public virtual Employee? LastModifiedByNavigation { get; set; }

    public virtual ICollection<Order> OrderCreatedByNavigations { get; set; } = new List<Order>();

    public virtual ICollection<Order> OrderEmployeeOrderNavigations { get; set; } = new List<Order>();

    public virtual ICollection<Order> OrderLastModifiedByNavigations { get; set; } = new List<Order>();

    public virtual Position Position { get; set; } = null!;

    public virtual ICollection<RecipeRice> RecipeRiceCreatedByNavigations { get; set; } = new List<RecipeRice>();

    public virtual ICollection<RecipeRice> RecipeRiceLastModifiedByNavigations { get; set; } = new List<RecipeRice>();

    public virtual ICollection<Rice> RiceCreatedByNavigations { get; set; } = new List<Rice>();

    public virtual ICollection<RiceGrade> RiceGradeCreatedByNavigations { get; set; } = new List<RiceGrade>();

    public virtual ICollection<RiceGrade> RiceGradeLastModifiedByNavigations { get; set; } = new List<RiceGrade>();

    public virtual ICollection<Rice> RiceLastModifiedByNavigations { get; set; } = new List<Rice>();

    public virtual ICollection<RiceOrigin> RiceOriginCreatedByNavigations { get; set; } = new List<RiceOrigin>();

    public virtual ICollection<RiceOrigin> RiceOriginLastModifiedByNavigations { get; set; } = new List<RiceOrigin>();

    public virtual ICollection<RicePackaging> RicePackagingCreatedByNavigations { get; set; } = new List<RicePackaging>();

    public virtual ICollection<RicePackaging> RicePackagingLastModifiedByNavigations { get; set; } = new List<RicePackaging>();

    public virtual ICollection<RiceType> RiceTypeCreatedByNavigations { get; set; } = new List<RiceType>();

    public virtual ICollection<RiceType> RiceTypeLastModifiedByNavigations { get; set; } = new List<RiceType>();

    public virtual ICollection<SellsReceipt> SellsReceiptCreatedByNavigations { get; set; } = new List<SellsReceipt>();

    public virtual ICollection<SellsReceipt> SellsReceiptLastModifiedByNavigations { get; set; } = new List<SellsReceipt>();

    public virtual ICollection<Unit> UnitCreatedByNavigations { get; set; } = new List<Unit>();

    public virtual ICollection<Unit> UnitLastModifiedByNavigations { get; set; } = new List<Unit>();

    public virtual User User { get; set; } = null!;

    public virtual ICollection<WareHouse> WareHouseCreatedByNavigations { get; set; } = new List<WareHouse>();

    public virtual ICollection<WareHouseEmployee> WareHouseEmployees { get; set; } = new List<WareHouseEmployee>();

    public virtual ICollection<WareHouseExport> WareHouseExportCreatedByNavigations { get; set; } = new List<WareHouseExport>();

    public virtual ICollection<WareHouseExport> WareHouseExportLastModifiedByNavigations { get; set; } = new List<WareHouseExport>();

    public virtual ICollection<WareHouseExportReceipt> WareHouseExportReceiptCreatedByNavigations { get; set; } = new List<WareHouseExportReceipt>();

    public virtual ICollection<WareHouseExportReceipt> WareHouseExportReceiptEmployeeSpendNavigations { get; set; } = new List<WareHouseExportReceipt>();

    public virtual ICollection<WareHouseExportReceipt> WareHouseExportReceiptLastModifiedByNavigations { get; set; } = new List<WareHouseExportReceipt>();

    public virtual ICollection<WareHouseImport> WareHouseImportCreatedByNavigations { get; set; } = new List<WareHouseImport>();

    public virtual ICollection<WareHouseImport> WareHouseImportLastModifiedByNavigations { get; set; } = new List<WareHouseImport>();

    public virtual ICollection<WareHouseImportReceipt> WareHouseImportReceiptCreatedByNavigations { get; set; } = new List<WareHouseImportReceipt>();

    public virtual ICollection<WareHouseImportReceipt> WareHouseImportReceiptEmployeeSpendNavigations { get; set; } = new List<WareHouseImportReceipt>();

    public virtual ICollection<WareHouseImportReceipt> WareHouseImportReceiptLastModifiedByNavigations { get; set; } = new List<WareHouseImportReceipt>();

    public virtual ICollection<WareHouse> WareHouseLastModifiedByNavigations { get; set; } = new List<WareHouse>();

    public virtual ICollection<WareHouseTranfer> WareHouseTranferCreatedByNavigations { get; set; } = new List<WareHouseTranfer>();

    public virtual ICollection<WareHouseTranfer> WareHouseTranferLastModifiedByNavigations { get; set; } = new List<WareHouseTranfer>();
}
