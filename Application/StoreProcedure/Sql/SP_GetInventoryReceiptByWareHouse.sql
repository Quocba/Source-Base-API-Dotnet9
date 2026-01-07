CREATE OR ALTER PROCEDURE GetInventoryReceiptByWareHouse
    @WareHouseId UNIQUEIDENTIFIER = NULL,
    @PageNumber INT,
    @PageSize INT,
    @Search NVARCHAR(255) = NULL,
    @Filter NVARCHAR(255) = NULL,
    @Month INT = NULL,
    @FromDate DATETIME = NULL,
    @ToDate DATETIME = NULL
AS 
BEGIN 
    SET NOCOUNT ON;
    DECLARE @Offset INT = (@PageNumber - 1) * @PageSize;

    ;WITH InventoryCTE AS(
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
            empCreated.FullName as CreatedByName,
            empModified.FullName as LastModifiedByName
        FROM InventoryReceipt ir
        LEFT JOIN WareHouses wh ON wh.Id = ir.WareHouseId
        LEFT JOIN Employees empCreated ON empCreated.Id = ir.CreatedBy
        LEFT JOIN Employees empModified ON empModified.Id = ir.LastModifiedBy
        WHERE (@WareHouseId IS NULL OR ir.WareHouseId = @WareHouseId)
          AND (ir.IsDeleted = 0 OR ir.IsDeleted IS NULL)
          AND (@Search IS NULL OR ir.ReceiptNo LIKE N'%'+@Search+'%' OR ir.Note LIKE N'%'+@Search+'%')
          AND (@Month IS NULL OR MONTH(ir.CreatedDate) = @Month)
          AND (@FromDate IS NULL OR ir.CreatedDate >= @FromDate)
          AND (@ToDate IS NULL OR ir.CreatedDate <= @ToDate)
    )
    SELECT *,
           COUNT(*) OVER() AS TotalRecords
    FROM InventoryCTE
    ORDER BY CreatedDate DESC
    OFFSET @Offset ROWS
    FETCH NEXT @PageSize ROWS ONLY;
END

