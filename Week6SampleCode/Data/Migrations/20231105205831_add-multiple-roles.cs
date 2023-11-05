using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Week6SampleCode.Data.Migrations
{
    /// <inheritdoc />
    public partial class addmultipleroles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1f79d328-9e0e-4622-a045-2ff44a589d9f", "9deb4ea0-b998-476b-af44-2ce37ab55cb6" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1f79d328-9e0e-4622-a045-2ff44a589d9f");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9deb4ea0-b998-476b-af44-2ce37ab55cb6");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "02a72bc6-1666-48a0-ac62-e95d7ad68c3e", "f35e63ab-cd9d-45d5-8ff7-7e93f2a2979c", "Club Captain", "CLUB CAPTAIN" },
                    { "52efc262-5c40-4698-af4c-f52de3a4f308", "0d9846b1-a439-4542-9833-8ff69bf9dc67", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "9f7dcd0f-e380-4f1d-b1c7-862d0b18acb9", 0, "8aa35b87-e64d-45a5-8ed5-8e769cebaedb", "paul.powell@atu.ie", true, false, null, null, "PAUL.POWELL@ATU.IE", "AQAAAAIAAYagAAAAEJOxa7ErbfNjyTL04K0/Hdmjt+rqX7ox1yGBpG4MnDmN/auQdnJt+k/n3A2F0MsV7A==", null, false, "698d8545-ab32-4285-a294-6d06dd87234c", false, "paul.powell@atu.ie" });

            migrationBuilder.InsertData(
                table: "AspNetUserClaims",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "UserId" },
                values: new object[,]
                {
                    { 1, "http://schemas.microsoft.com/ws/2008/06/identity/claims/role", "Admin", "9f7dcd0f-e380-4f1d-b1c7-862d0b18acb9" },
                    { 2, "http://schemas.microsoft.com/ws/2008/06/identity/claims/role", "Club Captain", "9f7dcd0f-e380-4f1d-b1c7-862d0b18acb9" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "02a72bc6-1666-48a0-ac62-e95d7ad68c3e", "9f7dcd0f-e380-4f1d-b1c7-862d0b18acb9" },
                    { "52efc262-5c40-4698-af4c-f52de3a4f308", "9f7dcd0f-e380-4f1d-b1c7-862d0b18acb9" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "02a72bc6-1666-48a0-ac62-e95d7ad68c3e", "9f7dcd0f-e380-4f1d-b1c7-862d0b18acb9" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "52efc262-5c40-4698-af4c-f52de3a4f308", "9f7dcd0f-e380-4f1d-b1c7-862d0b18acb9" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "02a72bc6-1666-48a0-ac62-e95d7ad68c3e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "52efc262-5c40-4698-af4c-f52de3a4f308");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9f7dcd0f-e380-4f1d-b1c7-862d0b18acb9");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1f79d328-9e0e-4622-a045-2ff44a589d9f", "56404ab5-a01f-4534-930a-190c31429529", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "9deb4ea0-b998-476b-af44-2ce37ab55cb6", 0, "60263460-2702-46a3-9aaf-39b4f67dd7a1", "paul.powell@atu.ie", true, false, null, null, "PAUL.POWELL@ATU.IE", "AQAAAAIAAYagAAAAEBgmcwe9D8Lt1zEBYHQtNIKGxoAmYfppX0fBid7XBKsITYwuCfLSqANbUPuCBsgDrg==", null, false, "babce467-7139-4690-870d-2a27ee72d2c5", false, "paul.powell@atu.ie" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "1f79d328-9e0e-4622-a045-2ff44a589d9f", "9deb4ea0-b998-476b-af44-2ce37ab55cb6" });
        }
    }
}
