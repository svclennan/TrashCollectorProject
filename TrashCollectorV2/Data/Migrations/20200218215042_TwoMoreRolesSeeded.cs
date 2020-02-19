using Microsoft.EntityFrameworkCore.Migrations;

namespace TrashCollectorV2.Data.Migrations
{
    public partial class TwoMoreRolesSeeded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6e4d9bc6-47e4-4247-aa31-b2050212cc1f");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f28f335d-f7df-43ff-88ac-a0c5d502d657", "8198f924-f581-4d92-b21f-c08fb98f2986", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0acba0db-9cfd-4a0a-b1a7-21bc1563da7d", "54119a21-45aa-43ac-bca3-a5cd84b76df5", "Employee", "EMPLOYEE" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1fa23f2b-e638-4238-b3a9-15236fbdcd34", "06a5a97a-dcc3-49ae-848b-3eea240541bc", "Customer", "CUSTOMER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0acba0db-9cfd-4a0a-b1a7-21bc1563da7d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1fa23f2b-e638-4238-b3a9-15236fbdcd34");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f28f335d-f7df-43ff-88ac-a0c5d502d657");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6e4d9bc6-47e4-4247-aa31-b2050212cc1f", "8d21c19a-0dd0-4f4c-afd4-5139880444fc", "Admin", "ADMIN" });
        }
    }
}
