CREATE OR ALTER PROCEDURE GetInventoryReceiptDetail
    @InventoryReceiptId UNIQUEIDENTIFIER
AS
BEGIN
    SET NOCOUNT ON;

    -- 1. Header
    SELECT
        ir.Id,
        ir.CreatedDate,
        ir.ReceiptNo,
        ir.WareHouseId,
        wh.Name as WareHouseName,
        ir.Note,
        ir.TotalRice,
        ir.ActualRice,
        ir.Status,
        ir.IsDeleted,
        ir.ToDate,
        empCreated.FullName as CreatedBy,
        empModified.FullName as LastModifiedBy
    FROM InventoryReceipt ir
    LEFT JOIN WareHouses wh ON wh.Id = ir.WareHouseId
    LEFT JOIN Employees empCreated ON empCreated.Id = ir.CreatedBy
    LEFT JOIN Employees empModified ON empModified.Id = ir.LastModifiedBy
    WHERE ir.Id = @InventoryReceiptId;

    -- 2. Employees
    SELECT
        e.Id as EmployeeId,
        e.FullName as Name,
        e.PositionId,
        p.Name as Position,
        e.Phone
    FROM InventoryReceiptEmployee ire
    JOIN Employees e ON e.Id = ire.EmployeeId
    LEFT JOIN Positions p ON p.Id = e.PositionId
    WHERE ire.InventoryReceiptId = @InventoryReceiptId;

    -- 3. Details
    SELECT
        d.Id,
        r.Code as RiceCode,
        r.Name as Rice,
        r.RiceTypeId as TypeId,
        rt.Name as RiceType,
        d.Unit,
        d.TotalRice,
        d.ActualRice,
        d.Offset,
        d.Note
    FROM InventoryReceiptDetail d
    JOIN Rices r ON r.Id = d.RiceId
    LEFT JOIN RiceTypes rt ON rt.Id = r.RiceTypeId
    WHERE d.InventoryReceiptId = @InventoryReceiptId;

END
