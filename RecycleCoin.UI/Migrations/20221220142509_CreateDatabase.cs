using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecycleCoin.UI.Migrations
{
    public partial class CreateDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Aluminums",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Object = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CarbonValue = table.Column<decimal>(type: "decimal(18,4)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aluminums", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Irons",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Object = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CarbonValue = table.Column<decimal>(type: "decimal(18,4)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Irons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Papers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Object = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CarbonValue = table.Column<decimal>(type: "decimal(18,4)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Papers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pines",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Object = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CarbonValue = table.Column<decimal>(type: "decimal(18,4)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pines", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Plastics",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Object = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CarbonValue = table.Column<decimal>(type: "decimal(18,4)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plastics", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Identity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CarbonAccount = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    RecycleCoinAccount = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    Roles = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Aluminums",
                columns: new[] { "Id", "CarbonValue", "Object" },
                values: new object[] { new Guid("d4b4102d-9ebf-41cb-bbed-91f324339818"), 330m, "Kola Kutusu" });

            migrationBuilder.InsertData(
                table: "Irons",
                columns: new[] { "Id", "CarbonValue", "Object" },
                values: new object[] { new Guid("09f78b5e-0b17-4d4c-b0e4-c2f31ee62b5e"), 400m, "Pil" });

            migrationBuilder.InsertData(
                table: "Papers",
                columns: new[] { "Id", "CarbonValue", "Object" },
                values: new object[] { new Guid("4c3ab4f3-4696-440d-bf43-09c8e5fe87c3"), 50m, "Gazete" });

            migrationBuilder.InsertData(
                table: "Pines",
                columns: new[] { "Id", "CarbonValue", "Object" },
                values: new object[] { new Guid("20046759-c2f9-4ff7-9b60-93b9da00504a"), 200m, "Gazoz Şisesi" });

            migrationBuilder.InsertData(
                table: "Plastics",
                columns: new[] { "Id", "CarbonValue", "Object" },
                values: new object[] { new Guid("f337de15-3cfc-473e-b551-e0ca14c0251c"), 50m, "Su Şişesi" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CarbonAccount", "FullName", "Identity", "Password", "RecycleCoinAccount", "Roles", "UserName" },
                values: new object[] { new Guid("3d9c78f6-6ac2-4e4b-a9a4-b2202e10768a"), 0m, "Admin", "A6AFE2EF9641A327692BD71B4917FB45FC0302023928A8FA73E8A9F69162337B", "Admin", 0m, 1, "Admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Aluminums");

            migrationBuilder.DropTable(
                name: "Irons");

            migrationBuilder.DropTable(
                name: "Papers");

            migrationBuilder.DropTable(
                name: "Pines");

            migrationBuilder.DropTable(
                name: "Plastics");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
