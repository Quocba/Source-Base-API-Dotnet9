using AngleSharp.Text;

namespace Domain.Share.Common
{
    public static class EndpointManage
    {
        public const string ApiVersion = "api/v1";

        public static class Reports
        {
            public const string Create = "create";
            public const string Edit  = "edit";
            public const string GetReportsByContractNo = "get-reports-by-contract";
            public const string Delete = "delete";
        }
        public static class Permissions
        {
            public const string GetPermissions = "get-permissions";
            public const string SetAndUnSetDepartmentPermission = "set-unset-department-permission";
        }
        public static class Users
        {
            public const string CreateNewUser = "create-user";
            public const string GetUsers = "get-users";
            public const string SetUserRole = "set-user-role";
            public const string GetUserTypes = "get-user-types";
            public const string EditUserInfo = "edit-user-info" + "/{userId}";
            public const string DeleteUserOrRestore = "delete-or-restore" + "/{userId}";
            public const string LockOrUnLock = "lock-or-unlock" + "/{userId}";
        }
        public static class ParentContracts {

            public const string CreateParentContract = "create-parent-contract";
            public const string GetParentContracts = "get-parent-contracts";
            public const string EditParentContract = "edit-parent-contract" + "/{parentContractId}";
            public const string GetContractsByParent = "get-contracts-by-parent"; 
        
        }
        public static class ContractStorages
        {
            public const string UploadContractFile = "upload-file";
            public const string DeleteContractFile = "delete-contract-file";
            public const string GetFileByContractNo = "get-file-by-contract";
            public const string Download = "download" + "/{fileID}";
        }
        public static class WareHouseReceipt
        {
            public const string CreateWareHouseReceipt = "create-warehouse-receipt";
            public const string DeleteProductFromReceipts = "delete-product-from-receipt" + "/{wareHouseReceiptID}";
            public const string AddProductToReceipt = "add-product-to-receipt" + "/{wareHouseReceiptID}";
            public const string EditProductFromDetail = "edit-product-from-detail" + "/{wareHouseReceiptID}";
            public const string GetWareHouseReceipts = "get-warehouse-receipts";
            public const string GetReceiptsByWareHouseNo = "get-receipts-by-warehouseno";
            public const string GetDetail = "get-details";
        }
        public static class Statictis
        {
            public const string StatictisWithYear = "statictis-year"; 
            public const string StatictisReceiptsService = "statictis-receipt-service";
            public const string StatictisTotalCustomerContract = "total-customer-contract";
            public const string StatictisTotalsuplierContract = "total-suplier-contract";
            public const string StatictisInternalTransfer = "statictis-internal-transfer";
            public const string StatictisContracReceipts = "statictis-contract-receipts";
            public const string GetBestSellingProduct = "get-best-selling-product";
            public const string StatictisTotalCustomer = "statictis-total-customer";
            public const string GetTopContracts = "top-contracts";
            public const string GetTopSellers = "get-top-seller";
            public const string GetCollectAndSpedFromContract = "collect-spend-from-contracts";
            public const string SumaryOnAndOverTimeAmountContract = "sumary-on-and-over-time-amount-contract";
            public const string ProductsInStock = "products-in-stock";
        }
        public static class WareHouseImports
        {
            public const string CreateImport = "create";
            public const string EditImport = "edit-import" + "/{importId}";
            public const string AddProductToImport = "add-product-to-import" + "/{importID}";
            public const string DeleteProduct = "delete-product-from-import";
            public const string EditProductQUantity = "edit-product-quantity";
            public const string DeleteImport = "delete" + "/{importId}";
            public const string GetImports = "get-imports";
            public const string GetDetail = "get-details";
            public const string EditProductFromImport = "edit-product" + "/{detailID}";
        }
        public static class WareHouseExports
        {
            public const string CreateExport = "create";
            public const string EditExport = "edit" + "/{exportNo}";
            public const string DeleteExport = "delete" + "/{exportId}";
            public const string EditProductQuantity = "edit-product-quantity";
            public const string AddProductToExport = "add-product" + "/{exportId}";
            public const string DeleteProductFromExport = "delete-product";
            public const string GetExports = "get-exports";
            public const string GetDetail = "get-detail";
        }
        public static class Receipts
        {
            public const string CreateReceipt = "create";
            public const string EditReceiptInfo = "edit-receipt" + "/{receiptID}";
            public const string DeleteReceipt = "delete-receipt" + "/{receiptId}";
            public const string GetReceipts = "get-receipts";
        }
        public static class ContractReceipts
        {
            public const string CreateReceipt = "create";
            public const string EditReceiptInfo = "edit-receipt" + "/{receiptId}";
            public const string DeleteReceiptInfo = "delete-receipt";
            public const string GetReceipts = "get-receipts";
            public const string BatchCollect = "bach-need-collect";
            public const string HistoryCollect = "history-collect";
            public const string HistorySpend = "history-spend";
            public const string HistoriesSpendByContract = "histories-spend-by-contract";
            public const string GetReceipt = "receipt";
        }
        public static class ContractSuppliers
        {
            public const string CreateNewContract = "create";
            public const string AddProductToSupContract = "add-product-to-contract" + "/{supplierContractId}";
            public const string DeleteProductFromSupContract = "delete-product-from-contract";
            public const string GetSupplierContracts = "supplier-contracts";
            public const string GetSupplierByContract = "get-supplier-by-contract" + "/{supplierContractId}";
            public const string GetDetail = "get-detail";
            public const string UpdateQuantityProductFromSupContract = "update-quantity-product-from-contract";
            public const string EditContractSup = "edit-contract-sup" + "/{supplierContractId}";
            public const string GetSupContractByCustomerContractNo = "get-sup-contracts-by-customer-contract";
            public const string EditProductFromSupContract = "edit-product-from-sup-contract" + "/{detailId}";
            public const string DeleteSupContract = "delete-supcontract" + "/{supContractId}";
            public const string ReamainningSuplierContract = "reamainning-supplier-contract";

        }
        public static class Contract
        {
            public const string CreateNewContract = "create";
            public const string AddProductToContract = "add-product-to-contract" + "/{contractId}";
            public const string DeleteProductFromContract = "delete-product-from-contract";
            public const string UpdateProductQuantityFromContract = "update-product-quantity-from-contract";
            public const string UpdateContractInfo = "update-contract-info" + "/{contractId}";
            public const string EditExportedProductFromContract = "edit-exported-product";
            public const string GetContracts = "contracts";
            public const string GetCustomerByContract = "get-customer-by-contract" + "/{contractId}";
            public const string GetContractDetail = "get-contract-detail";
            public const string EditProductFormContract = "edit-product-form-contract" + "/{detailId}";
            public const string DeleteContract = "delete-contract" + "/{contractID}";
            public const string GetReminingProduct = "get-remining-product";
            public const string NeedCollectByContract = "need-collect";
            public const string NeedSpendByContract = "need-spend";
            public const string NeedSpendSupplierByContract = "need-spend-supplier";
        }
        public static class Transfer
        {
            private const string Entity = "transfer";
            public const string InternalTransfer = "internal-transfer";
            public const string EditInternalTransfer = "edit" + "/{transferId}";
            public const string Delete = "delete" + "/{transferId}";
            public const string GetTransfers = "get-transfer";
            public const string GetTransferReceipts = "get-receipts";
            public const string GetReceiptsByBank = "get-receipts-by-bank";
        }
        public static class Quotation
        {
            private const string Entity = "quotations";
            public const string GetAll = Entity;               // GET /quotations
            public const string GetDetail = "get-detail" + "/{quotationId}";    // GET /quotations/{id}
            public const string Create = "create";               // POST /quotations
            public const string Update = "update" + "/{quotationId}";     // PUT /quotations/{id}
            public const string Delete = "delete" + "/{id}";     // DELETE /quotations/{id}
            public const string Restore = "restore" + "/{id}";   // PUT /quotations/{id}
            public const string AddProduct = "add-product" + "/{quotationId}"; // POST /quotations/{id}/add-product
            public const string DeleteProduct = "delete-quotation-product"; // DELETE /quotations/{id}/delete-product
            public const string EditProductQuantity = "edit-quantity-product"; // PATCH /quotations/{id}/edit-quantity-product
            public const string GetCustomer = "get-customer-by-quotation/{quotationId}"; //Get/ quotations/get-customer-by-qoutation
            public const string CreateNewCustomer = "create-new-customer/{quotationId}"; //Post /quotations/create-new-customer/{quotationId}
            public const string UploadWithExcel = "upload-excel";
            public const string SendMail = "send-mail";
            public const string EditProductFormQuotation = "edit-product-form-quotation" + "/{quotationDetailId}";
        }
        public static class Department
        {
            private const string Entity = "departments";
            public const string GetAll = Entity;               // GET /departments
            public const string GetDetail = "get-detail" + "/{id}";    // GET /departments/{id}
            public const string Create = "create";               // POST /departments
            public const string Update = "update" + "/{id}";     // PUT /departments/{id}
            public const string Delete = "delete" + "/{id}";     // DELETE /departments/{id}
        }

