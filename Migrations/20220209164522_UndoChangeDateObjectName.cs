using Microsoft.EntityFrameworkCore.Migrations;

namespace MyCustomer.Migrations
{
    public partial class UndoChangeDateObjectName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CreateDate",
                table: "Customers",
                newName: "Date");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Customers",
                newName: "CreateDate");
        }
    }
}
