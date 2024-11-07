using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HCMS.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class init8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "JobDescription",
                table: "Jobs");

            migrationBuilder.RenameColumn(
                name: "JobTypeId",
                table: "Jobs",
                newName: "JobTitleId");

            migrationBuilder.RenameColumn(
                name: "EmployeeId",
                table: "Jobs",
                newName: "BusinessUnitId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "JobTitleId",
                table: "Jobs",
                newName: "JobTypeId");

            migrationBuilder.RenameColumn(
                name: "BusinessUnitId",
                table: "Jobs",
                newName: "EmployeeId");

            migrationBuilder.AddColumn<string>(
                name: "JobDescription",
                table: "Jobs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
