using Microsoft.EntityFrameworkCore.Migrations;

namespace OrderDisplay.Data.Migrations
{
    public partial class Changeorders : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Orders_OrderPurchaseOrderId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_OrderPurchaseOrderId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "OrderPurchaseOrderId",
                table: "Orders");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OrderPurchaseOrderId",
                table: "Orders",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_OrderPurchaseOrderId",
                table: "Orders",
                column: "OrderPurchaseOrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Orders_OrderPurchaseOrderId",
                table: "Orders",
                column: "OrderPurchaseOrderId",
                principalTable: "Orders",
                principalColumn: "PurchaseOrderId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
