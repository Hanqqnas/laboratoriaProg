using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace laboratoriaProg.Migrations
{
    /// <inheritdoc />
    public partial class Organizations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "organizations",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.UpdateData(
                table: "Contact",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2024, 11, 18, 22, 42, 45, 85, DateTimeKind.Local).AddTicks(9167));

            migrationBuilder.UpdateData(
                table: "Contact",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2024, 11, 18, 22, 42, 45, 85, DateTimeKind.Local).AddTicks(9220));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "organizations",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.UpdateData(
                table: "Contact",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2024, 11, 18, 22, 29, 35, 725, DateTimeKind.Local).AddTicks(4170));

            migrationBuilder.UpdateData(
                table: "Contact",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2024, 11, 18, 22, 29, 35, 725, DateTimeKind.Local).AddTicks(4224));
        }
    }
}
