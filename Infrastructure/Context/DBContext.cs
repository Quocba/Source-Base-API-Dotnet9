using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context
{
    public partial class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {
        }


        public virtual DbSet<Bank> Banks { get; set; }

        public virtual DbSet<BrokeFeeReceipt> BrokeFeeReceipts { get; set; }

        public virtual DbSet<BusinessPartner> BusinessPartners { get; set; }

        public virtual DbSet<Department> Departments { get; set; }

        public virtual DbSet<Employee> Employees { get; set; }

        public virtual DbSet<InventoryLog> InventoryLogs { get; set; }

        public virtual DbSet<InventoryReceipt> InventoryReceipts { get; set; }

        public virtual DbSet<InventoryReceiptDetail> InventoryReceiptDetails { get; set; }

        public virtual DbSet<LocalReceipt> LocalReceipts { get; set; }

        public virtual DbSet<Order> Orders { get; set; }

        public virtual DbSet<OrderDetail> OrderDetails { get; set; }

        public virtual DbSet<Partner> Partners { get; set; }

        public virtual DbSet<Permission> Permissions { get; set; }

        public virtual DbSet<Position> Positions { get; set; }

        public virtual DbSet<RecipeRice> RecipeRices { get; set; }

        public virtual DbSet<RecipeRiceDetail> RecipeRiceDetails { get; set; }

        public virtual DbSet<Rice> Rices { get; set; }

        public virtual DbSet<RiceBox> RiceBoxes { get; set; }

        public virtual DbSet<RiceGrade> RiceGrades { get; set; }

        public virtual DbSet<RiceOrigin> RiceOrigins { get; set; }

        public virtual DbSet<RicePackaging> RicePackagings { get; set; }

        public virtual DbSet<RiceType> RiceTypes { get; set; }

        public virtual DbSet<SellReceiptDetail> SellReceiptDetails { get; set; }

        public virtual DbSet<SellsReceipt> SellsReceipts { get; set; }

        public virtual DbSet<Unit> Units { get; set; }

        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<WareHouse> WareHouses { get; set; }

        public virtual DbSet<WareHouseEmployee> WareHouseEmployees { get; set; }

        public virtual DbSet<WareHouseExport> WareHouseExports { get; set; }

        public virtual DbSet<WareHouseExportDetail> WareHouseExportDetails { get; set; }

        public virtual DbSet<WareHouseExportReceipt> WareHouseExportReceipts { get; set; }

        public virtual DbSet<WareHouseImport> WareHouseImports { get; set; }

        public virtual DbSet<WareHouseImportDetail> WareHouseImportDetails { get; set; }

        public virtual DbSet<WareHouseImportReceipt> WareHouseImportReceipts { get; set; }

        public virtual DbSet<WareHouseProduct> WareHouseProducts { get; set; }

        public virtual DbSet<WareHouseTranfer> WareHouseTranfers { get; set; }

        public virtual DbSet<WareHouseTransferDetail> WareHouseTransferDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bank>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__Bank__3214EC2758CA0560");

                entity.ToTable("Bank");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");
                entity.Property(e => e.BankNo).HasMaxLength(255);
                entity.Property(e => e.Location).HasMaxLength(255);
                entity.Property(e => e.Name).HasMaxLength(255);
                entity.Property(e => e.WareHouseId).HasColumnName("WareHouseID");

                entity.HasOne(d => d.WareHouse).WithMany(p => p.Banks)
                    .HasForeignKey(d => d.WareHouseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Bank__WareHouseI__0F624AF8");
            });

            modelBuilder.Entity<BrokeFeeReceipt>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__BrokeFee__3214EC275D8543DA");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");
                entity.Property(e => e.Date).HasColumnType("datetime");
                entity.Property(e => e.ParterId).HasColumnName("ParterID");
                entity.Property(e => e.Reason).HasMaxLength(255);
                entity.Property(e => e.TotalAmounts).HasColumnType("decimal(18, 0)");
                entity.Property(e => e.WareHouseImportId).HasColumnName("WareHouseImportID");

                entity.HasOne(d => d.EmployeeSpendNavigation).WithMany(p => p.BrokeFeeReceipts)
                    .HasForeignKey(d => d.EmployeeSpend)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__BrokeFeeR__Emplo__03F0984C");

                entity.HasOne(d => d.Parter).WithMany(p => p.BrokeFeeReceipts)
                    .HasForeignKey(d => d.ParterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__BrokeFeeR__Parte__02084FDA");

                entity.HasOne(d => d.WareHouseImport).WithMany(p => p.BrokeFeeReceipts)
                    .HasForeignKey(d => d.WareHouseImportId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__BrokeFeeR__WareH__02FC7413");
            });

            modelBuilder.Entity<BusinessPartner>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__Business__3214EC279EABD949");

                entity.ToTable("BusinessPartner");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");
                entity.Property(e => e.AddressLine).HasMaxLength(255);
                entity.Property(e => e.BankName).HasMaxLength(255);
                entity.Property(e => e.BankNo).HasMaxLength(255);
                entity.Property(e => e.City).HasMaxLength(255);
                entity.Property(e => e.CompanyName).HasMaxLength(255);
                entity.Property(e => e.Country).HasMaxLength(255);
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");
                entity.Property(e => e.District).HasMaxLength(255);
                entity.Property(e => e.Email).HasMaxLength(255);
                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");
                entity.Property(e => e.Name).HasMaxLength(255);
                entity.Property(e => e.PartnerType).HasMaxLength(50);
                entity.Property(e => e.Phone).HasMaxLength(255);
                entity.Property(e => e.StateOrProvince).HasMaxLength(255);
                entity.Property(e => e.TaxCode).HasMaxLength(255);
                entity.Property(e => e.Type).HasMaxLength(255);

                entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.BusinessPartnerCreatedByNavigations)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__BusinessP__Creat__2EDAF651");

                entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.BusinessPartnerLastModifiedByNavigations)
                    .HasForeignKey(d => d.LastModifiedBy)
                    .HasConstraintName("FK__BusinessP__LastM__2FCF1A8A");
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__Departme__3214EC2716659579");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");
                entity.Property(e => e.Code).HasMaxLength(255);
                entity.Property(e => e.CreateDate).HasColumnType("datetime");
                entity.Property(e => e.Description).HasMaxLength(255);
                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");
                entity.Property(e => e.Name).HasMaxLength(255);

                entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.DepartmentCreatedByNavigations)
                    .HasForeignKey(d => d.CreatedBy)
                    .HasConstraintName("FK__Departmen__Creat__1F98B2C1");

                entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.DepartmentLastModifiedByNavigations)
                    .HasForeignKey(d => d.LastModifiedBy)
                    .HasConstraintName("FK__Departmen__LastM__208CD6FA");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__Employee__3214EC279E2A15F7");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");
                entity.Property(e => e.Address).HasMaxLength(255);
                entity.Property(e => e.Avatar).HasMaxLength(255);
                entity.Property(e => e.Code).HasMaxLength(100);
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");
                entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");
                entity.Property(e => e.Email).HasMaxLength(255);
                entity.Property(e => e.FullName).HasMaxLength(100);
                entity.Property(e => e.Gener).HasMaxLength(50);
                entity.Property(e => e.HireDate).HasMaxLength(255);
                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");
                entity.Property(e => e.MaritalStatus).HasMaxLength(50);
                entity.Property(e => e.Nationality).HasMaxLength(255);
                entity.Property(e => e.Phone).HasMaxLength(15);
                entity.Property(e => e.PositionId).HasColumnName("PositionID");
                entity.Property(e => e.Status).HasMaxLength(255);
                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.InverseCreatedByNavigation)
                    .HasForeignKey(d => d.CreatedBy)
                    .HasConstraintName("FK__Employees__Creat__2180FB33");

                entity.HasOne(d => d.Department).WithMany(p => p.Employees)
                    .HasForeignKey(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Employees__Depar__1CBC4616");

                entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.InverseLastModifiedByNavigation)
                    .HasForeignKey(d => d.LastModifiedBy)
                    .HasConstraintName("FK__Employees__LastM__22751F6C");

                entity.HasOne(d => d.Position).WithMany(p => p.Employees)
                    .HasForeignKey(d => d.PositionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Employees__Posit__1DB06A4F");

                entity.HasOne(d => d.User).WithMany(p => p.Employees)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Employees__UserI__1EA48E88");
            });

            modelBuilder.Entity<InventoryLog>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__Inventor__3214EC274521D10C");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");
                entity.Property(e => e.Actual).HasColumnType("decimal(18, 0)");
                entity.Property(e => e.Beginning).HasColumnType("decimal(18, 0)");
                entity.Property(e => e.Date).HasColumnType("datetime");
                entity.Property(e => e.Inventory).HasColumnType("decimal(18, 0)");
                entity.Property(e => e.Offset).HasColumnType("decimal(18, 0)");
                entity.Property(e => e.RiceId).HasColumnName("RiceID");
                entity.Property(e => e.TotalExport).HasColumnType("decimal(18, 0)");
                entity.Property(e => e.TotalImport).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.Rice).WithMany(p => p.InventoryLogs)
                    .HasForeignKey(d => d.RiceId)
                    .HasConstraintName("FK__Inventory__RiceI__08B54D69");
            });

            modelBuilder.Entity<InventoryReceipt>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__Inventor__3214EC2742CFFBED");

                entity.ToTable("InventoryReceipt");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");
                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");
                entity.Property(e => e.ReceiptNo).HasMaxLength(255);
                entity.Property(e => e.TotalAmounts).HasColumnType("decimal(18, 0)");
                entity.Property(e => e.TotalRice).HasColumnType("decimal(18, 0)");
                entity.Property(e => e.WareHouseId).HasColumnName("WareHouseID");

                entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.InventoryReceiptCreatedByNavigations)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Inventory__Creat__3A4CA8FD");

                entity.HasOne(d => d.FirstCheckerNavigation).WithMany(p => p.InventoryReceiptFirstCheckerNavigations)
                    .HasForeignKey(d => d.FirstChecker)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Inventory__First__1332DBDC");

                entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.InventoryReceiptLastModifiedByNavigations)
                    .HasForeignKey(d => d.LastModifiedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Inventory__LastM__3B40CD36");

                entity.HasOne(d => d.SecondCheckerNavigation).WithMany(p => p.InventoryReceiptSecondCheckerNavigations)
                    .HasForeignKey(d => d.SecondChecker)
                    .HasConstraintName("FK__Inventory__Secon__14270015");

                entity.HasOne(d => d.ThirdCheckerNavigation).WithMany(p => p.InventoryReceiptThirdCheckerNavigations)
                    .HasForeignKey(d => d.ThirdChecker)
                    .HasConstraintName("FK__Inventory__Third__151B244E");

                entity.HasOne(d => d.WareHouse).WithMany(p => p.InventoryReceipts)
                    .HasForeignKey(d => d.WareHouseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Inventory__WareH__123EB7A3");
            });

            modelBuilder.Entity<InventoryReceiptDetail>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__Inventor__3214EC2757287CF7");

                entity.ToTable("InventoryReceiptDetail");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");
                entity.Property(e => e.InventoryReceiptId).HasColumnName("InventoryReceiptID");
                entity.Property(e => e.Note).HasMaxLength(255);
                entity.Property(e => e.Offset).HasColumnType("decimal(18, 0)");
                entity.Property(e => e.Quantity).HasColumnType("decimal(18, 0)");
                entity.Property(e => e.RiceId).HasColumnName("RiceID");
                entity.Property(e => e.Subtoal).HasColumnType("decimal(18, 0)");
                entity.Property(e => e.Unit).HasMaxLength(255);
                entity.Property(e => e.UnitPrice).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.InventoryReceipt).WithMany(p => p.InventoryReceiptDetails)
                    .HasForeignKey(d => d.InventoryReceiptId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Inventory__Inven__10566F31");

                entity.HasOne(d => d.Rice).WithMany(p => p.InventoryReceiptDetails)
                    .HasForeignKey(d => d.RiceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Inventory__RiceI__114A936A");
            });

            modelBuilder.Entity<LocalReceipt>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__LocalRec__3214EC272E4BE0F7");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");
                entity.Property(e => e.Collect).HasColumnType("decimal(18, 0)");
                entity.Property(e => e.Date).HasColumnType("datetime");
                entity.Property(e => e.Note).HasMaxLength(255);
                entity.Property(e => e.ReceiptType).HasMaxLength(255);
                entity.Property(e => e.Remaining).HasColumnType("decimal(18, 0)");
                entity.Property(e => e.Spend).HasColumnType("decimal(18, 0)");
                entity.Property(e => e.TargetCode).HasMaxLength(255);
                entity.Property(e => e.TargetType).HasMaxLength(255);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__Orders__3214EC27E759E9A8");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");
                entity.Property(e => e.BusinessPartnerId).HasColumnName("BusinessPartnerID");
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");
                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");
                entity.Property(e => e.OrderNo).HasMaxLength(255);
                entity.Property(e => e.Total).HasColumnType("decimal(18, 0)");
                entity.Property(e => e.WareHouseId).HasColumnName("WareHouseID");

                entity.HasOne(d => d.BusinessPartner).WithMany(p => p.Orders)
                    .HasForeignKey(d => d.BusinessPartnerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Orders__Business__17036CC0");

                entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.OrderCreatedByNavigations)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Orders__CreatedB__32AB8735");

                entity.HasOne(d => d.EmployeeOrderNavigation).WithMany(p => p.OrderEmployeeOrderNavigations)
                    .HasForeignKey(d => d.EmployeeOrder)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Orders__Employee__160F4887");

                entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.OrderLastModifiedByNavigations)
                    .HasForeignKey(d => d.LastModifiedBy)
                    .HasConstraintName("FK__Orders__LastModi__339FAB6E");

                entity.HasOne(d => d.WareHouse).WithMany(p => p.Orders)
                    .HasForeignKey(d => d.WareHouseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Orders__WareHous__17F790F9");
            });

            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__OrderDet__3214EC27DD839DDA");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");
                entity.Property(e => e.PruchaseReceiptId).HasColumnName("PruchaseReceiptID");
                entity.Property(e => e.RiceId).HasColumnName("RiceID");
                entity.Property(e => e.Subtotal).HasColumnType("decimal(18, 0)");
                entity.Property(e => e.Unit).HasMaxLength(255);
                entity.Property(e => e.UnitPrice).HasColumnType("decimal(18, 0)");
                entity.Property(e => e.Weight).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.PruchaseReceipt).WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.PruchaseReceiptId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__OrderDeta__Pruch__56E8E7AB");

                entity.HasOne(d => d.Rice).WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.RiceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__OrderDeta__RiceI__57DD0BE4");
            });

            modelBuilder.Entity<Partner>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__Partner__3214EC277C589726");

                entity.ToTable("Partner");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");
                entity.Property(e => e.Name).HasMaxLength(255);
                entity.Property(e => e.Phone).HasMaxLength(20);
                entity.Property(e => e.TotalFee).HasColumnType("decimal(18, 0)");
            });

            modelBuilder.Entity<Permission>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__Permissi__3214EC2784BBA37E");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");
                entity.Property(e => e.Action).HasMaxLength(255);
                entity.Property(e => e.Description).HasMaxLength(255);
                entity.Property(e => e.Module).HasMaxLength(255);
                entity.Property(e => e.Name).HasMaxLength(255);
            });

            modelBuilder.Entity<Position>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__Position__3214EC2716241E83");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");
                entity.Property(e => e.Description).HasMaxLength(255);
                entity.Property(e => e.Name).HasMaxLength(255);

                entity.HasMany(d => d.Permissions).WithMany(p => p.Positions)
                    .UsingEntity<Dictionary<string, object>>(
                        "PositionPermission",
                        r => r.HasOne<Permission>().WithMany()
                            .HasForeignKey("PermissionId")
                            .OnDelete(DeleteBehavior.ClientSetNull)
                            .HasConstraintName("FK__PositionP__Permi__42E1EEFE"),
                        l => l.HasOne<Position>().WithMany()
                            .HasForeignKey("PositionId")
                            .OnDelete(DeleteBehavior.ClientSetNull)
                            .HasConstraintName("FK__PositionP__Posit__41EDCAC5"),
                        j =>
                        {
                            j.HasKey("PositionId", "PermissionId").HasName("PK__Position__8E41F5E9249D5E14");
                            j.ToTable("PositionPermissions");
                            j.IndexerProperty<Guid>("PositionId").HasColumnName("PositionID");
                            j.IndexerProperty<Guid>("PermissionId").HasColumnName("PermissionID");
                        });
            });

            modelBuilder.Entity<RecipeRice>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__RecipeRi__3214EC27F92B3B74");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");
                entity.Property(e => e.CustomerName).HasMaxLength(255);
                entity.Property(e => e.Date).HasColumnType("datetime");
                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");
                entity.Property(e => e.Name).HasMaxLength(255);
                entity.Property(e => e.RecipeNo).HasMaxLength(255);
                entity.Property(e => e.RiceId).HasColumnName("RiceID");

                entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.RecipeRiceCreatedByNavigations)
                    .HasForeignKey(d => d.CreatedBy)
                    .HasConstraintName("FK__RecipeRic__Creat__498EEC8D");

                entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.RecipeRiceLastModifiedByNavigations)
                    .HasForeignKey(d => d.LastModifiedBy)
                    .HasConstraintName("FK__RecipeRic__LastM__4A8310C6");

                entity.HasOne(d => d.Rice).WithMany(p => p.RecipeRices)
                    .HasForeignKey(d => d.RiceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__RecipeRic__RiceI__489AC854");
            });

            modelBuilder.Entity<RecipeRiceDetail>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__RecipeRi__3214EC27D35051F7");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");
                entity.Property(e => e.Percentage).HasColumnType("decimal(18, 0)");
                entity.Property(e => e.RecipeId).HasColumnName("RecipeID");
                entity.Property(e => e.Weight).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.IngredientRice).WithMany(p => p.RecipeRiceDetails)
                    .HasForeignKey(d => d.IngredientRiceId)
                    .HasConstraintName("FK__RecipeRic__Ingre__4C6B5938");

                entity.HasOne(d => d.Recipe).WithMany(p => p.RecipeRiceDetails)
                    .HasForeignKey(d => d.RecipeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__RecipeRic__Recip__4B7734FF");
            });

            modelBuilder.Entity<Rice>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__Rices__3214EC273B7F1BFD");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");
                entity.Property(e => e.Code).HasMaxLength(255);
                entity.Property(e => e.Color).HasMaxLength(255);
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");
                entity.Property(e => e.ExportPrice).HasColumnType("decimal(18, 0)");
                entity.Property(e => e.GradeId).HasColumnName("GradeID");
                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");
                entity.Property(e => e.Name).HasMaxLength(255);
                entity.Property(e => e.OriginId).HasColumnName("OriginID");
                entity.Property(e => e.Price).HasColumnType("decimal(18, 0)");
                entity.Property(e => e.PurchasePrice).HasColumnType("decimal(18, 0)");
                entity.Property(e => e.RiceBoxId).HasColumnName("RiceBoxID");
                entity.Property(e => e.RiceTypeId).HasColumnName("RiceTypeID");
                entity.Property(e => e.Status).HasMaxLength(255);
                entity.Property(e => e.Thumbnail).HasMaxLength(255);
                entity.Property(e => e.Type).HasMaxLength(100);
                entity.Property(e => e.UnitId).HasColumnName("UnitID");

                entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.RiceCreatedByNavigations)
                    .HasForeignKey(d => d.CreatedBy)
                    .HasConstraintName("FK__Rices__CreatedBy__2B0A656D");

                entity.HasOne(d => d.Grade).WithMany(p => p.Rice)
                    .HasForeignKey(d => d.GradeId)
                    .HasConstraintName("FK__Rices__GradeID__44CA3770");

                entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.RiceLastModifiedByNavigations)
                    .HasForeignKey(d => d.LastModifiedBy)
                    .HasConstraintName("FK__Rices__LastModif__2BFE89A6");

                entity.HasOne(d => d.Origin).WithMany(p => p.Rice)
                    .HasForeignKey(d => d.OriginId)
                    .HasConstraintName("FK__Rices__OriginID__45BE5BA9");

                entity.HasOne(d => d.RiceBox).WithMany(p => p.Rice)
                    .HasForeignKey(d => d.RiceBoxId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Rices__RiceBoxID__47A6A41B");

                entity.HasOne(d => d.RiceType).WithMany(p => p.Rice)
                    .HasForeignKey(d => d.RiceTypeId)
                    .HasConstraintName("FK__Rices__RiceTypeI__43D61337");

                entity.HasOne(d => d.Unit).WithMany(p => p.Rice)
                    .HasForeignKey(d => d.UnitId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Rices__UnitID__46B27FE2");
            });

            modelBuilder.Entity<RiceBox>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__RiceBox__3214EC273037E803");

                entity.ToTable("RiceBox");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");
                entity.Property(e => e.AxisX).HasColumnType("decimal(18, 0)");
                entity.Property(e => e.AxisY).HasColumnType("decimal(18, 0)");
                entity.Property(e => e.Capacity).HasColumnType("decimal(18, 0)");
                entity.Property(e => e.Color).HasMaxLength(255);
                entity.Property(e => e.Name).HasMaxLength(255);
            });

            modelBuilder.Entity<RiceGrade>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__RiceGrad__3214EC277F6E6787");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");
                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");
                entity.Property(e => e.Name).HasMaxLength(255);

                entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.RiceGradeCreatedByNavigations)
                    .HasForeignKey(d => d.CreatedBy)
                    .HasConstraintName("FK__RiceGrade__Creat__236943A5");

                entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.RiceGradeLastModifiedByNavigations)
                    .HasForeignKey(d => d.LastModifiedBy)
                    .HasConstraintName("FK__RiceGrade__LastM__245D67DE");
            });

            modelBuilder.Entity<RiceOrigin>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__RiceOrig__3214EC27D38D38E5");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");
                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");
                entity.Property(e => e.OriginName).HasMaxLength(255);

                entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.RiceOriginCreatedByNavigations)
                    .HasForeignKey(d => d.CreatedBy)
                    .HasConstraintName("FK__RiceOrigi__Creat__25518C17");

                entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.RiceOriginLastModifiedByNavigations)
                    .HasForeignKey(d => d.LastModifiedBy)
                    .HasConstraintName("FK__RiceOrigi__LastM__2645B050");
            });

            modelBuilder.Entity<RicePackaging>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__RicePack__3214EC27431C7CD2");

                entity.ToTable("RicePackaging");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");
                entity.Property(e => e.Barcode).HasMaxLength(255);
                entity.Property(e => e.Color).HasMaxLength(255);
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");
                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");
                entity.Property(e => e.Name).HasMaxLength(255);
                entity.Property(e => e.Note)
                    .HasMaxLength(255)
                    .IsFixedLength();
                entity.Property(e => e.PackagingType).HasMaxLength(255);
                entity.Property(e => e.StitchType).HasMaxLength(255);
                entity.Property(e => e.Weight).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.RicePackagingCreatedByNavigations)
                    .HasForeignKey(d => d.CreatedBy)
                    .HasConstraintName("FK__RicePacka__Creat__2739D489");

                entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.RicePackagingLastModifiedByNavigations)
                    .HasForeignKey(d => d.LastModifiedBy)
                    .HasConstraintName("FK__RicePacka__LastM__282DF8C2");
            });

            modelBuilder.Entity<RiceType>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__RiceType__3214EC2783F7572A");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");
                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");

                entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.RiceTypeCreatedByNavigations)
                    .HasForeignKey(d => d.CreatedBy)
                    .HasConstraintName("FK__RiceTypes__Creat__29221CFB");

                entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.RiceTypeLastModifiedByNavigations)
                    .HasForeignKey(d => d.LastModifiedBy)
                    .HasConstraintName("FK__RiceTypes__LastM__2A164134");
            });

            modelBuilder.Entity<SellReceiptDetail>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__SellRece__3214EC27E57EFA10");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");
                entity.Property(e => e.RiceId).HasColumnName("RiceID");
                entity.Property(e => e.SellReceiptId).HasColumnName("SellReceiptID");
                entity.Property(e => e.Subtotal).HasColumnType("decimal(18, 0)");
                entity.Property(e => e.Unit).HasMaxLength(255);
                entity.Property(e => e.UnitPrice).HasColumnType("decimal(18, 0)");
                entity.Property(e => e.Weight).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.Rice).WithMany(p => p.SellReceiptDetails)
                    .HasForeignKey(d => d.RiceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__SellRecei__RiceI__5BAD9CC8");

                entity.HasOne(d => d.SellReceipt).WithMany(p => p.SellReceiptDetails)
                    .HasForeignKey(d => d.SellReceiptId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__SellRecei__SellR__5AB9788F");
            });

            modelBuilder.Entity<SellsReceipt>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__SellsRec__3214EC276394F484");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");
                entity.Property(e => e.BusinessPartnerId).HasColumnName("BusinessPartnerID");
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");
                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");
                entity.Property(e => e.SellNo).HasMaxLength(255);
                entity.Property(e => e.Total).HasColumnType("decimal(18, 0)");
                entity.Property(e => e.WareHouseId).HasColumnName("WareHouseID");

                entity.HasOne(d => d.BusinessPartner).WithMany(p => p.SellsReceipts)
                    .HasForeignKey(d => d.BusinessPartnerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__SellsRece__Busin__59C55456");

                entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.SellsReceiptCreatedByNavigations)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__SellsRece__Creat__3493CFA7");

                entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.SellsReceiptLastModifiedByNavigations)
                    .HasForeignKey(d => d.LastModifiedBy)
                    .HasConstraintName("FK__SellsRece__LastM__3587F3E0");

                entity.HasOne(d => d.WareHouse).WithMany(p => p.SellsReceipts)
                    .HasForeignKey(d => d.WareHouseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__SellsRece__WareH__58D1301D");
            });

            modelBuilder.Entity<Unit>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__Unit__3214EC272A5AF7EA");

                entity.ToTable("Unit");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");
                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");
                entity.Property(e => e.Name).HasMaxLength(255);

                entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.UnitCreatedByNavigations)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Unit__CreatedBy__40058253");

                entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.UnitLastModifiedByNavigations)
                    .HasForeignKey(d => d.LastModifiedBy)
                    .HasConstraintName("FK__Unit__LastModifi__40F9A68C");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__Users__3214EC274465C354");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");
                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");
                entity.Property(e => e.Password).HasMaxLength(255);
                entity.Property(e => e.UserName).HasMaxLength(100);
            });

            modelBuilder.Entity<WareHouse>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__WareHous__3214EC27DD8B5334");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");
                entity.Property(e => e.Address).HasMaxLength(255);
                entity.Property(e => e.Area).HasMaxLength(100);
                entity.Property(e => e.Code).HasMaxLength(50);
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");
                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");
                entity.Property(e => e.Lat).HasMaxLength(255);
                entity.Property(e => e.Logo).HasMaxLength(255);
                entity.Property(e => e.Lon).HasMaxLength(255);
                entity.Property(e => e.Name).HasMaxLength(255);
                entity.Property(e => e.Note).HasMaxLength(255);
                entity.Property(e => e.Phone).HasMaxLength(20);
                entity.Property(e => e.Status).HasMaxLength(255);
                entity.Property(e => e.TaxCode).HasMaxLength(50);

                entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.WareHouseCreatedByNavigations)
                    .HasForeignKey(d => d.CreatedBy)
                    .HasConstraintName("FK__WareHouse__Creat__2CF2ADDF");

                entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.WareHouseLastModifiedByNavigations)
                    .HasForeignKey(d => d.LastModifiedBy)
                    .HasConstraintName("FK__WareHouse__LastM__2DE6D218");
            });

            modelBuilder.Entity<WareHouseEmployee>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__WareHous__3214EC27C1BF4B18");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");
                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");
                entity.Property(e => e.WareHouseId).HasColumnName("WareHouseID");

                entity.HasOne(d => d.Employee).WithMany(p => p.WareHouseEmployees)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__WareHouse__Emplo__4D5F7D71");

                entity.HasOne(d => d.WareHouse).WithMany(p => p.WareHouseEmployees)
                    .HasForeignKey(d => d.WareHouseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__WareHouse__WareH__4E53A1AA");
            });

            modelBuilder.Entity<WareHouseExport>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__WareHous__3214EC27DB3B1FE1");

                entity.ToTable("WareHouseExport");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");
                entity.Property(e => e.BrokerFeeOriginal).HasColumnType("decimal(18, 0)");
                entity.Property(e => e.BrokerFeeRounded).HasColumnType("decimal(18, 0)");
                entity.Property(e => e.BusinessPartnerId).HasColumnName("BusinessPartnerID");
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");
                entity.Property(e => e.Date).HasColumnType("datetime");
                entity.Property(e => e.ExportNo).HasMaxLength(255);
                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");
                entity.Property(e => e.PartnerId).HasColumnName("PartnerID");
                entity.Property(e => e.Total).HasColumnType("decimal(18, 0)");
                entity.Property(e => e.WareHouseId).HasColumnName("WareHouseID");

                entity.HasOne(d => d.BusinessPartner).WithMany(p => p.WareHouseExports)
                    .HasForeignKey(d => d.BusinessPartnerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__WareHouse__Busin__0C85DE4D");

                entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.WareHouseExportCreatedByNavigations)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__WareHouse__Creat__3C34F16F");

                entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.WareHouseExportLastModifiedByNavigations)
                    .HasForeignKey(d => d.LastModifiedBy)
                    .HasConstraintName("FK__WareHouse__LastM__3D2915A8");

                entity.HasOne(d => d.Partner).WithMany(p => p.WareHouseExports)
                    .HasForeignKey(d => d.PartnerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__WareHouse__Partn__0D7A0286");

                entity.HasOne(d => d.WareHouse).WithMany(p => p.WareHouseExports)
                    .HasForeignKey(d => d.WareHouseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__WareHouse__WareH__0E6E26BF");
            });

            modelBuilder.Entity<WareHouseExportDetail>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__WareHous__3214EC27C09EC9ED");

                entity.ToTable("WareHouseExportDetail");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");
                entity.Property(e => e.ExportId).HasColumnName("ExportID");
                entity.Property(e => e.Humidity).HasMaxLength(255);
                entity.Property(e => e.PackingId).HasColumnName("PackingID");
                entity.Property(e => e.RiceId).HasColumnName("RiceID");
                entity.Property(e => e.Subtotal).HasColumnType("decimal(18, 0)");
                entity.Property(e => e.Unit).HasMaxLength(255);
                entity.Property(e => e.UnitPrice).HasColumnType("decimal(18, 0)");
                entity.Property(e => e.Vat).HasColumnType("decimal(18, 0)");
                entity.Property(e => e.Weight).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.Export).WithMany(p => p.WareHouseExportDetails)
                    .HasForeignKey(d => d.ExportId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__WareHouse__Expor__09A971A2");

                entity.HasOne(d => d.Packing).WithMany(p => p.WareHouseExportDetails)
                    .HasForeignKey(d => d.PackingId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__WareHouse__Packi__0A9D95DB");

                entity.HasOne(d => d.Rice).WithMany(p => p.WareHouseExportDetails)
                    .HasForeignKey(d => d.RiceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__WareHouse__RiceI__0B91BA14");
            });

            modelBuilder.Entity<WareHouseExportReceipt>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__WareHous__3214EC275B32789C");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");
                entity.Property(e => e.Amounts).HasColumnType("decimal(18, 0)");
                entity.Property(e => e.BankId).HasColumnName("BankID");
                entity.Property(e => e.BusinessPartnerId).HasColumnName("BusinessPartnerID");
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");
                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");
                entity.Property(e => e.Reseaon).HasMaxLength(255);
                entity.Property(e => e.WareHouseExportId).HasColumnName("WareHouseExportID");

                entity.HasOne(d => d.Bank).WithMany(p => p.WareHouseExportReceipts)
                    .HasForeignKey(d => d.BankId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__WareHouse__BankI__7E37BEF6");

                entity.HasOne(d => d.BusinessPartner).WithMany(p => p.WareHouseExportReceipts)
                    .HasForeignKey(d => d.BusinessPartnerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__WareHouse__Busin__00200768");

                entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.WareHouseExportReceiptCreatedByNavigations)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__WareHouse__Creat__3E1D39E1");

                entity.HasOne(d => d.EmployeeSpendNavigation).WithMany(p => p.WareHouseExportReceiptEmployeeSpendNavigations)
                    .HasForeignKey(d => d.EmployeeSpend)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__WareHouse__Emplo__7F2BE32F");

                entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.WareHouseExportReceiptLastModifiedByNavigations)
                    .HasForeignKey(d => d.LastModifiedBy)
                    .HasConstraintName("FK__WareHouse__LastM__3F115E1A");

                entity.HasOne(d => d.WareHouseExport).WithMany(p => p.WareHouseExportReceipts)
                    .HasForeignKey(d => d.WareHouseExportId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__WareHouse__WareH__01142BA1");
            });

            modelBuilder.Entity<WareHouseImport>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__WareHous__3214EC27F7EF39E5");

                entity.ToTable("WareHouseImport");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");
                entity.Property(e => e.BrokerFeeOriginal).HasColumnType("decimal(18, 0)");
                entity.Property(e => e.BrokerFeeRounded).HasColumnType("decimal(18, 0)");
                entity.Property(e => e.BusinessPartnerId).HasColumnName("BusinessPartnerID");
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");
                entity.Property(e => e.Date).HasColumnType("datetime");
                entity.Property(e => e.ImportNo).HasMaxLength(255);
                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");
                entity.Property(e => e.PartnerId).HasColumnName("PartnerID");
                entity.Property(e => e.Total).HasColumnType("decimal(18, 0)");
                entity.Property(e => e.WareHouseId).HasColumnName("WareHouseID");

                entity.HasOne(d => d.BusinessPartner).WithMany(p => p.WareHouseImports)
                    .HasForeignKey(d => d.BusinessPartnerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__WareHouse__Busin__5224328E");

                entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.WareHouseImportCreatedByNavigations)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__WareHouse__Creat__30C33EC3");

                entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.WareHouseImportLastModifiedByNavigations)
                    .HasForeignKey(d => d.LastModifiedBy)
                    .HasConstraintName("FK__WareHouse__LastM__31B762FC");

                entity.HasOne(d => d.Partner).WithMany(p => p.WareHouseImports)
                    .HasForeignKey(d => d.PartnerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__WareHouse__Partn__531856C7");

                entity.HasOne(d => d.WareHouse).WithMany(p => p.WareHouseImports)
                    .HasForeignKey(d => d.WareHouseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__WareHouse__WareH__51300E55");
            });

            modelBuilder.Entity<WareHouseImportDetail>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__WareHous__3214EC272A87FCE0");

                entity.ToTable("WareHouseImportDetail");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");
                entity.Property(e => e.Humidity).HasMaxLength(255);
                entity.Property(e => e.ImportId).HasColumnName("ImportID");
                entity.Property(e => e.RiceId).HasColumnName("RiceID");
                entity.Property(e => e.RiceboxId).HasColumnName("RiceboxID");
                entity.Property(e => e.Subtotal).HasColumnType("decimal(18, 0)");
                entity.Property(e => e.Unit).HasMaxLength(255);
                entity.Property(e => e.UnitPrice).HasColumnType("decimal(18, 0)");
                entity.Property(e => e.Vat).HasColumnType("decimal(18, 0)");
                entity.Property(e => e.Weight).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.Import).WithMany(p => p.WareHouseImportDetails)
                    .HasForeignKey(d => d.ImportId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__WareHouse__Impor__540C7B00");

                entity.HasOne(d => d.Rice).WithMany(p => p.WareHouseImportDetails)
                    .HasForeignKey(d => d.RiceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__WareHouse__RiceI__55009F39");

                entity.HasOne(d => d.Ricebox).WithMany(p => p.WareHouseImportDetails)
                    .HasForeignKey(d => d.RiceboxId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__WareHouse__Riceb__55F4C372");
            });

            modelBuilder.Entity<WareHouseImportReceipt>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__WareHous__3214EC27B4706A5A");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");
                entity.Property(e => e.Amounts).HasColumnType("decimal(18, 0)");
                entity.Property(e => e.BankId).HasColumnName("BankID");
                entity.Property(e => e.BusinessPartnerId).HasColumnName("BusinessPartnerID");
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");
                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");
                entity.Property(e => e.Reseaon).HasMaxLength(255);
                entity.Property(e => e.WareHouseImportId).HasColumnName("WareHouseImportID");

                entity.HasOne(d => d.Bank).WithMany(p => p.WareHouseImportReceipts)
                    .HasForeignKey(d => d.BankId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__WareHouse__BankI__05D8E0BE");

                entity.HasOne(d => d.BusinessPartner).WithMany(p => p.WareHouseImportReceipts)
                    .HasForeignKey(d => d.BusinessPartnerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__WareHouse__Busin__07C12930");

                entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.WareHouseImportReceiptCreatedByNavigations)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__WareHouse__Creat__3864608B");

                entity.HasOne(d => d.EmployeeSpendNavigation).WithMany(p => p.WareHouseImportReceiptEmployeeSpendNavigations)
                    .HasForeignKey(d => d.EmployeeSpend)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__WareHouse__Emplo__06CD04F7");

                entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.WareHouseImportReceiptLastModifiedByNavigations)
                    .HasForeignKey(d => d.LastModifiedBy)
                    .HasConstraintName("FK__WareHouse__LastM__395884C4");

                entity.HasOne(d => d.WareHouseImport).WithMany(p => p.WareHouseImportReceipts)
                    .HasForeignKey(d => d.WareHouseImportId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__WareHouse__WareH__04E4BC85");
            });

            modelBuilder.Entity<WareHouseProduct>(entity =>
            {
                entity.HasKey(e => new { e.WareHouseId, e.RiceId }).HasName("PK__WareHous__882A47AFBDA0C5D7");

                entity.Property(e => e.WareHouseId).HasColumnName("WareHouseID");
                entity.Property(e => e.RiceId).HasColumnName("RiceID");
                entity.Property(e => e.Quantity).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.Rice).WithMany(p => p.WareHouseProducts)
                    .HasForeignKey(d => d.RiceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__WareHouse__RiceI__503BEA1C");

                entity.HasOne(d => d.WareHouse).WithMany(p => p.WareHouseProducts)
                    .HasForeignKey(d => d.WareHouseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__WareHouse__WareH__4F47C5E3");
            });

            modelBuilder.Entity<WareHouseTranfer>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__WareHous__3214EC279CD93CB2");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");
                entity.Property(e => e.FromWareHouseId).HasColumnName("FromWareHouseID");
                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");
                entity.Property(e => e.ToWareHouseId).HasColumnName("ToWareHouseID");
                entity.Property(e => e.Total).HasColumnType("decimal(18, 0)");
                entity.Property(e => e.TranferNo).HasMaxLength(255);

                entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.WareHouseTranferCreatedByNavigations)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__WareHouse__Creat__367C1819");

                entity.HasOne(d => d.FromWareHouse).WithMany(p => p.WareHouseTranferFromWareHouses)
                    .HasForeignKey(d => d.FromWareHouseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__WareHouse__FromW__18EBB532");

                entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.WareHouseTranferLastModifiedByNavigations)
                    .HasForeignKey(d => d.LastModifiedBy)
                    .HasConstraintName("FK__WareHouse__LastM__37703C52");

                entity.HasOne(d => d.ToWareHouse).WithMany(p => p.WareHouseTranferToWareHouses)
                    .HasForeignKey(d => d.ToWareHouseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__WareHouse__ToWar__19DFD96B");
            });

            modelBuilder.Entity<WareHouseTransferDetail>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__WareHous__3214EC27B750F47F");

                entity.ToTable("WareHouseTransferDetail");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");
                entity.Property(e => e.RiceId).HasColumnName("RiceID");
                entity.Property(e => e.Subtotal).HasColumnType("decimal(18, 0)");
                entity.Property(e => e.Unit).HasMaxLength(255);
                entity.Property(e => e.UnitPrice).HasColumnType("decimal(18, 0)");
                entity.Property(e => e.WareHouseTranferId).HasColumnName("WareHouseTranferID");
                entity.Property(e => e.Weight).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.Rice).WithMany(p => p.WareHouseTransferDetails)
                    .HasForeignKey(d => d.RiceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__WareHouse__RiceI__1BC821DD");

                entity.HasOne(d => d.WareHouseTranfer).WithMany(p => p.WareHouseTransferDetails)
                    .HasForeignKey(d => d.WareHouseTranferId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__WareHouse__WareH__1AD3FDA4");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    }
}
