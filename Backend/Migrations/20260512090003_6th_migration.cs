using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackendApp.Migrations
{
    /// <inheritdoc />
    public partial class _6th_migration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "BaseDataId",
                table: "F037_Licmos",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_F037_Licmos_BaseDataId",
                table: "F037_Licmos",
                column: "BaseDataId");

            migrationBuilder.AddForeignKey(
                name: "FK_F037_Licmos_BaseData_BaseDataId",
                table: "F037_Licmos",
                column: "BaseDataId",
                principalTable: "BaseData",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_F037_Licmos_BaseData_BaseDataId",
                table: "F037_Licmos");

            migrationBuilder.DropIndex(
                name: "IX_F037_Licmos_BaseDataId",
                table: "F037_Licmos");

            migrationBuilder.DropColumn(
                name: "BaseDataId",
                table: "F037_Licmos");
        }
    }
}
