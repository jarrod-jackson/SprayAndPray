using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SprayAndPray.DAL
{
    public partial class ALTER_TABLE_AddServicesIdColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pricing_Services_ServicesID",
                table: "Pricing");

            migrationBuilder.RenameColumn(
                name: "ServicesID",
                table: "Pricing",
                newName: "ServicesId");

            migrationBuilder.RenameIndex(
                name: "IX_Pricing_ServicesID",
                table: "Pricing",
                newName: "IX_Pricing_ServicesId");

            migrationBuilder.AlterColumn<int>(
                name: "ServicesId",
                table: "Pricing",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Pricing_Services_ServicesId",
                table: "Pricing",
                column: "ServicesId",
                principalTable: "Services",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pricing_Services_ServicesId",
                table: "Pricing");

            migrationBuilder.RenameColumn(
                name: "ServicesId",
                table: "Pricing",
                newName: "ServicesID");

            migrationBuilder.RenameIndex(
                name: "IX_Pricing_ServicesId",
                table: "Pricing",
                newName: "IX_Pricing_ServicesID");

            migrationBuilder.AlterColumn<int>(
                name: "ServicesID",
                table: "Pricing",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Pricing_Services_ServicesID",
                table: "Pricing",
                column: "ServicesID",
                principalTable: "Services",
                principalColumn: "ID");
        }
    }
}
