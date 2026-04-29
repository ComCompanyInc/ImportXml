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
                name: "NalP",
                table: "Organizations");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Organizations");

            migrationBuilder.DropColumn(
                name: "NameE",
                table: "Organizations");

            migrationBuilder.DropColumn(
                name: "ShortName",
                table: "Organizations");

            migrationBuilder.DropColumn(
                name: "DateBegin",
                table: "Districts");

            migrationBuilder.DropColumn(
                name: "DateEnd",
                table: "Districts");

            migrationBuilder.DropColumn(
                name: "Okato",
                table: "Addresses");

            migrationBuilder.RenameColumn(
                name: "MoDocumentId",
                table: "F032_Trmos",
                newName: "OrgDocumentId");

            migrationBuilder.RenameIndex(
                name: "IX_F032_Trmos_MoDocumentId",
                table: "F032_Trmos",
                newName: "IX_F032_Trmos_OrgDocumentId");

            migrationBuilder.AddColumn<string>(
                name: "Okato",
                table: "Subjects",
                type: "nvarchar(5)",
                maxLength: 5,
                nullable: true);

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

            migrationBuilder.AddColumn<long>(
                name: "Code",
                table: "Districts",
                type: "bigint",
                nullable: true);

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

            migrationBuilder.AddColumn<long>(
                name: "AdditionalContactId",
                table: "Communications",
                type: "bigint",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "BaseData",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "Oktmo",
                table: "Addresses",
                type: "nvarchar(11)",
                maxLength: 11,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(11)",
                oldMaxLength: 11);

            migrationBuilder.AlterColumn<string>(
                name: "AddressCode",
                table: "Addresses",
                type: "nvarchar(36)",
                maxLength: 36,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(36)",
                oldMaxLength: 36);

            migrationBuilder.CreateTable(
                name: "ExpTypes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(1500)", maxLength: 1500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "F010_Subects",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BaseDataId = table.Column<long>(type: "bigint", nullable: false),
                    CodeTf = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    SubjectId = table.Column<long>(type: "bigint", nullable: false),
                    DateBeg = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateEnd = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AddressId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_F010_Subects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_F010_Subects_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_F010_Subects_BaseData_BaseDataId",
                        column: x => x.BaseDataId,
                        principalTable: "BaseData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_F010_Subects_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "F012_TipSches",
                columns: table => new
                {
                    SchId = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    BaseDataId = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(254)", maxLength: 254, nullable: false),
                    ShortName = table.Column<string>(type: "nvarchar(254)", maxLength: 254, nullable: false),
                    DateBeg = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateEnd = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_F012_TipSches", x => x.SchId);
                    table.ForeignKey(
                        name: "FK_F012_TipSches_BaseData_BaseDataId",
                        column: x => x.BaseDataId,
                        principalTable: "BaseData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "F015_Okrugs",
                columns: table => new
                {
                    Code = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    BaseDataId = table.Column<long>(type: "bigint", nullable: false),
                    DistrictId = table.Column<long>(type: "bigint", nullable: false),
                    DateBeg = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateEnd = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_F015_Okrugs", x => x.Code);
                    table.ForeignKey(
                        name: "FK_F015_Okrugs_BaseData_BaseDataId",
                        column: x => x.BaseDataId,
                        principalTable: "BaseData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_F015_Okrugs_Districts_DistrictId",
                        column: x => x.DistrictId,
                        principalTable: "Districts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InsIncludes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameE = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    NalP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DBegin = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DEnd = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OrganizationId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InsIncludes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InsIncludes_Organizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organizations",
                        principalColumn: "Id");
                });

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
                name: "OmsTypes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(254)", maxLength: 254, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OmsTypes", x => x.Id);
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
                name: "PaymentStatuses",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusName = table.Column<string>(type: "nvarchar(254)", maxLength: 254, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Patronymic = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StatTypes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusName = table.Column<string>(type: "nvarchar(254)", maxLength: 254, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VedomType",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(254)", maxLength: 254, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VedomType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "F006_VidExps",
                columns: table => new
                {
                    VidId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BaseDataId = table.Column<long>(type: "bigint", nullable: false),
                    ExpTypeId = table.Column<long>(type: "bigint", nullable: false),
                    DateBeg = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateEnd = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_F006_VidExps", x => x.VidId);
                    table.ForeignKey(
                        name: "FK_F006_VidExps_BaseData_BaseDataId",
                        column: x => x.BaseDataId,
                        principalTable: "BaseData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_F006_VidExps_ExpTypes_ExpTypeId",
                        column: x => x.ExpTypeId,
                        principalTable: "ExpTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                name: "F008_TipOms",
                columns: table => new
                {
                    DocId = table.Column<long>(type: "bigint", nullable: false),
                    BaseDataId = table.Column<long>(type: "bigint", nullable: false),
                    OmsTypeId = table.Column<long>(type: "bigint", nullable: false),
                    DateBeg = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateEnd = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_F008_TipOms", x => x.DocId);
                    table.ForeignKey(
                        name: "FK_F008_TipOms_BaseData_BaseDataId",
                        column: x => x.BaseDataId,
                        principalTable: "BaseData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_F008_TipOms_OmsTypes_OmsTypeId",
                        column: x => x.OmsTypeId,
                        principalTable: "OmsTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                name: "F005_StatOpls",
                columns: table => new
                {
                    StatusCode = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateBeg = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateEnd = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PaymentStatusId = table.Column<long>(type: "bigint", nullable: false),
                    BaseDataId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_F005_StatOpls", x => x.StatusCode);
                    table.ForeignKey(
                        name: "FK_F005_StatOpls_BaseData_BaseDataId",
                        column: x => x.BaseDataId,
                        principalTable: "BaseData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_F005_StatOpls_PaymentStatuses_PaymentStatusId",
                        column: x => x.PaymentStatusId,
                        principalTable: "PaymentStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "F002_SmoEmps",
                columns: table => new
                {
                    SmoCod = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    AddressId = table.Column<long>(type: "bigint", nullable: false),
                    OrganizationId = table.Column<long>(type: "bigint", nullable: false),
                    DocumentId = table.Column<long>(type: "bigint", nullable: false),
                    CommunicationId = table.Column<long>(type: "bigint", nullable: false),
                    PersonId = table.Column<long>(type: "bigint", nullable: false),
                    BaseDataId = table.Column<long>(type: "bigint", nullable: false),
                    LicenseId = table.Column<long>(type: "bigint", nullable: false),
                    F002_InsIncludeId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_F002_SmoEmps", x => x.SmoCod);
                    table.ForeignKey(
                        name: "FK_F002_SmoEmps_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_F002_SmoEmps_BaseData_BaseDataId",
                        column: x => x.BaseDataId,
                        principalTable: "BaseData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_F002_SmoEmps_Communications_CommunicationId",
                        column: x => x.CommunicationId,
                        principalTable: "Communications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_F002_SmoEmps_Documents_DocumentId",
                        column: x => x.DocumentId,
                        principalTable: "Documents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_F002_SmoEmps_InsIncludes_F002_InsIncludeId",
                        column: x => x.F002_InsIncludeId,
                        principalTable: "InsIncludes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_F002_SmoEmps_Licenses_LicenseId",
                        column: x => x.LicenseId,
                        principalTable: "Licenses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_F002_SmoEmps_Organizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_F002_SmoEmps_People_PersonId",
                        column: x => x.PersonId,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "F009_StatZls",
                columns: table => new
                {
                    StatusId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BaseDataId = table.Column<long>(type: "bigint", nullable: false),
                    StatTypeId = table.Column<long>(type: "bigint", nullable: false),
                    DateBeg = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateEnd = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_F009_StatZls", x => x.StatusId);
                    table.ForeignKey(
                        name: "FK_F009_StatZls_BaseData_BaseDataId",
                        column: x => x.BaseDataId,
                        principalTable: "BaseData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_F009_StatZls_StatTypes_StatTypeId",
                        column: x => x.StatTypeId,
                        principalTable: "StatTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "F007_Vedoms",
                columns: table => new
                {
                    VedId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VedomTypeId = table.Column<long>(type: "bigint", nullable: false),
                    BaseDataId = table.Column<long>(type: "bigint", nullable: false),
                    DateBeg = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateEnd = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_F007_Vedoms", x => x.VedId);
                    table.ForeignKey(
                        name: "FK_F007_Vedoms_BaseData_BaseDataId",
                        column: x => x.BaseDataId,
                        principalTable: "BaseData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_F007_Vedoms_VedomType_VedomTypeId",
                        column: x => x.VedomTypeId,
                        principalTable: "VedomType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "F011_Tipdocs",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    F008_TipOmsId = table.Column<long>(type: "bigint", nullable: false),
                    DocSer = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    DocNum = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_F011_Tipdocs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_F011_Tipdocs_F008_TipOms_F008_TipOmsId",
                        column: x => x.F008_TipOmsId,
                        principalTable: "F008_TipOms",
                        principalColumn: "DocId",
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

            migrationBuilder.CreateTable(
                name: "f002_smo_insAdvices",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    YearWork = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Duved = table.Column<DateTime>(type: "datetime2", nullable: false),
                    KolZl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DEdit = table.Column<DateTime>(type: "datetime2", nullable: false),
                    F002_SmoEmpSmoCod = table.Column<string>(type: "nvarchar(5)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_f002_smo_insAdvices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_f002_smo_insAdvices_F002_SmoEmps_F002_SmoEmpSmoCod",
                        column: x => x.F002_SmoEmpSmoCod,
                        principalTable: "F002_SmoEmps",
                        principalColumn: "SmoCod",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "f019_PersAccOrgs",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrganizationId = table.Column<long>(type: "bigint", nullable: true),
                    AddressId = table.Column<long>(type: "bigint", nullable: true),
                    DateBeg = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateEnd = table.Column<DateTime>(type: "datetime2", nullable: false),
                    F002_SmoEmpId = table.Column<string>(type: "nvarchar(5)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_f019_PersAccOrgs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_f019_PersAccOrgs_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_f019_PersAccOrgs_F002_SmoEmps_F002_SmoEmpId",
                        column: x => x.F002_SmoEmpId,
                        principalTable: "F002_SmoEmps",
                        principalColumn: "SmoCod",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_f019_PersAccOrgs_Organizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organizations",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Organizations_OrgNameId",
                table: "Organizations",
                column: "OrgNameId");

            migrationBuilder.CreateIndex(
                name: "IX_Communications_AdditionalContactId",
                table: "Communications",
                column: "AdditionalContactId");

            migrationBuilder.CreateIndex(
                name: "IX_f002_smo_insAdvices_F002_SmoEmpSmoCod",
                table: "f002_smo_insAdvices",
                column: "F002_SmoEmpSmoCod");

            migrationBuilder.CreateIndex(
                name: "IX_F002_SmoEmps_AddressId",
                table: "F002_SmoEmps",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_F002_SmoEmps_BaseDataId",
                table: "F002_SmoEmps",
                column: "BaseDataId");

            migrationBuilder.CreateIndex(
                name: "IX_F002_SmoEmps_CommunicationId",
                table: "F002_SmoEmps",
                column: "CommunicationId");

            migrationBuilder.CreateIndex(
                name: "IX_F002_SmoEmps_DocumentId",
                table: "F002_SmoEmps",
                column: "DocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_F002_SmoEmps_F002_InsIncludeId",
                table: "F002_SmoEmps",
                column: "F002_InsIncludeId");

            migrationBuilder.CreateIndex(
                name: "IX_F002_SmoEmps_LicenseId",
                table: "F002_SmoEmps",
                column: "LicenseId");

            migrationBuilder.CreateIndex(
                name: "IX_F002_SmoEmps_OrganizationId",
                table: "F002_SmoEmps",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_F002_SmoEmps_PersonId",
                table: "F002_SmoEmps",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_F005_StatOpls_BaseDataId",
                table: "F005_StatOpls",
                column: "BaseDataId");

            migrationBuilder.CreateIndex(
                name: "IX_F005_StatOpls_PaymentStatusId",
                table: "F005_StatOpls",
                column: "PaymentStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_F006_VidExps_BaseDataId",
                table: "F006_VidExps",
                column: "BaseDataId");

            migrationBuilder.CreateIndex(
                name: "IX_F006_VidExps_ExpTypeId",
                table: "F006_VidExps",
                column: "ExpTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_F007_Vedoms_BaseDataId",
                table: "F007_Vedoms",
                column: "BaseDataId");

            migrationBuilder.CreateIndex(
                name: "IX_F007_Vedoms_VedomTypeId",
                table: "F007_Vedoms",
                column: "VedomTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_F008_TipOms_BaseDataId",
                table: "F008_TipOms",
                column: "BaseDataId");

            migrationBuilder.CreateIndex(
                name: "IX_F008_TipOms_OmsTypeId",
                table: "F008_TipOms",
                column: "OmsTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_F009_StatZls_BaseDataId",
                table: "F009_StatZls",
                column: "BaseDataId");

            migrationBuilder.CreateIndex(
                name: "IX_F009_StatZls_StatTypeId",
                table: "F009_StatZls",
                column: "StatTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_F010_Subects_AddressId",
                table: "F010_Subects",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_F010_Subects_BaseDataId",
                table: "F010_Subects",
                column: "BaseDataId");

            migrationBuilder.CreateIndex(
                name: "IX_F010_Subects_SubjectId",
                table: "F010_Subects",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_F011_Tipdocs_F008_TipOmsId",
                table: "F011_Tipdocs",
                column: "F008_TipOmsId");

            migrationBuilder.CreateIndex(
                name: "IX_F012_TipSches_BaseDataId",
                table: "F012_TipSches",
                column: "BaseDataId");

            migrationBuilder.CreateIndex(
                name: "IX_F015_Okrugs_BaseDataId",
                table: "F015_Okrugs",
                column: "BaseDataId");

            migrationBuilder.CreateIndex(
                name: "IX_F015_Okrugs_DistrictId",
                table: "F015_Okrugs",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_f019_PersAccOrgs_AddressId",
                table: "f019_PersAccOrgs",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_f019_PersAccOrgs_F002_SmoEmpId",
                table: "f019_PersAccOrgs",
                column: "F002_SmoEmpId");

            migrationBuilder.CreateIndex(
                name: "IX_f019_PersAccOrgs_OrganizationId",
                table: "f019_PersAccOrgs",
                column: "OrganizationId");

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

            migrationBuilder.CreateIndex(
                name: "IX_InsIncludes_OrganizationId",
                table: "InsIncludes",
                column: "OrganizationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Communications_Communications_AdditionalContactId",
                table: "Communications",
                column: "AdditionalContactId",
                principalTable: "Communications",
                principalColumn: "Id");

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
                name: "FK_Communications_Communications_AdditionalContactId",
                table: "Communications");

            migrationBuilder.DropForeignKey(
                name: "FK_F032_Trmos_OrgDocuments_OrgDocumentId",
                table: "F032_Trmos");

            migrationBuilder.DropForeignKey(
                name: "FK_Organizations_OrgNames_OrgNameId",
                table: "Organizations");

            migrationBuilder.DropTable(
                name: "f002_smo_insAdvices");

            migrationBuilder.DropTable(
                name: "F005_StatOpls");

            migrationBuilder.DropTable(
                name: "F006_VidExps");

            migrationBuilder.DropTable(
                name: "F007_Vedoms");

            migrationBuilder.DropTable(
                name: "F009_StatZls");

            migrationBuilder.DropTable(
                name: "F010_Subects");

            migrationBuilder.DropTable(
                name: "F011_Tipdocs");

            migrationBuilder.DropTable(
                name: "F012_TipSches");

            migrationBuilder.DropTable(
                name: "F015_Okrugs");

            migrationBuilder.DropTable(
                name: "f019_PersAccOrgs");

            migrationBuilder.DropTable(
                name: "F037_Licmos");

            migrationBuilder.DropTable(
                name: "F038_Addrmps");

            migrationBuilder.DropTable(
                name: "PaymentStatuses");

            migrationBuilder.DropTable(
                name: "ExpTypes");

            migrationBuilder.DropTable(
                name: "VedomType");

            migrationBuilder.DropTable(
                name: "StatTypes");

            migrationBuilder.DropTable(
                name: "F008_TipOms");

            migrationBuilder.DropTable(
                name: "F002_SmoEmps");

            migrationBuilder.DropTable(
                name: "F033_Spmos");

            migrationBuilder.DropTable(
                name: "OmsTypes");

            migrationBuilder.DropTable(
                name: "InsIncludes");

            migrationBuilder.DropTable(
                name: "Licenses");

            migrationBuilder.DropTable(
                name: "People");

            migrationBuilder.DropTable(
                name: "OrgNames");

            migrationBuilder.DropIndex(
                name: "IX_Organizations_OrgNameId",
                table: "Organizations");

            migrationBuilder.DropIndex(
                name: "IX_Communications_AdditionalContactId",
                table: "Communications");

            migrationBuilder.DropColumn(
                name: "Okato",
                table: "Subjects");

            migrationBuilder.DropColumn(
                name: "OrgNameId",
                table: "Organizations");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "Districts");

            migrationBuilder.DropColumn(
                name: "AdditionalContactId",
                table: "Communications");

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

            migrationBuilder.AddColumn<int>(
                name: "NalP",
                table: "Organizations",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Organizations",
                type: "nvarchar(2500)",
                maxLength: 2500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NameE",
                table: "Organizations",
                type: "nvarchar(1)",
                maxLength: 1,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ShortName",
                table: "Organizations",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateBegin",
                table: "Districts",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateEnd",
                table: "Districts",
                type: "datetime2",
                nullable: true);

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
                name: "Type",
                table: "BaseData",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
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

            migrationBuilder.AlterColumn<string>(
                name: "AddressCode",
                table: "Addresses",
                type: "nvarchar(36)",
                maxLength: 36,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(36)",
                oldMaxLength: 36,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Okato",
                table: "Addresses",
                type: "nvarchar(5)",
                maxLength: 5,
                nullable: true);

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
