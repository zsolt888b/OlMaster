using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Olympic.DAL.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Nationalities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Country = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nationalities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Olympicons",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Surname = table.Column<string>(nullable: false),
                    Forename = table.Column<string>(nullable: false),
                    Birthday = table.Column<DateTime>(nullable: false),
                    Age = table.Column<int>(nullable: false),
                    Sport = table.Column<int>(nullable: false),
                    NationalityId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Olympicons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Olympicons_Nationalities_NationalityId",
                        column: x => x.NationalityId,
                        principalTable: "Nationalities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Medals",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OlympiconId = table.Column<int>(nullable: false),
                    Place = table.Column<int>(nullable: false),
                    Year = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Medals_Olympicons_OlympiconId",
                        column: x => x.OlympiconId,
                        principalTable: "Olympicons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Nationalities",
                columns: new[] { "Id", "Country" },
                values: new object[,]
                {
                    { 1, "USA" },
                    { 2, "GRB" },
                    { 3, "HUH" },
                    { 4, "FR" }
                });

            migrationBuilder.InsertData(
                table: "Olympicons",
                columns: new[] { "Id", "Age", "Birthday", "Forename", "NationalityId", "Sport", "Surname" },
                values: new object[,]
                {
                    { 1, 25, new DateTime(1995, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "John", 1, 0, "Doe" },
                    { 2, 30, new DateTime(1990, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jane", 1, 2, "Doe" },
                    { 3, 25, new DateTime(1996, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Er", 2, 3, "Cycl" },
                    { 4, 25, new DateTime(1995, 7, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ther", 3, 5, "Fig" }
                });

            migrationBuilder.InsertData(
                table: "Medals",
                columns: new[] { "Id", "OlympiconId", "Place", "Year" },
                values: new object[,]
                {
                    { 1, 1, 3, 2008 },
                    { 2, 1, 1, 2016 },
                    { 3, 2, 2, 2012 },
                    { 4, 3, 3, 2008 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Medals_OlympiconId",
                table: "Medals",
                column: "OlympiconId");

            migrationBuilder.CreateIndex(
                name: "IX_Olympicons_NationalityId",
                table: "Olympicons",
                column: "NationalityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Medals");

            migrationBuilder.DropTable(
                name: "Olympicons");

            migrationBuilder.DropTable(
                name: "Nationalities");
        }
    }
}
