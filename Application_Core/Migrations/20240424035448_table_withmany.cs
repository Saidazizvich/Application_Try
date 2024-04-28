using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Application_Core.Migrations
{
    /// <inheritdoc />
    public partial class table_withmany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DepartmentId",
                table: "Personels",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Personels_DepartmentId",
                table: "Personels",
                column: "DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Personels_Departments_DepartmentId",
                table: "Personels",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "DepartmentId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Personels_Departments_DepartmentId",
                table: "Personels");

            migrationBuilder.DropIndex(
                name: "IX_Personels_DepartmentId",
                table: "Personels");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "Personels");
        }
    }
}