        public static class BankAccounts
        {
            private const string Entity = "bank-accounts";
            public const string GetAll = Entity;               // GET /bank-accounts
            public const string GetDetail = "get-detail" + "/{id}";    // GET /bank-accounts/{id}
            public const string Create = "create";               // POST /bank-accounts
            public const string Update = "update" + "/{id}";     // PUT /bank-accounts/{id}
            public const string Delete = "delete" + "/{id}";     // DELETE /bank-accounts/{id}
            public const string Restore = "restore" + "/{id}";   // PUT /bank-accounts/{id}
            public const string BankList = "vietqr-banks";
        }
        public static class Employee
        {
            private const string Entity = "employees";

            public const string GetAll = Entity;               // GET /employees
            public const string GetDetail = "get-detail" + "/{id}";    // GET /employees/{id}
            public const string Create = "create";               // POST /employees
            public const string Update = "update" + "/{id}";     // PUT /employees/{id}
            public const string Delete = "delete" + "/{id}";     // DELETE /employees/{id}
            public const string Restore = "restore" + "/{id}";   // PUT /employees/{id}
        };
        public static class EmployeeType
        {
            private const string Entity = "employee-types";
            public const string GetAll = Entity;               // GET /employee-types
            public const string GetDetail = "get-detail" + "/{id}";    // GET /employee-types/{id}
            public const string Create = "create";               // POST /employee-types
            public const string Update = "update" + "/{id}";     // PUT /employee-types/{id}
            public const string Delete = "delete" + "/{id}";     // DELETE /employee-types/{id}
            public const string Resotre = "resotre" + "/{id}";     // DELETE /employee-types/{id}
        }
        public static class Suppliers
        {
            private const string Entity = "suppliers";
            public const string GetAll = Entity;               // GET /suppliers
            public const string GetDetail = "get-detail" + "/{id}";    // GET /suppliers/{id}
            public const string Create = "create";               // POST /suppliers
            public const string Update = "update" + "/{id}";     // PUT /suppliers/{id}
            public const string Delete = "delete" + "/{id}";     // DELETE /suppliers/{id}
            public const string Restore = "restore" + "/{id}";
        }
        public static class Unit
        {
            private const string Entity = "units";
            public const string GetAll = Entity;               // GET /units
            public const string GetDetail = "get-detail" + "/{id}";    // GET /units/{id}
            public const string Create = "create";               // POST /units
            public const string Update = "update" + "/{id}";     // PUT /units/{id}
            public const string Delete = "delete" + "/{id}";     // DELETE /units/{id}

        }
        public static class Customer
        {
            private const string Entity = "customers";
            public const string GetAll = Entity;               // GET /customers
            public const string GetDetail = "get-detail" + "/{id}";    // GET /customers/{id}
            public const string Create = "create";               // POST /customers
            public const string Update = "update" + "/{id}";     // PUT /customers/{id}
            public const string Delete = "delete" + "/{id}";     // DELETE /customers/{id}
            public const string Restore = "restore" + "/{id}";     // PUT /units/{id}

        }



        public static class Product
        {
            private const string Entity = "products";
            public const string GetAll = Entity;               // GET /products
            public const string GetDetail = "get-detail" + "/{id}";    // GET /products/{id}
            public const string Create = "create";               // POST /products
            public const string Update = "update" + "/{id}";     // PUT /products/{id}
            public const string Delete = "delete" + "/{id}";     // DELETE /products/{id}
            public const string Import = "import-products"; /// import
        }
        public static class Category
        {
            private const string Entity = "categories";

            public const string GetAll = Entity;               // GET /categories
            public const string GetById = Entity + "/{id}";    // GET /categories/{id}
            public const string Create = Entity;               // POST /categories
            public const string Update = Entity + "/{id}";     // PUT /categories/{id}
            public const string Delete = Entity + "/{id}";     // DELETE /categories/{id}
        }

        public static class Authenication
        {
            private const string Entity = "auth";
            public const string Login = Entity + "/login";      // POST /auth/login
            public const string Register = Entity + "/register"; // POST /auth/register
            public const string RefreshToken = Entity + "/refresh-token"; // POST /auth/refresh-token
            public const string ChangePassword = Entity + "/change-password"; // PATCH /auth/change-password
        }
    }
}
