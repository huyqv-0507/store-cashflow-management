using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class updateDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StoreEmployee_Store",
                table: "StoreEmployee");

            migrationBuilder.DropIndex(
                name: "IX_StoreEmployee_IdStore",
                table: "StoreEmployee");

            migrationBuilder.AddColumn<int>(
                name: "StoreId",
                table: "StoreEmployee",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Store",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_StoreEmployee_StoreId",
                table: "StoreEmployee",
                column: "StoreId");

            migrationBuilder.AddForeignKey(
                name: "FK_StoreEmployee_Store_StoreId",
                table: "StoreEmployee",
                column: "StoreId",
                principalTable: "Store",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StoreEmployee_Store_StoreId",
                table: "StoreEmployee");

            migrationBuilder.DropIndex(
                name: "IX_StoreEmployee_StoreId",
                table: "StoreEmployee");

            migrationBuilder.DropColumn(
                name: "StoreId",
                table: "StoreEmployee");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Store");

            migrationBuilder.CreateIndex(
                name: "IX_StoreEmployee_IdStore",
                table: "StoreEmployee",
                column: "IdStore");

            migrationBuilder.AddForeignKey(
                name: "FK_StoreEmployee_Store",
                table: "StoreEmployee",
                column: "IdStore",
                principalTable: "Store",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
