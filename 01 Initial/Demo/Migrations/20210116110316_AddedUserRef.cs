using Microsoft.EntityFrameworkCore.Migrations;

namespace Demo.Migrations
{
    public partial class AddedUserRef : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OwnerKey",
                schema: "Content",
                table: "Products",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Key",
                schema: "Authentication",
                table: "Users",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                schema: "Authentication",
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Key",
                value: "DFE27E47-2BBE-4C7D-B419-25AC7835881F");

            migrationBuilder.UpdateData(
                schema: "Authentication",
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Key",
                value: "C8A9EFD2-F350-4437-ADA0-1CCB8C0DFA55");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OwnerKey",
                schema: "Content",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Key",
                schema: "Authentication",
                table: "Users");
        }
    }
}
