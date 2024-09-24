using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DOCTOR.INFRA.Migrations
{
    /// <inheritdoc />
    public partial class addworkstardateandworkend : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "WorkEndTime",
                table: "Doctors",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "WorkStartTime",
                table: "Doctors",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WorkEndTime",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "WorkStartTime",
                table: "Doctors");
        }
    }
}
