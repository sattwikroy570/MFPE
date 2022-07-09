using Microsoft.EntityFrameworkCore.Migrations;

namespace CustomerMicroservice.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "customers",
                columns: table => new
                {
                    CustomerId = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Address = table.Column<string>(nullable: false),
                    DateOfBirth = table.Column<string>(nullable: false),
                    PanNumber = table.Column<string>(maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customers", x => x.CustomerId);
                });

            migrationBuilder.InsertData(
                table: "customers",
                columns: new[] { "CustomerId", "Address", "DateOfBirth", "Name", "PanNumber" },
                values: new object[] { "JhonSmith", "Dumdum", "05-09-1997", "Jhonathon Smith", "CGLBP002" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "customers");
        }
    }
}
