using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackendApp.Migrations
{
    /// <inheritdoc />
    public partial class _2nd_migration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "BaseDataId",
                table: "F032_Trmos",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "BaseDataId",
                table: "F031_Ermos",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "BaseData",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Version = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaseData", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_F032_Trmos_BaseDataId",
                table: "F032_Trmos",
                column: "BaseDataId");

            migrationBuilder.CreateIndex(
                name: "IX_F031_Ermos_BaseDataId",
                table: "F031_Ermos",
                column: "BaseDataId");

            migrationBuilder.AddForeignKey(
                name: "FK_F031_Ermos_BaseData_BaseDataId",
                table: "F031_Ermos",
                column: "BaseDataId",
                principalTable: "BaseData",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_F032_Trmos_BaseData_BaseDataId",
                table: "F032_Trmos",
                column: "BaseDataId",
                principalTable: "BaseData",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_F031_Ermos_BaseData_BaseDataId",
                table: "F031_Ermos");

            migrationBuilder.DropForeignKey(
                name: "FK_F032_Trmos_BaseData_BaseDataId",
                table: "F032_Trmos");

            migrationBuilder.DropTable(
                name: "BaseData");

            migrationBuilder.DropIndex(
                name: "IX_F032_Trmos_BaseDataId",
                table: "F032_Trmos");

            migrationBuilder.DropIndex(
                name: "IX_F031_Ermos_BaseDataId",
                table: "F031_Ermos");

            migrationBuilder.DropColumn(
                name: "BaseDataId",
                table: "F032_Trmos");

            migrationBuilder.DropColumn(
                name: "BaseDataId",
                table: "F031_Ermos");
        }
    }
}
