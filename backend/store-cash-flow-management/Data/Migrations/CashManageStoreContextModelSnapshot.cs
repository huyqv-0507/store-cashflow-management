﻿// <auto-generated />
using System;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Data.Migrations
{
    [DbContext(typeof(CashManageStoreContext))]
    partial class CashManageStoreContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Data.Models.Account", b =>
                {
                    b.Property<long>("Id");

                    b.Property<int>("IdRole");

                    b.Property<int?>("IdStore");

                    b.Property<string>("Name")
                        .HasMaxLength(50);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Status")
                        .HasMaxLength(10);

                    b.Property<DateTime?>("TimeCreated")
                        .HasColumnType("datetime");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.HasIndex("IdRole");

                    b.ToTable("Account");
                });

            modelBuilder.Entity("Data.Models.CashTransaction", b =>
                {
                    b.Property<long>("Id");

                    b.Property<decimal?>("Cash")
                        .HasColumnType("decimal(18, 0)");

                    b.Property<DateTime?>("CreatedTime")
                        .HasColumnType("datetime");

                    b.Property<long?>("RegisterCashTransactionId");

                    b.Property<int?>("TransactionTypeId");

                    b.HasKey("Id");

                    b.HasIndex("RegisterCashTransactionId");

                    b.HasIndex("TransactionTypeId");

                    b.ToTable("CashTransaction");
                });

            modelBuilder.Entity("Data.Models.CashType", b =>
                {
                    b.Property<int>("Id");

                    b.Property<string>("Description")
                        .HasMaxLength(50);

                    b.Property<string>("Name")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("CashType");
                });

            modelBuilder.Entity("Data.Models.Invoice", b =>
                {
                    b.Property<int>("Id");

                    b.Property<string>("Cash")
                        .HasMaxLength(10);

                    b.Property<long?>("CashTransactionId");

                    b.Property<string>("CreateTime")
                        .HasMaxLength(10);

                    b.Property<string>("Name")
                        .HasMaxLength(10);

                    b.HasKey("Id");

                    b.HasIndex("CashTransactionId");

                    b.ToTable("Invoice");
                });

            modelBuilder.Entity("Data.Models.Register", b =>
                {
                    b.Property<int>("Id");

                    b.Property<string>("Name")
                        .HasMaxLength(50);

                    b.Property<string>("Status")
                        .HasMaxLength(50);

                    b.Property<int?>("StoreId");

                    b.Property<DateTime?>("TimeCreated")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.HasIndex("StoreId");

                    b.ToTable("Register");
                });

            modelBuilder.Entity("Data.Models.RegisterCashTransaction", b =>
                {
                    b.Property<long>("Id");

                    b.Property<DateTime?>("CreatedTime")
                        .HasColumnType("datetime");

                    b.Property<long?>("EmployeeId");

                    b.Property<string>("Note")
                        .HasMaxLength(50);

                    b.Property<int?>("RegisterId");

                    b.Property<int?>("ShiftId")
                        .HasColumnName("ShiftID");

                    b.HasKey("Id");

                    b.HasIndex("RegisterId");

                    b.HasIndex("ShiftId");

                    b.ToTable("RegisterCashTransaction");
                });

            modelBuilder.Entity("Data.Models.Role", b =>
                {
                    b.Property<int>("Id");

                    b.Property<string>("Role1")
                        .HasColumnName("Role")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Role");
                });

            modelBuilder.Entity("Data.Models.Shift", b =>
                {
                    b.Property<int>("Id");

                    b.Property<string>("Description")
                        .HasMaxLength(10);

                    b.HasKey("Id");

                    b.ToTable("Shift");
                });

            modelBuilder.Entity("Data.Models.Store", b =>
                {
                    b.Property<int>("Id");

                    b.Property<string>("Address")
                        .HasMaxLength(150);

                    b.Property<string>("Name")
                        .HasMaxLength(50);

                    b.Property<DateTime?>("TimeCreated")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.ToTable("Store");
                });

            modelBuilder.Entity("Data.Models.StoreCash", b =>
                {
                    b.Property<int>("Id");

                    b.Property<decimal?>("CashAccount")
                        .HasColumnType("decimal(10, 0)");

                    b.Property<int?>("CashTypeId");

                    b.Property<int?>("StoreId");

                    b.Property<DateTime?>("TimeCreated")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.HasIndex("CashTypeId");

                    b.HasIndex("StoreId");

                    b.ToTable("StoreCash");
                });

            modelBuilder.Entity("Data.Models.StoreEmployee", b =>
                {
                    b.Property<long>("Id");

                    b.Property<DateTime?>("CreatedTime")
                        .HasColumnType("datetime");

                    b.Property<long?>("IdAccount");

                    b.Property<int?>("IdStore");

                    b.HasKey("Id");

                    b.HasIndex("IdAccount");

                    b.HasIndex("IdStore");

                    b.ToTable("StoreEmployee");
                });

            modelBuilder.Entity("Data.Models.TransactionType", b =>
                {
                    b.Property<int>("Id");

                    b.Property<string>("Description")
                        .HasMaxLength(50);

                    b.Property<string>("Name")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("TransactionType");
                });

            modelBuilder.Entity("Data.Models.Account", b =>
                {
                    b.HasOne("Data.Models.Role", "IdRoleNavigation")
                        .WithMany("Account")
                        .HasForeignKey("IdRole")
                        .HasConstraintName("FK_Account_Role");
                });

            modelBuilder.Entity("Data.Models.CashTransaction", b =>
                {
                    b.HasOne("Data.Models.RegisterCashTransaction", "RegisterCashTransaction")
                        .WithMany("CashTransaction")
                        .HasForeignKey("RegisterCashTransactionId")
                        .HasConstraintName("FK_CashTransaction_RegisterCashTransaction");

                    b.HasOne("Data.Models.TransactionType", "TransactionType")
                        .WithMany("CashTransaction")
                        .HasForeignKey("TransactionTypeId")
                        .HasConstraintName("FK_CashTransaction_TransactionType");
                });

            modelBuilder.Entity("Data.Models.Invoice", b =>
                {
                    b.HasOne("Data.Models.CashTransaction", "CashTransaction")
                        .WithMany("Invoice")
                        .HasForeignKey("CashTransactionId")
                        .HasConstraintName("FK_Invoice_CashTransaction");
                });

            modelBuilder.Entity("Data.Models.Register", b =>
                {
                    b.HasOne("Data.Models.Store", "Store")
                        .WithMany("Register")
                        .HasForeignKey("StoreId")
                        .HasConstraintName("FK_Register_Store");
                });

            modelBuilder.Entity("Data.Models.RegisterCashTransaction", b =>
                {
                    b.HasOne("Data.Models.Register", "Register")
                        .WithMany("RegisterCashTransaction")
                        .HasForeignKey("RegisterId")
                        .HasConstraintName("FK_RegisterCashTransaction_Register");

                    b.HasOne("Data.Models.Shift", "Shift")
                        .WithMany("RegisterCashTransaction")
                        .HasForeignKey("ShiftId")
                        .HasConstraintName("FK_RegisterCashTransaction_Shift");
                });

            modelBuilder.Entity("Data.Models.StoreCash", b =>
                {
                    b.HasOne("Data.Models.CashType", "CashType")
                        .WithMany("StoreCash")
                        .HasForeignKey("CashTypeId")
                        .HasConstraintName("FK_StoreCash_CashType");

                    b.HasOne("Data.Models.Store", "Store")
                        .WithMany("StoreCash")
                        .HasForeignKey("StoreId")
                        .HasConstraintName("FK_CashBox_Store");
                });

            modelBuilder.Entity("Data.Models.StoreEmployee", b =>
                {
                    b.HasOne("Data.Models.Account", "IdAccountNavigation")
                        .WithMany("StoreEmployee")
                        .HasForeignKey("IdAccount")
                        .HasConstraintName("FK_StoreEmployee_Account");

                    b.HasOne("Data.Models.Store", "IdStoreNavigation")
                        .WithMany("StoreEmployee")
                        .HasForeignKey("IdStore")
                        .HasConstraintName("FK_StoreEmployee_Store");
                });
#pragma warning restore 612, 618
        }
    }
}
