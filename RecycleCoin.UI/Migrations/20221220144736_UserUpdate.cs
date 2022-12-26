using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecycleCoin.UI.Migrations
{
    public partial class UserUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Aluminums",
                keyColumn: "Id",
                keyValue: new Guid("d4b4102d-9ebf-41cb-bbed-91f324339818"));

            migrationBuilder.DeleteData(
                table: "Irons",
                keyColumn: "Id",
                keyValue: new Guid("09f78b5e-0b17-4d4c-b0e4-c2f31ee62b5e"));

            migrationBuilder.DeleteData(
                table: "Papers",
                keyColumn: "Id",
                keyValue: new Guid("4c3ab4f3-4696-440d-bf43-09c8e5fe87c3"));

            migrationBuilder.DeleteData(
                table: "Pines",
                keyColumn: "Id",
                keyValue: new Guid("20046759-c2f9-4ff7-9b60-93b9da00504a"));

            migrationBuilder.DeleteData(
                table: "Plastics",
                keyColumn: "Id",
                keyValue: new Guid("f337de15-3cfc-473e-b551-e0ca14c0251c"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("3d9c78f6-6ac2-4e4b-a9a4-b2202e10768a"));

            migrationBuilder.DropColumn(
                name: "CarbonAccount",
                table: "Users");

            migrationBuilder.InsertData(
                table: "Aluminums",
                columns: new[] { "Id", "CarbonValue", "Object" },
                values: new object[] { new Guid("9b4900f3-f9ce-40dc-aa58-4fe0c681c331"), 330m, "Kola Kutusu" });

            migrationBuilder.InsertData(
                table: "Irons",
                columns: new[] { "Id", "CarbonValue", "Object" },
                values: new object[] { new Guid("6784cd47-bccc-4ddd-a38d-75401374b9f5"), 400m, "Pil" });

            migrationBuilder.InsertData(
                table: "Papers",
                columns: new[] { "Id", "CarbonValue", "Object" },
                values: new object[] { new Guid("7eb84f85-459e-4417-bbc9-1654ecb84c63"), 50m, "Gazete" });

            migrationBuilder.InsertData(
                table: "Pines",
                columns: new[] { "Id", "CarbonValue", "Object" },
                values: new object[] { new Guid("70108e90-c3c2-480e-956f-504b222371e4"), 200m, "Gazoz Şisesi" });

            migrationBuilder.InsertData(
                table: "Plastics",
                columns: new[] { "Id", "CarbonValue", "Object" },
                values: new object[] { new Guid("83ac8f5f-e9a7-46dc-acbc-ccc0b601c241"), 50m, "Su Şişesi" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FullName", "Identity", "Password", "RecycleCoinAccount", "Roles", "UserName" },
                values: new object[] { new Guid("68e2b0d9-00b3-4e92-809a-a0ffc9a5fcd8"), "Admin", "17B8B50331A934BD2821B15FE88FB3B8AF0CA093D86B0757ED70DD4F0F868619", "Admin", 0m, 1, "Admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Aluminums",
                keyColumn: "Id",
                keyValue: new Guid("9b4900f3-f9ce-40dc-aa58-4fe0c681c331"));

            migrationBuilder.DeleteData(
                table: "Irons",
                keyColumn: "Id",
                keyValue: new Guid("6784cd47-bccc-4ddd-a38d-75401374b9f5"));

            migrationBuilder.DeleteData(
                table: "Papers",
                keyColumn: "Id",
                keyValue: new Guid("7eb84f85-459e-4417-bbc9-1654ecb84c63"));

            migrationBuilder.DeleteData(
                table: "Pines",
                keyColumn: "Id",
                keyValue: new Guid("70108e90-c3c2-480e-956f-504b222371e4"));

            migrationBuilder.DeleteData(
                table: "Plastics",
                keyColumn: "Id",
                keyValue: new Guid("83ac8f5f-e9a7-46dc-acbc-ccc0b601c241"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("68e2b0d9-00b3-4e92-809a-a0ffc9a5fcd8"));

            migrationBuilder.AddColumn<decimal>(
                name: "CarbonAccount",
                table: "Users",
                type: "decimal(18,4)",
                nullable: false,
                defaultValue: 0m);

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
    }
}
