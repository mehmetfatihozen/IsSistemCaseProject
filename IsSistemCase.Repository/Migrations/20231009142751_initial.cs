using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace IsSistemCase.Repository.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tables",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Number = table.Column<int>(type: "int", nullable: false),
                    Capacity = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tables", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TableId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReservationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NumberOfGuests = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reservations_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservations_Tables_TableId",
                        column: x => x.TableId,
                        principalTable: "Tables",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Tables",
                columns: new[] { "Id", "Capacity", "Number" },
                values: new object[,]
                {
                    { new Guid("0e1bb2c3-9ef3-4407-8fbf-98d2ad4df840"), (byte)2, 2 },
                    { new Guid("1514ff63-2ebb-4f6d-82f5-9e866a5c38b4"), (byte)4, 7 },
                    { new Guid("19d61eeb-34c8-4c14-9965-74f0b7db0570"), (byte)4, 8 },
                    { new Guid("1eb1a6ab-5ded-416b-ac0e-8e47a1d85f2d"), (byte)8, 19 },
                    { new Guid("28d7d36b-d483-40af-8c2c-c862e013d4f7"), (byte)2, 3 },
                    { new Guid("5a1e4378-0f07-4475-93da-f341d4e50b86"), (byte)4, 12 },
                    { new Guid("68bae558-1968-41e0-99cb-68a3b7fe9acc"), (byte)4, 11 },
                    { new Guid("6d74bbd2-bfcb-44fe-8086-01efb1118528"), (byte)2, 1 },
                    { new Guid("6e8f97c5-f786-41ea-be75-065e7d0d4fa6"), (byte)8, 20 },
                    { new Guid("7da6cfe4-aa43-4124-99ff-a69918a753ea"), (byte)2, 6 },
                    { new Guid("8aa250d7-37a5-4ae6-a5bb-6d27d179f036"), (byte)4, 15 },
                    { new Guid("a56b414c-e394-42f5-b9cd-0b8d7898fb06"), (byte)4, 14 },
                    { new Guid("a93d467c-18bd-48fd-84ad-b7f9a9788d52"), (byte)6, 18 },
                    { new Guid("ad6aaa16-d30a-455a-8ad0-545767d74c7d"), (byte)4, 13 },
                    { new Guid("ba5eff4f-b4fb-4966-b473-b70e71d35832"), (byte)4, 10 },
                    { new Guid("ec47278b-b3e6-41b5-85af-a2a12b14a203"), (byte)4, 9 },
                    { new Guid("ecca94c1-659e-4982-876d-262af6b279b2"), (byte)4, 16 },
                    { new Guid("f1d872db-e222-4bd8-aed5-ebaa5905666c"), (byte)2, 4 },
                    { new Guid("f9799ff7-c51c-4347-a09e-4751dd4ee2cf"), (byte)6, 17 },
                    { new Guid("fe398cc0-36a6-49c8-9337-7e9149455c03"), (byte)2, 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_CustomerId",
                table: "Reservations",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_TableId",
                table: "Reservations",
                column: "TableId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Tables");
        }
    }
}
