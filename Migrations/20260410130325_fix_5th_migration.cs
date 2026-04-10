using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackendApp.Migrations
{
    /// <inheritdoc />
    public partial class fix_5th_migration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_F032_Trmos_OrgDocuments_MoDocumentId",
                table: "F032_Trmos");

            migrationBuilder.RenameColumn(
                name: "MoDocumentId",
                table: "F032_Trmos",
                newName: "OrgDocumentId");

            migrationBuilder.RenameIndex(
                name: "IX_F032_Trmos_MoDocumentId",
                table: "F032_Trmos",
                newName: "IX_F032_Trmos_OrgDocumentId");

            migrationBuilder.AddForeignKey(
                name: "FK_F032_Trmos_OrgDocuments_OrgDocumentId",
                table: "F032_Trmos",
                column: "OrgDocumentId",
                principalTable: "OrgDocuments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_F032_Trmos_OrgDocuments_OrgDocumentId",
                table: "F032_Trmos");

            migrationBuilder.RenameColumn(
                name: "OrgDocumentId",
                table: "F032_Trmos",
                newName: "MoDocumentId");

            migrationBuilder.RenameIndex(
                name: "IX_F032_Trmos_OrgDocumentId",
                table: "F032_Trmos",
                newName: "IX_F032_Trmos_MoDocumentId");

            migrationBuilder.AddForeignKey(
                name: "FK_F032_Trmos_OrgDocuments_MoDocumentId",
                table: "F032_Trmos",
                column: "MoDocumentId",
                principalTable: "OrgDocuments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
