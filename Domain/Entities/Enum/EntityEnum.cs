using System;

namespace Domain.Entities.Enum
{
    /// <summary>
    /// Enum ánh xạ tên entity cho delete chung. FE truyền đúng tên dưới dạng string (case-insensitive).
    /// </summary>
    public enum EntityEnum
    {
        Unknown = 0,
        Bank,
        BrokeFeeReceipt,
        BusinessPartner,
        Department,
        Employee,
        InventoryLog,
        InventoryReceipt,
        InventoryReceiptDetail,
        LocalReceipt,
        Order,
        OrderDetail,
        Partner,
        Permission,
        Position,
        RecipeRice,
        RecipeRiceDetail,
        Rice,
        RiceBox,
        RiceGrade,
        RiceOrigin,
        RicePackaging,
        RiceType,
        SellReceiptDetail,
        SellsReceipt,
        Unit,
        User,
        WareHouse,
        WareHouseEmployee,
        WareHouseExport,
        WareHouseExportDetail,
        WareHouseExportReceipt,
        WareHouseImport,
        WareHouseImportDetail,
        WareHouseImportReceipt,
        WareHouseProduct,
        WareHouseTranfer,
        WareHouseTransferDetail,
        Products
    }
}
