using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Library.Migrations
{
    /// <inheritdoc />
    public partial class Two : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BookConnections",
                columns: table => new
                {
                    BookConnectionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FK_CustomerId = table.Column<int>(type: "int", nullable: false),
                    FK_BookId = table.Column<int>(type: "int", nullable: false),
                    IsReturned = table.Column<bool>(type: "bit", nullable: false),
                    Barrowed = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookConnections", x => x.BookConnectionId);
                    table.ForeignKey(
                        name: "FK_BookConnections_Books_FK_BookId",
                        column: x => x.FK_BookId,
                        principalTable: "Books",
                        principalColumn: "BookId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookConnections_Customers_FK_CustomerId",
                        column: x => x.FK_CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookConnections_FK_BookId",
                table: "BookConnections",
                column: "FK_BookId");

            migrationBuilder.CreateIndex(
                name: "IX_BookConnections_FK_CustomerId",
                table: "BookConnections",
                column: "FK_CustomerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookConnections");
        }
    }
}
