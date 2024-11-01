using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartBin.Api.Migrations
{
    /// <inheritdoc />
    public partial class UpdateError : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ErrorHistories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BinUnitId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ErrorName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TimeStamp = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ErrorHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ErrorHistories_BinUnits_BinUnitId",
                        column: x => x.BinUnitId,
                        principalTable: "BinUnits",
                        principalColumn: "BinUnitId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ErrorHistories_BinUnitId",
                table: "ErrorHistories",
                column: "BinUnitId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ErrorHistories");
        }
    }
}
