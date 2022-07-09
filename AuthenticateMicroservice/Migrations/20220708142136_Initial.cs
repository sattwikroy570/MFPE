using Microsoft.EntityFrameworkCore.Migrations;

namespace AuthenticateMicroservice.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "clientList",
                columns: table => new
                {
                    UserName = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false),
                    Roles = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clientList", x => x.UserName);
                });

            migrationBuilder.InsertData(
                table: "clientList",
                columns: new[] { "UserName", "Password", "Roles" },
                values: new object[] { "Manager", "1234", "Employee" });

            migrationBuilder.InsertData(
                table: "clientList",
                columns: new[] { "UserName", "Password", "Roles" },
                values: new object[] { "JhonSmith", "0000", "Customer" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "clientList");
        }
    }
}
