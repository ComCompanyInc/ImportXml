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

            migrationBuilder.AddColumn<long>(
                name: "F002_InsIncludeId",
                table: "F032_Trmos",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_F037_Licmos_BaseDataId",
                table: "F037_Licmos",
                column: "BaseDataId");

            migrationBuilder.CreateIndex(
                name: "IX_F032_Trmos_F002_InsIncludeId",
                table: "F032_Trmos",
                column: "F002_InsIncludeId");

            migrationBuilder.AddForeignKey(
                name: "FK_F032_Trmos_InsIncludes_F002_InsIncludeId",
                table: "F032_Trmos",
                column: "F002_InsIncludeId",
                principalTable: "InsIncludes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
                name: "FK_F032_Trmos_InsIncludes_F002_InsIncludeId",
                table: "F032_Trmos");

            migrationBuilder.DropForeignKey(
                name: "FK_F037_Licmos_BaseData_BaseDataId",
                table: "F037_Licmos");

            migrationBuilder.DropIndex(
                name: "IX_F037_Licmos_BaseDataId",
                table: "F037_Licmos");

            migrationBuilder.DropIndex(
                name: "IX_F032_Trmos_F002_InsIncludeId",
                table: "F032_Trmos");

            migrationBuilder.DropColumn(
                name: "BaseDataId",
                table: "F037_Licmos");

            migrationBuilder.DropColumn(
                name: "F002_InsIncludeId",
                table: "F032_Trmos");
        }
    }
}
