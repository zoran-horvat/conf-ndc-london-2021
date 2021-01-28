using Microsoft.EntityFrameworkCore.Migrations;

namespace Demo.Migrations
{
    public partial class AddedProductModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Content");

            migrationBuilder.CreateTable(
                name: "Products",
                schema: "Content",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.UpdateData(
                schema: "Authentication",
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "UserName",
                value: "me");

            migrationBuilder.UpdateData(
                schema: "Authentication",
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "UserName",
                value: "neighbor");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products",
                schema: "Content");

            migrationBuilder.UpdateData(
                schema: "Authentication",
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "UserName",
                value: "me@home");

            migrationBuilder.UpdateData(
                schema: "Authentication",
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "UserName",
                value: "neighbour@home");
        }
    }
}
