using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TrashCollectorV2.Data.Migrations
{
    public partial class DenormalizationOfAccountAndPickup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_Pickups_PickupId",
                table: "Accounts");

            migrationBuilder.DropTable(
                name: "Pickups");

            migrationBuilder.DropIndex(
                name: "IX_Accounts_PickupId",
                table: "Accounts");

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

            migrationBuilder.DropColumn(
                name: "PickupId",
                table: "Accounts");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "Accounts",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "OneTimePickup",
                table: "Accounts",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "PickupDay",
                table: "Accounts",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "Accounts",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "OneTimePickup",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "PickupDay",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "Accounts");

            migrationBuilder.AddColumn<int>(
                name: "PickupId",
                table: "Accounts",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Pickups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OneTimePickup = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PickupDay = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pickups", x => x.Id);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_PickupId",
                table: "Accounts",
                column: "PickupId");

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_Pickups_PickupId",
                table: "Accounts",
                column: "PickupId",
                principalTable: "Pickups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
