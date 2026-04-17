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

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Organizations");

            migrationBuilder.DropColumn(
                name: "ShortName",
                table: "Organizations");

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

            migrationBuilder.AddColumn<long>(
                name: "OrgNameId",
                table: "Organizations",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

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

            migrationBuilder.AlterColumn<string>(
                name: "Oktmo",
                table: "Addresses",
                type: "nvarchar(11)",
                maxLength: 11,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(11)",
                oldMaxLength: 11);

            migrationBuilder.CreateTable(
                name: "Licenses",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Dstart = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Dterm = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LicenseNum = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Licenses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrgNames",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: false),
                    ShortName = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrgNames", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "F037_Licmos",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    F031_ErmoId = table.Column<string>(type: "nvarchar(17)", maxLength: 17, nullable: true),
                    OrgDocumentId = table.Column<long>(type: "bigint", nullable: true),
                    OrganizationId = table.Column<long>(type: "bigint", nullable: true),
                    F032_TrmoId = table.Column<string>(type: "nvarchar(17)", maxLength: 17, nullable: true),
                    LicenseId = table.Column<long>(type: "bigint", nullable: false),
                    DateBeg = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateEnd = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_F037_Licmos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_F037_Licmos_F031_Ermos_F031_ErmoId",
                        column: x => x.F031_ErmoId,
                        principalTable: "F031_Ermos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_F037_Licmos_F032_Trmos_F032_TrmoId",
                        column: x => x.F032_TrmoId,
                        principalTable: "F032_Trmos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_F037_Licmos_Licenses_LicenseId",
                        column: x => x.LicenseId,
                        principalTable: "Licenses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_F037_Licmos_OrgDocuments_OrgDocumentId",
                        column: x => x.OrgDocumentId,
                        principalTable: "OrgDocuments",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_F037_Licmos_Organizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organizations",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "F033_Spmos",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(17)", maxLength: 17, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(17)", maxLength: 17, nullable: false),
                    OrgNameId = table.Column<long>(type: "bigint", nullable: false),
                    DateBeg = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateEnd = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OspType = table.Column<int>(type: "int", nullable: false),
                    OspTypeId = table.Column<long>(type: "bigint", nullable: false),
                    OrgDocumentId = table.Column<long>(type: "bigint", nullable: false),
                    CommunicationId = table.Column<long>(type: "bigint", nullable: false),
                    BaseDataId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_F033_Spmos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_F033_Spmos_BaseData_BaseDataId",
                        column: x => x.BaseDataId,
                        principalTable: "BaseData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    table.ForeignKey(
                        name: "FK_F033_Spmos_OrgNames_OrgNameId",
                        column: x => x.OrgNameId,
                        principalTable: "OrgNames",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "F038_Addrmps",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(19)", maxLength: 19, nullable: false),
                    F032_TrmoId = table.Column<string>(type: "nvarchar(17)", maxLength: 17, nullable: true),
                    F033_SpmoId = table.Column<string>(type: "nvarchar(17)", maxLength: 17, nullable: true),
                    LicenseId = table.Column<long>(type: "bigint", nullable: false),
                    AddressId = table.Column<long>(type: "bigint", nullable: false),
                    DateBeg = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateEnd = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BaseDataId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_F038_Addrmps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_F038_Addrmps_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_F038_Addrmps_BaseData_BaseDataId",
                        column: x => x.BaseDataId,
                        principalTable: "BaseData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_F038_Addrmps_F032_Trmos_F032_TrmoId",
                        column: x => x.F032_TrmoId,
                        principalTable: "F032_Trmos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_F038_Addrmps_F033_Spmos_F033_SpmoId",
                        column: x => x.F033_SpmoId,
                        principalTable: "F033_Spmos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_F038_Addrmps_Licenses_LicenseId",
                        column: x => x.LicenseId,
                        principalTable: "Licenses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Organizations_OrgNameId",
                table: "Organizations",
                column: "OrgNameId");

            migrationBuilder.CreateIndex(
                name: "IX_F033_Spmos_BaseDataId",
                table: "F033_Spmos",
                column: "BaseDataId");

            migrationBuilder.CreateIndex(
                name: "IX_F033_Spmos_CommunicationId",
                table: "F033_Spmos",
                column: "CommunicationId");

            migrationBuilder.CreateIndex(
                name: "IX_F033_Spmos_OrgDocumentId",
                table: "F033_Spmos",
                column: "OrgDocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_F033_Spmos_OrgNameId",
                table: "F033_Spmos",
                column: "OrgNameId");

            migrationBuilder.CreateIndex(
                name: "IX_F037_Licmos_F031_ErmoId",
                table: "F037_Licmos",
                column: "F031_ErmoId");

            migrationBuilder.CreateIndex(
                name: "IX_F037_Licmos_F032_TrmoId",
                table: "F037_Licmos",
                column: "F032_TrmoId");

            migrationBuilder.CreateIndex(
                name: "IX_F037_Licmos_LicenseId",
                table: "F037_Licmos",
                column: "LicenseId");

            migrationBuilder.CreateIndex(
                name: "IX_F037_Licmos_OrganizationId",
                table: "F037_Licmos",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_F037_Licmos_OrgDocumentId",
                table: "F037_Licmos",
                column: "OrgDocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_F038_Addrmps_AddressId",
                table: "F038_Addrmps",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_F038_Addrmps_BaseDataId",
                table: "F038_Addrmps",
                column: "BaseDataId");

            migrationBuilder.CreateIndex(
                name: "IX_F038_Addrmps_F032_TrmoId",
                table: "F038_Addrmps",
                column: "F032_TrmoId");

            migrationBuilder.CreateIndex(
                name: "IX_F038_Addrmps_F033_SpmoId",
                table: "F038_Addrmps",
                column: "F033_SpmoId");

            migrationBuilder.CreateIndex(
                name: "IX_F038_Addrmps_LicenseId",
                table: "F038_Addrmps",
                column: "LicenseId");

            migrationBuilder.AddForeignKey(
                name: "FK_F032_Trmos_OrgDocuments_OrgDocumentId",
                table: "F032_Trmos",
                column: "OrgDocumentId",
                principalTable: "OrgDocuments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Organizations_OrgNames_OrgNameId",
                table: "Organizations",
                column: "OrgNameId",
                principalTable: "OrgNames",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_F032_Trmos_OrgDocuments_OrgDocumentId",
                table: "F032_Trmos");

            migrationBuilder.DropForeignKey(
                name: "FK_Organizations_OrgNames_OrgNameId",
                table: "Organizations");

            migrationBuilder.DropTable(
                name: "F037_Licmos");

            migrationBuilder.DropTable(
                name: "F038_Addrmps");

            migrationBuilder.DropTable(
                name: "F033_Spmos");

            migrationBuilder.DropTable(
                name: "Licenses");

            migrationBuilder.DropTable(
                name: "OrgNames");

            migrationBuilder.DropIndex(
                name: "IX_Organizations_OrgNameId",
                table: "Organizations");

            migrationBuilder.DropColumn(
                name: "OrgNameId",
                table: "Organizations");

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

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Organizations",
                type: "nvarchar(2500)",
                maxLength: 2500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ShortName",
                table: "Organizations",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

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

            migrationBuilder.AlterColumn<string>(
                name: "Oktmo",
                table: "Addresses",
                type: "nvarchar(11)",
                maxLength: 11,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(11)",
                oldMaxLength: 11,
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
