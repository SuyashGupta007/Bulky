using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Bulky.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addDrugstable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Drugs",
                columns: table => new
                {
                    Batch_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Drug_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Expired_Date = table.Column<DateOnly>(type: "date", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drugs", x => x.Batch_Id);
                });

            migrationBuilder.InsertData(
                table: "Drugs",
                columns: new[] { "Batch_Id", "Drug_Name", "Expired_Date", "Price", "Quantity" },
                values: new object[,]
                {
                    { 1, "Paracetamol", new DateOnly(2028, 3, 16), 200.0, 10 },
                    { 2, "Ketoconazole", new DateOnly(2025, 10, 19), 500.0, 5 },
                    { 3, "Aspirin", new DateOnly(2027, 9, 26), 750.0, 6 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Drugs");
        }
    }
}
