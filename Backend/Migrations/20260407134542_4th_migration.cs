using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackendApp.Migrations
{
    /// <inheritdoc />
    public partial class _4th_migration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_F031_Ermos_MoDocuments_MoDocumentId",
                table: "F031_Ermos");

            migrationBuilder.DropForeignKey(
                name: "FK_F032_Trmos_MoDocuments_MoDocumentId",
                table: "F032_Trmos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MoDocuments",
                table: "MoDocuments");

            migrationBuilder.DropColumn(
                name: "MoId",
                table: "MoDocuments");

            migrationBuilder.AddColumn<long>(
                name: "Id",
                table: "MoDocuments",
                type: "bigint",
                nullable: false,
                defaultValue: 0L)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<long>(
                name: "MoDocumentId",
                table: "F032_Trmos",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(17)");

            migrationBuilder.AlterColumn<long>(
                name: "MoDocumentId",
                table: "F031_Ermos",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(17)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MoDocuments",
                table: "MoDocuments",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_F031_Ermos_MoDocuments_MoDocumentId",
                table: "F031_Ermos",
                column: "MoDocumentId",
                principalTable: "MoDocuments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_F032_Trmos_MoDocuments_MoDocumentId",
                table: "F032_Trmos",
                column: "MoDocumentId",
                principalTable: "MoDocuments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_F031_Ermos_MoDocuments_MoDocumentId",
                table: "F031_Ermos");

            migrationBuilder.DropForeignKey(
                name: "FK_F032_Trmos_MoDocuments_MoDocumentId",
                table: "F032_Trmos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MoDocuments",
                table: "MoDocuments");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "MoDocuments");

            migrationBuilder.AddColumn<string>(
                name: "MoId",
                table: "MoDocuments",
                type: "nvarchar(17)",
                maxLength: 17,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "MoDocumentId",
                table: "F032_Trmos",
                type: "nvarchar(17)",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<string>(
                name: "MoDocumentId",
                table: "F031_Ermos",
                type: "nvarchar(17)",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MoDocuments",
                table: "MoDocuments",
                column: "MoId");

            migrationBuilder.AddForeignKey(
                name: "FK_F031_Ermos_MoDocuments_MoDocumentId",
                table: "F031_Ermos",
                column: "MoDocumentId",
                principalTable: "MoDocuments",
                principalColumn: "MoId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_F032_Trmos_MoDocuments_MoDocumentId",
                table: "F032_Trmos",
                column: "MoDocumentId",
                principalTable: "MoDocuments",
                principalColumn: "MoId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
