using Microsoft.EntityFrameworkCore.Migrations;

namespace TrashCollectorV2.Data.Migrations
{
    public partial class ChangedDisplayNamesAndPickupDayType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5508fb86-f067-44ef-a7cd-8cf3a204c406");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e82919a4-c9e3-411c-b0ee-2affdba1c21b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fcfa0ad8-b25e-43b9-9974-405f82527c38");

            migrationBuilder.AlterColumn<int>(
                name: "PickupDay",
                table: "Pickups",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c1088a30-df3e-4c63-b09c-dfed1f75c77b", "28589daa-fbe5-4b1d-9e45-3da4afd3cb3d", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "67ba77ae-ea3a-483b-bc6d-297c9c81f8d6", "6ae1c94f-5afd-4920-b807-57308cc43342", "Employee", "EMPLOYEE" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1981b763-c28b-4eb2-935c-148edb9854f1", "7b4d2783-330e-41e7-b779-2ec669fd641e", "Customer", "CUSTOMER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1981b763-c28b-4eb2-935c-148edb9854f1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "67ba77ae-ea3a-483b-bc6d-297c9c81f8d6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c1088a30-df3e-4c63-b09c-dfed1f75c77b");

            migrationBuilder.AlterColumn<string>(
                name: "PickupDay",
                table: "Pickups",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "fcfa0ad8-b25e-43b9-9974-405f82527c38", "e0b3760e-9276-4c40-b51c-db8a7ad8c49a", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e82919a4-c9e3-411c-b0ee-2affdba1c21b", "c05c9b87-309c-4d41-a5e5-fa1933868ea0", "Employee", "EMPLOYEE" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5508fb86-f067-44ef-a7cd-8cf3a204c406", "93598f83-2bba-4d2f-9370-3867442074e0", "Customer", "CUSTOMER" });
        }
    }
}
