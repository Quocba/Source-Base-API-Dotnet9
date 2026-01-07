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




        public virtual DbSet<Department> Departments { get; set; }

        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Permission> Permissions { get; set; }

        public virtual DbSet<Position> Positions { get; set; }


        public virtual DbSet<User> Users { get; set; }





        //public virtual DbSet<WareHouseRice> WareHouseRice { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>(entity =>
            {
                entity.HasOne(d => d.CreatedByNavigation)
                      .WithMany()
                      .HasForeignKey(d => d.CreatedBy)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.LastModifiedByNavigation)
                      .WithMany()
                      .HasForeignKey(d => d.LastModifiedBy)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasMany(d => d.Employees)
                      .WithOne(e => e.Department)
                      .HasForeignKey(e => e.DepartmentId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    }
}
