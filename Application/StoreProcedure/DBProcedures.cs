using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.StoreProcedure
{
    public static class DBProcedures
    {
        public const string GetProducts = "GetProducts";
        public const string GetRiceTypes = "GetRiceTypes";
        public const string GetUnits = "GetUnits";
        public const string GetPositions = "GetPositions";
        public const string GetDepartments = "GetDepartments";
        public const string GetBanks = "GetBanks";
        public const string GetWareHouses = "GetWareHouses";
        public const string GetEmployees = "GetEmployees";
        public const string GetEmployeesByWareHouse = "GetEmployeesByWareHouse";
        public const string GetRicePackings = "GetRicePackings";
        public const string GetRices = "GetRices";
        public const string GetRicesByWareHouse = "GetRicesByWareHouse";
        public const string GetBusinessPartner = "GetBusinessPartner";
        public const string GetPartners = "GetPartners";
        public const string GetRiceReceipts = "GetRiceReceipts";
        public const string GetRiceReceiptDetail = "GetRiceReceiptsDetail";
        public const string GetAllWareHouseTransfer = "GetAllWareHouseTransfer";
        public const string GetTransferDetail = "GetTransferDetail";
        public const string GetTransferByWareHouses = "GetTransferByWareHouses";
        public const string GetInventoryReceiptByWareHouse = "GetInventoryReceiptByWareHouse";
        public const string GetInventoryReceiptDetail = "GetInventoryReceiptDetail";
    }
}
