using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackendApp.Migrations
{
    /// <inheritdoc />
    public partial class _3rd_migration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Subjects_SubjectId",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Subjects_Districts_DistrictId1",
                table: "Subjects");

            migrationBuilder.DropIndex(
                name: "IX_Subjects_DistrictId1",
                table: "Subjects");

            migrationBuilder.DropIndex(
                name: "IX_Addresses_SubjectId",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "DistrictId",
                table: "Subjects");

            migrationBuilder.DropColumn(
                name: "DistrictId1",
                table: "Subjects");

            migrationBuilder.RenameColumn(
                name: "SubjectId",
                table: "Addresses",
                newName: "DistrictId");

            migrationBuilder.AddColumn<long>(
                name: "SubjectId",
                table: "Districts",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "BaseData",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "DistrictId1",
                table: "Addresses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Districts_SubjectId",
                table: "Districts",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_DistrictId1",
                table: "Addresses",
                column: "DistrictId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Districts_DistrictId1",
                table: "Addresses",
                column: "DistrictId1",
                principalTable: "Districts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Districts_Subjects_SubjectId",
                table: "Districts",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Districts_DistrictId1",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Districts_Subjects_SubjectId",
                table: "Districts");

            migrationBuilder.DropIndex(
                name: "IX_Districts_SubjectId",
                table: "Districts");

            migrationBuilder.DropIndex(
                name: "IX_Addresses_DistrictId1",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "SubjectId",
                table: "Districts");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "BaseData");

            migrationBuilder.DropColumn(
                name: "DistrictId1",
                table: "Addresses");

            migrationBuilder.RenameColumn(
                name: "DistrictId",
                table: "Addresses",
                newName: "SubjectId");

            migrationBuilder.AddColumn<long>(
                name: "DistrictId",
                table: "Subjects",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<int>(
                name: "DistrictId1",
                table: "Subjects",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_DistrictId1",
                table: "Subjects",
                column: "DistrictId1");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_SubjectId",
                table: "Addresses",
                column: "SubjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Subjects_SubjectId",
                table: "Addresses",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Subjects_Districts_DistrictId1",
                table: "Subjects",
                column: "DistrictId1",
                principalTable: "Districts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
