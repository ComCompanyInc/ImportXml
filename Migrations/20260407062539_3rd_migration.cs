using System;
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
                name: "FK_MoDocuments_VidMos_VidMoId",
                table: "MoDocuments");

            migrationBuilder.DropForeignKey(
                name: "FK_Organizations_OrgTypes_OrgTypeId",
                table: "Organizations");

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

            migrationBuilder.DropColumn(
                name: "SubjectId",
                table: "Addresses");

            migrationBuilder.AlterColumn<string>(
                name: "VedPri",
                table: "Organizations",
                type: "nvarchar(2)",
                maxLength: 2,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(2)",
                oldMaxLength: 2);

            migrationBuilder.AlterColumn<long>(
                name: "OrgTypeId",
                table: "Organizations",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<string>(
                name: "OrgCode",
                table: "Organizations",
                type: "nvarchar(5)",
                maxLength: 5,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(5)",
                oldMaxLength: 5);

            migrationBuilder.AlterColumn<bool>(
                name: "NoSmo",
                table: "Organizations",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<string>(
                name: "NameE",
                table: "Organizations",
                type: "nvarchar(1)",
                maxLength: 1,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(1)",
                oldMaxLength: 1);

            migrationBuilder.AlterColumn<int>(
                name: "NalP",
                table: "Organizations",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Mcod",
                table: "Organizations",
                type: "nvarchar(6)",
                maxLength: 6,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(6)",
                oldMaxLength: 6);

            migrationBuilder.AlterColumn<int>(
                name: "KfTf",
                table: "Organizations",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Kbk",
                table: "Organizations",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<long>(
                name: "VidMoId",
                table: "MoDocuments",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<string>(
                name: "OidSpmo",
                table: "MoDocuments",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateEnd",
                table: "MoDocuments",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");



            // Удаляем старый ParentId (но сначала удаляем зависимости)
            migrationBuilder.DropForeignKey(
                name: "FK_F032_Trmos_F032_Trmos_ParentId",
                table: "F032_Trmos");

            migrationBuilder.DropIndex(
                name: "IX_F032_Trmos_ParentId",
                table: "F032_Trmos");

            migrationBuilder.DropColumn(
                name: "ParentId",
                table: "F032_Trmos");

            // Создаем новый ParentId
            migrationBuilder.AddColumn<string>(
                name: "ParentId",
                table: "F032_Trmos",
                type: "nvarchar(17)",
                nullable: true);

            // Удаляем первичный ключ
            migrationBuilder.DropPrimaryKey(
                name: "PK_F032_Trmos",
                table: "F032_Trmos");

            // Удаляем старый столбец Id
            migrationBuilder.DropColumn(
                name: "Id",
                table: "F032_Trmos");

            // Создаем новый Id
            migrationBuilder.AddColumn<string>(
                name: "Id",
                table: "F032_Trmos",
                type: "nvarchar(17)",
                maxLength: 17,
                nullable: false);

            // Восстанавливаем первичный ключ
            migrationBuilder.AddPrimaryKey(
                name: "PK_F032_Trmos",
                table: "F032_Trmos",
                column: "Id");


            // Восстанавливаем индекс и внешний ключ для ParentId
            migrationBuilder.CreateIndex(
                name: "IX_F032_Trmos_ParentId",
                table: "F032_Trmos",
                column: "ParentId");

            migrationBuilder.AddForeignKey(
                name: "FK_F032_Trmos_F032_Trmos_ParentId",
                table: "F032_Trmos",
                column: "ParentId",
                principalTable: "F032_Trmos",
                principalColumn: "Id");



            migrationBuilder.AddColumn<long>(
                name: "CommunicationId",
                table: "F031_Ermos",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateBeg",
                table: "F031_Ermos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateEnd",
                table: "F031_Ermos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<long>(
                name: "DocumentId",
                table: "F031_Ermos",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "SubjectId",
                table: "Districts",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AlterColumn<string>(
                name: "Site",
                table: "Communications",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "HotLine",
                table: "Communications",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(40)",
                oldMaxLength: 40);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "BaseData",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Okato",
                table: "Addresses",
                type: "nvarchar(5)",
                maxLength: 5,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(5)",
                oldMaxLength: 5);

            migrationBuilder.AddColumn<long>(
                name: "DistrictId",
                table: "Addresses",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DistrictId1",
                table: "Addresses",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Oktmo",
                table: "Addresses",
                type: "nvarchar(11)",
                maxLength: 11,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_F031_Ermos_CommunicationId",
                table: "F031_Ermos",
                column: "CommunicationId");

            migrationBuilder.CreateIndex(
                name: "IX_F031_Ermos_DocumentId",
                table: "F031_Ermos",
                column: "DocumentId");

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
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Districts_Subjects_SubjectId",
                table: "Districts",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_F031_Ermos_Communications_CommunicationId",
                table: "F031_Ermos",
                column: "CommunicationId",
                principalTable: "Communications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_F031_Ermos_Documents_DocumentId",
                table: "F031_Ermos",
                column: "DocumentId",
                principalTable: "Documents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MoDocuments_VidMos_VidMoId",
                table: "MoDocuments",
                column: "VidMoId",
                principalTable: "VidMos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Organizations_OrgTypes_OrgTypeId",
                table: "Organizations",
                column: "OrgTypeId",
                principalTable: "OrgTypes",
                principalColumn: "Id");
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

            migrationBuilder.DropForeignKey(
                name: "FK_F031_Ermos_Communications_CommunicationId",
                table: "F031_Ermos");

            migrationBuilder.DropForeignKey(
                name: "FK_F031_Ermos_Documents_DocumentId",
                table: "F031_Ermos");

            migrationBuilder.DropForeignKey(
                name: "FK_MoDocuments_VidMos_VidMoId",
                table: "MoDocuments");

            migrationBuilder.DropForeignKey(
                name: "FK_Organizations_OrgTypes_OrgTypeId",
                table: "Organizations");

            migrationBuilder.DropIndex(
                name: "IX_F031_Ermos_CommunicationId",
                table: "F031_Ermos");

            migrationBuilder.DropIndex(
                name: "IX_F031_Ermos_DocumentId",
                table: "F031_Ermos");

            migrationBuilder.DropIndex(
                name: "IX_Districts_SubjectId",
                table: "Districts");

            migrationBuilder.DropIndex(
                name: "IX_Addresses_DistrictId1",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "CommunicationId",
                table: "F031_Ermos");

            migrationBuilder.DropColumn(
                name: "DateBeg",
                table: "F031_Ermos");

            migrationBuilder.DropColumn(
                name: "DateEnd",
                table: "F031_Ermos");

            migrationBuilder.DropColumn(
                name: "DocumentId",
                table: "F031_Ermos");

            migrationBuilder.DropColumn(
                name: "SubjectId",
                table: "Districts");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "BaseData");

            migrationBuilder.DropColumn(
                name: "DistrictId",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "DistrictId1",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "Oktmo",
                table: "Addresses");

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

            migrationBuilder.AlterColumn<string>(
                name: "VedPri",
                table: "Organizations",
                type: "nvarchar(2)",
                maxLength: 2,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(2)",
                oldMaxLength: 2,
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "OrgTypeId",
                table: "Organizations",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "OrgCode",
                table: "Organizations",
                type: "nvarchar(5)",
                maxLength: 5,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(5)",
                oldMaxLength: 5,
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "NoSmo",
                table: "Organizations",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NameE",
                table: "Organizations",
                type: "nvarchar(1)",
                maxLength: 1,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(1)",
                oldMaxLength: 1,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "NalP",
                table: "Organizations",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Mcod",
                table: "Organizations",
                type: "nvarchar(6)",
                maxLength: 6,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(6)",
                oldMaxLength: 6,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "KfTf",
                table: "Organizations",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Kbk",
                table: "Organizations",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "VidMoId",
                table: "MoDocuments",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "OidSpmo",
                table: "MoDocuments",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateEnd",
                table: "MoDocuments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "ParentId",
                table: "F032_Trmos",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(17)",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "F032_Trmos",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(17)",
                oldMaxLength: 17)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<string>(
                name: "Site",
                table: "Communications",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "HotLine",
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
                name: "Okato",
                table: "Addresses",
                type: "nvarchar(5)",
                maxLength: 5,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(5)",
                oldMaxLength: 5,
                oldNullable: true);

            migrationBuilder.AddColumn<long>(
                name: "SubjectId",
                table: "Addresses",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

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
                name: "FK_MoDocuments_VidMos_VidMoId",
                table: "MoDocuments",
                column: "VidMoId",
                principalTable: "VidMos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Organizations_OrgTypes_OrgTypeId",
                table: "Organizations",
                column: "OrgTypeId",
                principalTable: "OrgTypes",
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
