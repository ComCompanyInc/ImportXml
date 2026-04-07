using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackendApp.Migrations
{
    /// <inheritdoc />
    public partial class fix_3rd_migration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // 1. Удаляем старый AddressCode из F031_Ermos
            migrationBuilder.DropColumn(
                name: "AddressCode",
                table: "F031_Ermos");

            // 2. Удаляем зависимости для f031_ermoParentId и f031_ermoId
            migrationBuilder.DropForeignKey(
                name: "FK_F032_Trmos_F031_Ermos_f031_ermoParentId",
                table: "F032_Trmos");

            migrationBuilder.DropIndex(
                name: "IX_F032_Trmos_f031_ermoParentId",
                table: "F032_Trmos");

            migrationBuilder.DropForeignKey(
                name: "FK_F032_Trmos_F031_Ermos_f031_ermoId",
                table: "F032_Trmos");

            migrationBuilder.DropIndex(
                name: "IX_F032_Trmos_f031_ermoId",
                table: "F032_Trmos");

            // 3. Удаляем старые столбцы
            migrationBuilder.DropColumn(
                name: "f031_ermoParentId",
                table: "F032_Trmos");

            migrationBuilder.DropColumn(
                name: "f031_ermoId",
                table: "F032_Trmos");

            // 4. Создаем новые столбцы
            migrationBuilder.AddColumn<string>(
                name: "f031_ermoParentId",
                table: "F032_Trmos",
                type: "nvarchar(17)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "f031_ermoId",
                table: "F032_Trmos",
                type: "nvarchar(17)",
                nullable: true);

            // 5. Добавляем DateBeginOms
            migrationBuilder.AddColumn<DateTime>(
                name: "DateBeginOms",
                table: "F032_Trmos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            // 6. Меняем Id в F031_Ermos (уже правильно через Drop + Add)
            migrationBuilder.DropPrimaryKey(
                name: "PK_F031_Ermos",
                table: "F031_Ermos");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "F031_Ermos");

            migrationBuilder.AddColumn<string>(
                name: "Id",
                table: "F031_Ermos",
                type: "nvarchar(17)",
                maxLength: 17,
                nullable: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_F031_Ermos",
                table: "F031_Ermos",
                column: "Id");

            // 7. Восстанавливаем индексы и внешние ключи для F032_Trmos
            migrationBuilder.CreateIndex(
                name: "IX_F032_Trmos_f031_ermoParentId",
                table: "F032_Trmos",
                column: "f031_ermoParentId");

            migrationBuilder.AddForeignKey(
                name: "FK_F032_Trmos_F031_Ermos_f031_ermoParentId",
                table: "F032_Trmos",
                column: "f031_ermoParentId",
                principalTable: "F031_Ermos",
                principalColumn: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_F032_Trmos_f031_ermoId",
                table: "F032_Trmos",
                column: "f031_ermoId");

            migrationBuilder.AddForeignKey(
                name: "FK_F032_Trmos_F031_Ermos_f031_ermoId",
                table: "F032_Trmos",
                column: "f031_ermoId",
                principalTable: "F031_Ermos",
                principalColumn: "Id");

            // 8. Добавляем AddressCode в Addresses
            migrationBuilder.AddColumn<string>(
                name: "AddressCode",
                table: "Addresses",
                type: "nvarchar(36)",
                maxLength: 36,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateBeginOms",
                table: "F032_Trmos");

            migrationBuilder.DropColumn(
                name: "AddressCode",
                table: "Addresses");

            migrationBuilder.AlterColumn<long>(
                name: "f031_ermoParentId",
                table: "F032_Trmos",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(17)",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "f031_ermoId",
                table: "F032_Trmos",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(17)",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "F031_Ermos",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(17)",
                oldMaxLength: 17)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "AddressCode",
                table: "F031_Ermos",
                type: "nvarchar(36)",
                maxLength: 36,
                nullable: false,
                defaultValue: "");
        }
    }
}
