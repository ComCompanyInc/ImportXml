using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackendApp.Migrations
{
    /// <inheritdoc />
    public partial class _5th_migration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Districts_DistrictId1",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_F031_Ermos_MoDocuments_MoDocumentId",
                table: "F031_Ermos");

            migrationBuilder.DropForeignKey(
                name: "FK_F032_Trmos_MoDocuments_MoDocumentId",
                table: "F032_Trmos");

            migrationBuilder.DropTable(
                name: "MoDocuments");

            migrationBuilder.DropTable(
                name: "VidMos");

            migrationBuilder.DropIndex(
                name: "IX_Addresses_DistrictId1",
                table: "Addresses");

            //migrationBuilder.DropIndex(
              //  name: "IX_Addresses_DistrictId",
                //table: "Addresses"/*,
                //throwIfMissing: false*/);

            migrationBuilder.DropColumn(
                name: "DistrictId1",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "DistrictId",
                table: "Addresses");

            migrationBuilder.RenameColumn(
                name: "MoDocumentId",
                table: "F031_Ermos",
                newName: "OrgDocumentId");

            migrationBuilder.RenameIndex(
                name: "IX_F031_Ermos_MoDocumentId",
                table: "F031_Ermos",
                newName: "IX_F031_Ermos_OrgDocumentId");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Districts",
                table: "Districts");

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "Districts",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Districts",
                table: "Districts",
                column: "Id");

            migrationBuilder.AddColumn<int>(
                name: "DistrictId",
                table: "Addresses",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "OidTypes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OidTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VidTypes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VidTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrgDocuments",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Okfs = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    VidTypeId = table.Column<long>(type: "bigint", nullable: true),
                    OidTypeMoId = table.Column<long>(type: "bigint", nullable: true),
                    OidTypeSpmoId = table.Column<long>(type: "bigint", nullable: true),
                    DateBeg = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateEnd = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrgDocuments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrgDocuments_OidTypes_OidTypeMoId",
                        column: x => x.OidTypeMoId,
                        principalTable: "OidTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OrgDocuments_OidTypes_OidTypeSpmoId",
                        column: x => x.OidTypeSpmoId,
                        principalTable: "OidTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OrgDocuments_VidTypes_VidTypeId",
                        column: x => x.VidTypeId,
                        principalTable: "VidTypes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_DistrictId",
                table: "Addresses",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_OrgDocuments_OidTypeMoId",
                table: "OrgDocuments",
                column: "OidTypeMoId");

            migrationBuilder.CreateIndex(
                name: "IX_OrgDocuments_OidTypeSpmoId",
                table: "OrgDocuments",
                column: "OidTypeSpmoId");

            migrationBuilder.CreateIndex(
                name: "IX_OrgDocuments_VidTypeId",
                table: "OrgDocuments",
                column: "VidTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Districts_DistrictId",
                table: "Addresses",
                column: "DistrictId",
                principalTable: "Districts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_F031_Ermos_OrgDocuments_OrgDocumentId",
                table: "F031_Ermos",
                column: "OrgDocumentId",
                principalTable: "OrgDocuments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_F032_Trmos_OrgDocuments_MoDocumentId",
                table: "F032_Trmos",
                column: "MoDocumentId",
                principalTable: "OrgDocuments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Districts_DistrictId",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_F031_Ermos_OrgDocuments_OrgDocumentId",
                table: "F031_Ermos");

            migrationBuilder.DropForeignKey(
                name: "FK_F032_Trmos_OrgDocuments_MoDocumentId",
                table: "F032_Trmos");

            migrationBuilder.DropTable(
                name: "OrgDocuments");

            migrationBuilder.DropTable(
                name: "OidTypes");

            migrationBuilder.DropTable(
                name: "VidTypes");

            migrationBuilder.DropIndex(
                name: "IX_Addresses_DistrictId",
                table: "Addresses");

            migrationBuilder.RenameColumn(
                name: "OrgDocumentId",
                table: "F031_Ermos",
                newName: "MoDocumentId");

            migrationBuilder.RenameIndex(
                name: "IX_F031_Ermos_OrgDocumentId",
                table: "F031_Ermos",
                newName: "IX_F031_Ermos_MoDocumentId");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Districts",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "DistrictId1",
                table: "Addresses",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "VidMos",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VidMos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MoDocuments",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VidMoId = table.Column<long>(type: "bigint", nullable: true),
                    DateBeg = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateEnd = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OidMo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    OidSpmo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Okfs = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoDocuments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MoDocuments_VidMos_VidMoId",
                        column: x => x.VidMoId,
                        principalTable: "VidMos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_DistrictId1",
                table: "Addresses",
                column: "DistrictId1");

            migrationBuilder.CreateIndex(
                name: "IX_MoDocuments_VidMoId",
                table: "MoDocuments",
                column: "VidMoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Districts_DistrictId1",
                table: "Addresses",
                column: "DistrictId1",
                principalTable: "Districts",
                principalColumn: "Id");

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
    }
}
