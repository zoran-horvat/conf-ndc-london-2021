using Microsoft.EntityFrameworkCore.Migrations;

namespace Demo.Migrations
{
    public partial class AddedFriendConnections : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Friends",
                schema: "Content",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OwnerKey = table.Column<string>(nullable: false),
                    FriendKey = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Friends", x => x.Id);
                });

            migrationBuilder.InsertData(
                schema: "Content",
                table: "Friends",
                columns: new[] { "Id", "FriendKey", "OwnerKey" },
                values: new object[] { 1, "DFE27E47-2BBE-4C7D-B419-25AC7835881F", "C8A9EFD2-F350-4437-ADA0-1CCB8C0DFA55" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Friends",
                schema: "Content");
        }
    }
}
