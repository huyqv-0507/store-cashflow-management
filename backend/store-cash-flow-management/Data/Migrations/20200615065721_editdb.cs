using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class editdb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CashType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    Description = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CashType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Role = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Shift",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Description = table.Column<string>(maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shift", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Store",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    Address = table.Column<string>(maxLength: 150, nullable: true),
                    TimeCreated = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Store", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TransactionType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Description = table.Column<string>(maxLength: 50, nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Account",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false),
                    Username = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    Password = table.Column<string>(maxLength: 50, nullable: false),
                    IdRole = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    Status = table.Column<string>(maxLength: 10, nullable: true),
                    TimeCreated = table.Column<DateTime>(type: "datetime", nullable: true),
                    IdStore = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Account_Role",
                        column: x => x.IdRole,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Register",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    TimeCreated = table.Column<DateTime>(type: "datetime", nullable: true),
                    Status = table.Column<string>(maxLength: 50, nullable: true),
                    StoreId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Register", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Register_Store",
                        column: x => x.StoreId,
                        principalTable: "Store",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StoreCash",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    StoreId = table.Column<int>(nullable: true),
                    TimeCreated = table.Column<DateTime>(type: "datetime", nullable: true),
                    CashTypeId = table.Column<int>(nullable: true),
                    CashAccount = table.Column<decimal>(type: "decimal(10, 0)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoreCash", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StoreCash_CashType",
                        column: x => x.CashTypeId,
                        principalTable: "CashType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CashBox_Store",
                        column: x => x.StoreId,
                        principalTable: "Store",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StoreEmployee",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false),
                    IdStore = table.Column<int>(nullable: true),
                    IdAccount = table.Column<long>(nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoreEmployee", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StoreEmployee_Account",
                        column: x => x.IdAccount,
                        principalTable: "Account",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StoreEmployee_Store",
                        column: x => x.IdStore,
                        principalTable: "Store",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RegisterCashTransaction",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false),
                    EmployeeId = table.Column<long>(nullable: true),
                    Note = table.Column<string>(maxLength: 50, nullable: true),
                    ShiftID = table.Column<int>(nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    RegisterId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegisterCashTransaction", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RegisterCashTransaction_Register",
                        column: x => x.RegisterId,
                        principalTable: "Register",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RegisterCashTransaction_Shift",
                        column: x => x.ShiftID,
                        principalTable: "Shift",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CashTransaction",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false),
                    Cash = table.Column<decimal>(type: "decimal(18, 0)", nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    TransactionTypeId = table.Column<int>(nullable: true),
                    RegisterCashTransactionId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CashTransaction", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CashTransaction_RegisterCashTransaction",
                        column: x => x.RegisterCashTransactionId,
                        principalTable: "RegisterCashTransaction",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CashTransaction_TransactionType",
                        column: x => x.TransactionTypeId,
                        principalTable: "TransactionType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Invoice",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 10, nullable: true),
                    Cash = table.Column<string>(maxLength: 10, nullable: true),
                    CreateTime = table.Column<string>(maxLength: 10, nullable: true),
                    CashTransactionId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoice", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Invoice_CashTransaction",
                        column: x => x.CashTransactionId,
                        principalTable: "CashTransaction",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Account_IdRole",
                table: "Account",
                column: "IdRole");

            migrationBuilder.CreateIndex(
                name: "IX_CashTransaction_RegisterCashTransactionId",
                table: "CashTransaction",
                column: "RegisterCashTransactionId");

            migrationBuilder.CreateIndex(
                name: "IX_CashTransaction_TransactionTypeId",
                table: "CashTransaction",
                column: "TransactionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_CashTransactionId",
                table: "Invoice",
                column: "CashTransactionId");

            migrationBuilder.CreateIndex(
                name: "IX_Register_StoreId",
                table: "Register",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_RegisterCashTransaction_RegisterId",
                table: "RegisterCashTransaction",
                column: "RegisterId");

            migrationBuilder.CreateIndex(
                name: "IX_RegisterCashTransaction_ShiftID",
                table: "RegisterCashTransaction",
                column: "ShiftID");

            migrationBuilder.CreateIndex(
                name: "IX_StoreCash_CashTypeId",
                table: "StoreCash",
                column: "CashTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_StoreCash_StoreId",
                table: "StoreCash",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_StoreEmployee_IdAccount",
                table: "StoreEmployee",
                column: "IdAccount");

            migrationBuilder.CreateIndex(
                name: "IX_StoreEmployee_IdStore",
                table: "StoreEmployee",
                column: "IdStore");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Invoice");

            migrationBuilder.DropTable(
                name: "StoreCash");

            migrationBuilder.DropTable(
                name: "StoreEmployee");

            migrationBuilder.DropTable(
                name: "CashTransaction");

            migrationBuilder.DropTable(
                name: "CashType");

            migrationBuilder.DropTable(
                name: "Account");

            migrationBuilder.DropTable(
                name: "RegisterCashTransaction");

            migrationBuilder.DropTable(
                name: "TransactionType");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "Register");

            migrationBuilder.DropTable(
                name: "Shift");

            migrationBuilder.DropTable(
                name: "Store");
        }
    }
}
