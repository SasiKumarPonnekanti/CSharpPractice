using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Cs_RestaurentApp.Models
{
    public partial class RestaurentContext : DbContext
    {
        public RestaurentContext()
        {
        }

        public RestaurentContext(DbContextOptions<RestaurentContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Catogiry> Catogiries { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<DineTable> DineTables { get; set; }
        public virtual DbSet<Dish> Dishes { get; set; }
        public virtual DbSet<Item> Items { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=Restaurent;Integrated Security=SSPI");
//            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Catogiry>(entity =>
            {
                entity.ToTable("Catogiry");

                entity.Property(e => e.CatogiryId).ValueGeneratedNever();

                entity.Property(e => e.CatogiryName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.BillId)
                    .HasName("PK__customer__11F2FC6AB7A6D318");

                entity.ToTable("customer");

                entity.Property(e => e.CustomerName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Customer_Name");

                entity.Property(e => e.Phone)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("phone");

                entity.Property(e => e.VisitedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("visited_at");
            });

            modelBuilder.Entity<DineTable>(entity =>
            {
                entity.HasKey(e => e.TableNo)
                    .HasName("PK__DineTabl__7D5F09DDC62C4FCE");

                entity.ToTable("DineTable");

                entity.Property(e => e.TableNo).ValueGeneratedNever();
            });

            modelBuilder.Entity<Dish>(entity =>
            {
                entity.Property(e => e.DishId)
                    .ValueGeneratedNever()
                    .HasColumnName("Dish_Id");

                entity.Property(e => e.DishName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Dish_Name");
            });

            modelBuilder.Entity<Item>(entity =>
            {
                entity.HasKey(e => e.OrderNo)
                    .HasName("PK__Items__C3907C74D7A4152F");

                entity.Property(e => e.ItemId).HasColumnName("Item_Id");

                entity.Property(e => e.ItemName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Item_Name");

                entity.HasOne(d => d.Bill)
                    .WithMany(p => p.Items)
                    .HasForeignKey(d => d.BillId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Items__BillId__25869641");

                entity.HasOne(d => d.ItemNavigation)
                    .WithMany(p => p.Items)
                    .HasForeignKey(d => d.ItemId)
                    .HasConstraintName("FK__Items__Item_Id__29572725");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
