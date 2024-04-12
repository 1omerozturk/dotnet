using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StoreApp.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2bfa87ce-6ed8-4afe-a473-6073b47e01bc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c96a870a-19ee-411f-8c92-648afa46f444");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "db36e663-a721-4c58-9fdd-6c57ad6d7d67");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6ebafd6b-0e29-40e4-910f-f8c4fefd66b9", "140705b1-ebad-4bcb-92b0-760402f00302", "Editor", "EDITOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d27e6e8a-39b2-4971-a394-280911dbb3d8", "d63ab005-e206-4954-84ad-a2a534a16497", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f227a2db-7415-48d3-b79c-e9f51c0647ef", "ca483a2f-5427-4e52-a75f-f56b15347b6c", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6ebafd6b-0e29-40e4-910f-f8c4fefd66b9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d27e6e8a-39b2-4971-a394-280911dbb3d8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f227a2db-7415-48d3-b79c-e9f51c0647ef");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2bfa87ce-6ed8-4afe-a473-6073b47e01bc", "a913c49a-2bfc-4255-9648-e59e597b6937", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c96a870a-19ee-411f-8c92-648afa46f444", "82455fb7-853b-4d31-b753-997f722c9a84", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "db36e663-a721-4c58-9fdd-6c57ad6d7d67", "b96bc7f2-9111-471b-a89f-bf35620d3edd", "Editor", "EDITOR" });
        }
    }
}
