using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TrashCollectorV2.Data.Migrations
{
    public partial class addedNextPickupDayVariableToAccount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "95bf92a4-5ed4-4b58-b708-9689ecba0672");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9e9393bd-c063-4c02-8191-a86d314395f7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d80f94a1-aa8c-4a74-8c74-6e44725dfe62");

            migrationBuilder.AddColumn<DateTime>(
                name: "NextPickup",
                table: "Accounts",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "NextPickup",
                table: "Accounts");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d80f94a1-aa8c-4a74-8c74-6e44725dfe62", "2fae2a40-5e92-4527-9626-ad344c561e7f", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9e9393bd-c063-4c02-8191-a86d314395f7", "b36915b8-5335-45de-bd3d-f5475ad34ed4", "Employee", "EMPLOYEE" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "95bf92a4-5ed4-4b58-b708-9689ecba0672", "a4e117d9-9ad4-469d-8201-e672a13b5d0a", "Customer", "CUSTOMER" });
        }
    }
}
