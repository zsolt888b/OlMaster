using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Olympic.DAL.Migrations
{
    public partial class seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Nationalities",
                keyColumn: "Id",
                keyValue: 3,
                column: "Country",
                value: "HUN");

            migrationBuilder.UpdateData(
                table: "Olympicons",
                keyColumn: "Id",
                keyValue: 1,
                column: "Age",
                value: 24);

            migrationBuilder.UpdateData(
                table: "Olympicons",
                keyColumn: "Id",
                keyValue: 2,
                column: "Age",
                value: 29);

            migrationBuilder.UpdateData(
                table: "Olympicons",
                keyColumn: "Id",
                keyValue: 3,
                column: "Age",
                value: 23);

            migrationBuilder.UpdateData(
                table: "Olympicons",
                keyColumn: "Id",
                keyValue: 4,
                column: "Age",
                value: 24);

            migrationBuilder.InsertData(
                table: "Olympicons",
                columns: new[] { "Id", "Age", "Birthday", "Forename", "NationalityId", "Sport", "Surname" },
                values: new object[,]
                {
                    { 5, 29, new DateTime(1990, 7, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Else", 3, 0, "Someone" },
                    { 6, 24, new DateTime(1995, 7, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Person", 3, 6, "Random" },
                    { 7, 24, new DateTime(1995, 7, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Forename", 4, 5, "Surname" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Olympicons",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Olympicons",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Olympicons",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.UpdateData(
                table: "Nationalities",
                keyColumn: "Id",
                keyValue: 3,
                column: "Country",
                value: "HUH");

            migrationBuilder.UpdateData(
                table: "Olympicons",
                keyColumn: "Id",
                keyValue: 1,
                column: "Age",
                value: 25);

            migrationBuilder.UpdateData(
                table: "Olympicons",
                keyColumn: "Id",
                keyValue: 2,
                column: "Age",
                value: 30);

            migrationBuilder.UpdateData(
                table: "Olympicons",
                keyColumn: "Id",
                keyValue: 3,
                column: "Age",
                value: 25);

            migrationBuilder.UpdateData(
                table: "Olympicons",
                keyColumn: "Id",
                keyValue: 4,
                column: "Age",
                value: 25);
        }
    }
}
