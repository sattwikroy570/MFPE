using Microsoft.EntityFrameworkCore.Migrations;

namespace AccountMicroservice.Migrations
{
    public partial class Data : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "accountStatements",
                column: "AccountId",
                values: new object[]
                {
                    202,
                    201
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "Id", "Balance" },
                values: new object[,]
                {
                    { 201, 1000.0 },
                    { 202, 500.0 }
                });

            migrationBuilder.InsertData(
                table: "customerAccounts",
                columns: new[] { "CustomerId", "CurrentAccountId", "SavingsAccountId" },
                values: new object[] { "JhonSmith", 201, 202 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "accountStatements",
                keyColumn: "AccountId",
                keyValue: 201);

            migrationBuilder.DeleteData(
                table: "accountStatements",
                keyColumn: "AccountId",
                keyValue: 202);

            migrationBuilder.DeleteData(
                table: "accounts",
                keyColumn: "Id",
                keyValue: 201);

            migrationBuilder.DeleteData(
                table: "accounts",
                keyColumn: "Id",
                keyValue: 202);

            migrationBuilder.DeleteData(
                table: "customerAccounts",
                keyColumn: "CustomerId",
                keyValue: "JhonSmith");
        }
    }
}
