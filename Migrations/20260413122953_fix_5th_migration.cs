using System;
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

            migrationBuilder.AlterColumn<string>(
                name: "Okfs",
                table: "OrgDocuments",
                type: "nvarchar(2)",
                maxLength: 2,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(2)",
                oldMaxLength: 2);

            migrationBuilder.AlterColumn<string>(
                name: "Fax",
                table: "Communications",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(40)",
                oldMaxLength: 40);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Communications",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(40)",
                oldMaxLength: 40);

            migrationBuilder.CreateTable(
                name: "F033_Spmos",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(17)", maxLength: 17, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(17)", maxLength: 17, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    ShortName = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    DateBeg = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateEnd = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OspType = table.Column<int>(type: "int", nullable: false),
                    OspTypeId = table.Column<long>(type: "bigint", nullable: false),
                    OrgDocumentId = table.Column<long>(type: "bigint", nullable: false),
                    CommunicationId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_F033_Spmos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_F033_Spmos_Communications_CommunicationId",
                        column: x => x.CommunicationId,
                        principalTable: "Communications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_F033_Spmos_OrgDocuments_OrgDocumentId",
                        column: x => x.OrgDocumentId,
                        principalTable: "OrgDocuments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_F033_Spmos_CommunicationId",
                table: "F033_Spmos",
                column: "CommunicationId");

            migrationBuilder.CreateIndex(
                name: "IX_F033_Spmos_OrgDocumentId",
                table: "F033_Spmos",
                column: "OrgDocumentId");

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

            migrationBuilder.DropTable(
                name: "F033_Spmos");

            migrationBuilder.RenameColumn(
                name: "OrgDocumentId",
                table: "F032_Trmos",
                newName: "MoDocumentId");

            migrationBuilder.RenameIndex(
                name: "IX_F032_Trmos_OrgDocumentId",
                table: "F032_Trmos",
                newName: "IX_F032_Trmos_MoDocumentId");

            migrationBuilder.AlterColumn<string>(
                name: "Okfs",
                table: "OrgDocuments",
                type: "nvarchar(2)",
                maxLength: 2,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(2)",
                oldMaxLength: 2,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Fax",
                table: "Communications",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(40)",
                oldMaxLength: 40,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Communications",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(40)",
                oldMaxLength: 40,
                oldNullable: true);

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
