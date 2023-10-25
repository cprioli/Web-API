using Microsoft.EntityFrameworkCore.Migrations;

namespace MyCustomer.Migrations
{
    public partial class ChangeDateObjectName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Customers",
                newName: "CreateDate");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CreateDate",
                table: "Customers",
                newName: "Date");
        }
    }
}
