using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PersonApi.Data.Migrations
{
    /// <inheritdoc />
    public partial class ChangeDateOfBirthToAge : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "People");

            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "People",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "People",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Age", "Name" },
                values: new object[] { 23, "Doe" });

            migrationBuilder.UpdateData(
                table: "People",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Age", "Name" },
                values: new object[] { 18, "Foo" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Age",
                table: "People");

            migrationBuilder.AddColumn<DateOnly>(
                name: "DateOfBirth",
                table: "People",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.UpdateData(
                table: "People",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateOfBirth", "Name" },
                values: new object[] { new DateOnly(2022, 12, 12), "Foo" });

            migrationBuilder.UpdateData(
                table: "People",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateOfBirth", "Name" },
                values: new object[] { new DateOnly(2022, 12, 12), "Doe" });
        }
    }
}
