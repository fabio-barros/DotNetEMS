using Microsoft.EntityFrameworkCore.Migrations;

namespace server.Migrations
{
    public partial class testeems2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "incio",
                table: "depar_geren",
                newName: "inicio");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "inicio",
                table: "depar_geren",
                newName: "incio");
        }
    }
}
