using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace financas.Migrations
{
    public partial class AlteraUsuarios : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "LastLogin",
                table: "Usuarios",
                type: "datetime",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AddColumn<string>(
                name: "RefreshToken",
                table: "Usuarios",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<DateTime>(
                name: "RefreshTokenTime",
                table: "Usuarios",
                type: "datetime",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RefreshToken",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "RefreshTokenTime",
                table: "Usuarios");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastLogin",
                table: "Usuarios",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true);
        }
    }
}
