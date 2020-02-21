using Microsoft.EntityFrameworkCore.Migrations;

namespace TrashCollectorV2.Data.Migrations
{
    public partial class AddedThingsToViewModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2830d66b-daf3-4587-9752-8845b1539c97");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "299d56c0-1a83-4523-8a02-aef107f04155");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d4225b04-56bf-4fc3-a975-3379d8af99a1");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "41d11d5b-0c42-43ff-832c-c4f1b43adaf9", "e37e6ff6-510a-4173-8cc9-a78254cea23b", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d89964e4-c42a-427b-bef6-6f07e8b27193", "40c42374-965f-42a7-8dbf-5e014ba5fdd6", "Employee", "EMPLOYEE" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "494e3bce-db20-4772-aa2d-1427c40314d1", "9a8d5d7b-e580-46d3-bfa8-017973adc449", "Customer", "CUSTOMER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "41d11d5b-0c42-43ff-832c-c4f1b43adaf9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "494e3bce-db20-4772-aa2d-1427c40314d1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d89964e4-c42a-427b-bef6-6f07e8b27193");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "299d56c0-1a83-4523-8a02-aef107f04155", "9a2a40df-a4ab-4901-92a4-be3b9ecaff9c", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2830d66b-daf3-4587-9752-8845b1539c97", "8ee1e3b4-0db0-4939-afee-5434857efbef", "Employee", "EMPLOYEE" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d4225b04-56bf-4fc3-a975-3379d8af99a1", "7cd3e96f-2690-4906-9548-98c7dca0f161", "Customer", "CUSTOMER" });
        }
    }
}
