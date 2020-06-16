using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Data.Models
{
    public partial class CashManageStoreContext : DbContext
    {
        public CashManageStoreContext()
        {
        }

        public CashManageStoreContext(DbContextOptions<CashManageStoreContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Account { get; set; }
        public virtual DbSet<CashTransaction> CashTransaction { get; set; }
        public virtual DbSet<CashType> CashType { get; set; }
        public virtual DbSet<Invoice> Invoice { get; set; }
        public virtual DbSet<Register> Register { get; set; }
        public virtual DbSet<RegisterCashTransaction> RegisterCashTransaction { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<Shift> Shift { get; set; }
        public virtual DbSet<Store> Store { get; set; }
        public virtual DbSet<StoreCash> StoreCash { get; set; }
        public virtual DbSet<StoreEmployee> StoreEmployee { get; set; }
        public virtual DbSet<TransactionType> TransactionType { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=CashManagementStore;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Account>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Status).HasMaxLength(10);

                entity.Property(e => e.TimeCreated).HasColumnType("datetime");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdRoleNavigation)
                    .WithMany(p => p.Account)
                    .HasForeignKey(d => d.IdRole)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Account_Role");
            });

            modelBuilder.Entity<CashTransaction>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Cash).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.CreatedTime).HasColumnType("datetime");

                entity.HasOne(d => d.RegisterCashTransaction)
                    .WithMany(p => p.CashTransaction)
                    .HasForeignKey(d => d.RegisterCashTransactionId)
                    .HasConstraintName("FK_CashTransaction_RegisterCashTransaction");

                entity.HasOne(d => d.TransactionType)
                    .WithMany(p => p.CashTransaction)
                    .HasForeignKey(d => d.TransactionTypeId)
                    .HasConstraintName("FK_CashTransaction_TransactionType");
            });

            modelBuilder.Entity<CashType>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Description).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Invoice>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Cash).HasMaxLength(10);

                entity.Property(e => e.CreateTime).HasMaxLength(10);

                entity.Property(e => e.Name).HasMaxLength(10);

                entity.HasOne(d => d.CashTransaction)
                    .WithMany(p => p.Invoice)
                    .HasForeignKey(d => d.CashTransactionId)
                    .HasConstraintName("FK_Invoice_CashTransaction");
            });

            modelBuilder.Entity<Register>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Status).HasMaxLength(50);

                entity.Property(e => e.TimeCreated).HasColumnType("datetime");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.Register)
                    .HasForeignKey(d => d.StoreId)
                    .HasConstraintName("FK_Register_Store");
            });

            modelBuilder.Entity<RegisterCashTransaction>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreatedTime).HasColumnType("datetime");

                entity.Property(e => e.Note).HasMaxLength(50);

                entity.Property(e => e.ShiftId).HasColumnName("ShiftID");

                entity.HasOne(d => d.Register)
                    .WithMany(p => p.RegisterCashTransaction)
                    .HasForeignKey(d => d.RegisterId)
                    .HasConstraintName("FK_RegisterCashTransaction_Register");

                entity.HasOne(d => d.Shift)
                    .WithMany(p => p.RegisterCashTransaction)
                    .HasForeignKey(d => d.ShiftId)
                    .HasConstraintName("FK_RegisterCashTransaction_Shift");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Role1)
                    .HasColumnName("Role")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Shift>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Description).HasMaxLength(10);
            });

            modelBuilder.Entity<Store>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Address).HasMaxLength(150);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Phone).HasMaxLength(50);

                entity.Property(e => e.TimeCreated).HasColumnType("datetime");
            });

            modelBuilder.Entity<StoreCash>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CashAccount).HasColumnType("decimal(10, 0)");

                entity.Property(e => e.TimeCreated).HasColumnType("datetime");

                entity.HasOne(d => d.CashType)
                    .WithMany(p => p.StoreCash)
                    .HasForeignKey(d => d.CashTypeId)
                    .HasConstraintName("FK_StoreCash_CashType");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.StoreCash)
                    .HasForeignKey(d => d.StoreId)
                    .HasConstraintName("FK_CashBox_Store");
            });

            modelBuilder.Entity<StoreEmployee>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreatedTime).HasColumnType("datetime");

                entity.HasOne(d => d.IdAccountNavigation)
                    .WithMany(p => p.StoreEmployee)
                    .HasForeignKey(d => d.IdAccount)
                    .HasConstraintName("FK_StoreEmployee_Account");
            
            });

            modelBuilder.Entity<TransactionType>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Description).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);
            });
        }
    }
}
