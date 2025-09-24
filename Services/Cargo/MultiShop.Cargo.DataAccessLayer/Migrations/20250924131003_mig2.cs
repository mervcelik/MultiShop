using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MultiShop.Cargo.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CargoDetails_CargoCompanies_CargocompanyId",
                table: "CargoDetails");

            migrationBuilder.RenameColumn(
                name: "CargocompanyId",
                table: "CargoDetails",
                newName: "CargoCompanyId");

            migrationBuilder.RenameIndex(
                name: "IX_CargoDetails_CargocompanyId",
                table: "CargoDetails",
                newName: "IX_CargoDetails_CargoCompanyId");

            migrationBuilder.RenameColumn(
                name: "CargocompanyId",
                table: "CargoCompanies",
                newName: "CargoCompanyId");

            migrationBuilder.AddColumn<string>(
                name: "UserCustomerId",
                table: "CargoCustomers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CargoDetails_CargoCompanies_CargoCompanyId",
                table: "CargoDetails",
                column: "CargoCompanyId",
                principalTable: "CargoCompanies",
                principalColumn: "CargoCompanyId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CargoDetails_CargoCompanies_CargoCompanyId",
                table: "CargoDetails");

            migrationBuilder.DropColumn(
                name: "UserCustomerId",
                table: "CargoCustomers");

            migrationBuilder.RenameColumn(
                name: "CargoCompanyId",
                table: "CargoDetails",
                newName: "CargocompanyId");

            migrationBuilder.RenameIndex(
                name: "IX_CargoDetails_CargoCompanyId",
                table: "CargoDetails",
                newName: "IX_CargoDetails_CargocompanyId");

            migrationBuilder.RenameColumn(
                name: "CargoCompanyId",
                table: "CargoCompanies",
                newName: "CargocompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_CargoDetails_CargoCompanies_CargocompanyId",
                table: "CargoDetails",
                column: "CargocompanyId",
                principalTable: "CargoCompanies",
                principalColumn: "CargocompanyId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
