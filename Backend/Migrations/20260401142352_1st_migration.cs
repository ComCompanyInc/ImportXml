using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackendApp.Migrations
{
    /// <inheritdoc />
    public partial class _1st_migration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Communications",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Phone = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Fax = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    HotLine = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Site = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Communications", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Districts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    DateBegin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateEnd = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Districts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Documents",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Inn = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    Ogrn = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Kpp = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrgTypes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrgTypeName = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrgTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OspType",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OspType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VidMos",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VidMos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Subjects",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    DistrictId = table.Column<long>(type: "bigint", nullable: false),
                    DistrictId1 = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subjects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Subjects_Districts_DistrictId1",
                        column: x => x.DistrictId1,
                        principalTable: "Districts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Organizations",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(2500)", maxLength: 2500, nullable: false),
                    ShortName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    KfTf = table.Column<int>(type: "int", nullable: false),
                    Kbk = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    NoSmo = table.Column<bool>(type: "bit", nullable: false),
                    OrgCode = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    Mcod = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    Okopf = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    NameE = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    NalP = table.Column<int>(type: "int", nullable: false),
                    VedPri = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    OrgTypeId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organizations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Organizations_OrgTypes_OrgTypeId",
                        column: x => x.OrgTypeId,
                        principalTable: "OrgTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MoDocuments",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OidMo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Okfs = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    VidMoId = table.Column<long>(type: "bigint", nullable: false),
                    OidSpmo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DateBeg = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateEnd = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoDocuments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MoDocuments_VidMos_VidMoId",
                        column: x => x.VidMoId,
                        principalTable: "VidMos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Index = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    Okato = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    SubjectId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Addresses_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "F031_Ermos",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MoDocumentId = table.Column<long>(type: "bigint", nullable: false),
                    AddressId = table.Column<long>(type: "bigint", nullable: false),
                    AddressCode = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    OrganizationId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_F031_Ermos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_F031_Ermos_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_F031_Ermos_MoDocuments_MoDocumentId",
                        column: x => x.MoDocumentId,
                        principalTable: "MoDocuments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_F031_Ermos_Organizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "F032_Trmos",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    f031_ermoId = table.Column<long>(type: "bigint", nullable: true),
                    OrganizationId = table.Column<long>(type: "bigint", nullable: false),
                    AddressId = table.Column<long>(type: "bigint", nullable: false),
                    DocumentId = table.Column<long>(type: "bigint", nullable: false),
                    OspTypeId = table.Column<long>(type: "bigint", nullable: false),
                    ExclusionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InclusionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    f031_ermoParentId = table.Column<long>(type: "bigint", nullable: true),
                    ParentId = table.Column<long>(type: "bigint", nullable: true),
                    MoDocumentId = table.Column<long>(type: "bigint", nullable: false),
                    DateBeg = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateEnd = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CommunicationId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_F032_Trmos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_F032_Trmos_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_F032_Trmos_Communications_CommunicationId",
                        column: x => x.CommunicationId,
                        principalTable: "Communications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_F032_Trmos_Documents_DocumentId",
                        column: x => x.DocumentId,
                        principalTable: "Documents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_F032_Trmos_F031_Ermos_f031_ermoId",
                        column: x => x.f031_ermoId,
                        principalTable: "F031_Ermos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_F032_Trmos_F031_Ermos_f031_ermoParentId",
                        column: x => x.f031_ermoParentId,
                        principalTable: "F031_Ermos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_F032_Trmos_F032_Trmos_ParentId",
                        column: x => x.ParentId,
                        principalTable: "F032_Trmos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_F032_Trmos_MoDocuments_MoDocumentId",
                        column: x => x.MoDocumentId,
                        principalTable: "MoDocuments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_F032_Trmos_Organizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_F032_Trmos_OspType_OspTypeId",
                        column: x => x.OspTypeId,
                        principalTable: "OspType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_SubjectId",
                table: "Addresses",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_F031_Ermos_AddressId",
                table: "F031_Ermos",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_F031_Ermos_MoDocumentId",
                table: "F031_Ermos",
                column: "MoDocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_F031_Ermos_OrganizationId",
                table: "F031_Ermos",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_F032_Trmos_AddressId",
                table: "F032_Trmos",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_F032_Trmos_CommunicationId",
                table: "F032_Trmos",
                column: "CommunicationId");

            migrationBuilder.CreateIndex(
                name: "IX_F032_Trmos_DocumentId",
                table: "F032_Trmos",
                column: "DocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_F032_Trmos_f031_ermoId",
                table: "F032_Trmos",
                column: "f031_ermoId");

            migrationBuilder.CreateIndex(
                name: "IX_F032_Trmos_f031_ermoParentId",
                table: "F032_Trmos",
                column: "f031_ermoParentId");

            migrationBuilder.CreateIndex(
                name: "IX_F032_Trmos_MoDocumentId",
                table: "F032_Trmos",
                column: "MoDocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_F032_Trmos_OrganizationId",
                table: "F032_Trmos",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_F032_Trmos_OspTypeId",
                table: "F032_Trmos",
                column: "OspTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_F032_Trmos_ParentId",
                table: "F032_Trmos",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_MoDocuments_VidMoId",
                table: "MoDocuments",
                column: "VidMoId");

            migrationBuilder.CreateIndex(
                name: "IX_Organizations_OrgTypeId",
                table: "Organizations",
                column: "OrgTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_DistrictId1",
                table: "Subjects",
                column: "DistrictId1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "F032_Trmos");

            migrationBuilder.DropTable(
                name: "Communications");

            migrationBuilder.DropTable(
                name: "Documents");

            migrationBuilder.DropTable(
                name: "F031_Ermos");

            migrationBuilder.DropTable(
                name: "OspType");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "MoDocuments");

            migrationBuilder.DropTable(
                name: "Organizations");

            migrationBuilder.DropTable(
                name: "Subjects");

            migrationBuilder.DropTable(
                name: "VidMos");

            migrationBuilder.DropTable(
                name: "OrgTypes");

            migrationBuilder.DropTable(
                name: "Districts");
        }
    }
}
