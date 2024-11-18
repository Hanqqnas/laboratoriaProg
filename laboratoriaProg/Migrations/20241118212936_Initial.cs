using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace laboratoriaProg.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "organizations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    NIP = table.Column<string>(type: "TEXT", nullable: false),
                    REGION = table.Column<string>(type: "TEXT", nullable: false),
                    Address_City = table.Column<string>(type: "TEXT", nullable: true),
                    Address_Street = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_organizations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Contact",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    LastName = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: false),
                    BirthDate = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    Category = table.Column<int>(type: "INTEGER", nullable: false),
                    Created = table.Column<DateTime>(type: "TEXT", nullable: false),
                    OrganizationId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contact", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contact_organizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "organizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "organizations",
                columns: new[] { "Id", "Address_City", "Address_Street", "NIP", "Name", "REGION" },
                values: new object[,]
                {
                    { 101, "Kraków", "św.Filipa 17", "21213356453", "WSEI", "21213356453" },
                    { 102, "Warszawa", "Dworcowa 9", "21453356453", "PKP", "21453356453" }
                });

            migrationBuilder.InsertData(
                table: "Contact",
                columns: new[] { "Id", "BirthDate", "Category", "Created", "Email", "FirstName", "LastName", "OrganizationId", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, new DateOnly(2000, 10, 10), 0, new DateTime(2024, 11, 18, 22, 29, 35, 725, DateTimeKind.Local).AddTicks(4170), "kk@wp.pl", "Kamil", "Kowalski", 101, "531432234" },
                    { 2, new DateOnly(2000, 12, 11), 0, new DateTime(2024, 11, 18, 22, 29, 35, 725, DateTimeKind.Local).AddTicks(4224), "kn@gmail.com", "Kamil", "Nowacki", 102, "531422234" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contact_OrganizationId",
                table: "Contact",
                column: "OrganizationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contact");

            migrationBuilder.DropTable(
                name: "organizations");
        }
    }
}
