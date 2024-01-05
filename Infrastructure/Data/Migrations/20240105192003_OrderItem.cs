using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class OrderItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ItemOrder_ProductName",
                table: "OrderItems",
                newName: "ItemOrdered_ProductName");

            migrationBuilder.RenameColumn(
                name: "ItemOrder_ProductItemId",
                table: "OrderItems",
                newName: "ItemOrdered_ProductItemId");

            migrationBuilder.RenameColumn(
                name: "ItemOrder_PictureUrl",
                table: "OrderItems",
                newName: "ItemOrdered_PictureUrl");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Orders",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ItemOrdered_ProductName",
                table: "OrderItems",
                newName: "ItemOrder_ProductName");

            migrationBuilder.RenameColumn(
                name: "ItemOrdered_ProductItemId",
                table: "OrderItems",
                newName: "ItemOrder_ProductItemId");

            migrationBuilder.RenameColumn(
                name: "ItemOrdered_PictureUrl",
                table: "OrderItems",
                newName: "ItemOrder_PictureUrl");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Orders",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true);
        }
    }
}
