using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HCMS.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class init7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StaffStrength",
                table: "BusinessUnits",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StaffStrength",
                table: "BusinessUnits");
        }
    }
}
