using Microsoft.EntityFrameworkCore.Migrations;

namespace Demo.Migrations
{
    public partial class SeededProducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "Content",
                table: "Products",
                columns: new[] { "Id", "Name", "OwnerKey" },
                values: new object[,]
                {
                    { 1, "one", "DFE27E47-2BBE-4C7D-B419-25AC7835881F" },
                    { 2, "two", "DFE27E47-2BBE-4C7D-B419-25AC7835881F" },
                    { 3, "three", "DFE27E47-2BBE-4C7D-B419-25AC7835881F" },
                    { 4, "square", "C8A9EFD2-F350-4437-ADA0-1CCB8C0DFA55" },
                    { 5, "pointy", "C8A9EFD2-F350-4437-ADA0-1CCB8C0DFA55" },
                    { 6, "round", "C8A9EFD2-F350-4437-ADA0-1CCB8C0DFA55" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Content",
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "Content",
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "Content",
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "Content",
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                schema: "Content",
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                schema: "Content",
                table: "Products",
                keyColumn: "Id",
                keyValue: 6);
        }
    }
}
