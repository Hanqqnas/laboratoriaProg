using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace laboratoriaProg.Migrations
{
    /// <inheritdoc />
    public partial class FixContactsDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Contact",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2025, 1, 22, 12, 24, 38, 104, DateTimeKind.Local).AddTicks(4797));

            migrationBuilder.UpdateData(
                table: "Contact",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2025, 1, 22, 12, 24, 38, 106, DateTimeKind.Local).AddTicks(7596));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
