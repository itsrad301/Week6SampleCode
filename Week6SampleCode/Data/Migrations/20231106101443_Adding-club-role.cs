using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Week6SampleCode.Data.Migrations
{
    /// <inheritdoc />
    public partial class Addingclubrole : Migration
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
                    { "643bcab1-60c3-47b3-9248-ee42e91b11c1", "ddc88d95-d903-404b-aae4-d10867b4138b", "Club Captain", "CLUB CAPTAIN" },
                    { "82318110-804b-4126-afa0-67c519ff542c", "dad4fec5-6752-4f17-9960-101e326b8a25", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "e924efdf-c056-4467-b1a1-0b4ecd2ccbbe", 0, "07f6df0a-05d6-46a7-8c67-a339bf00612f", "paul.powell@atu.ie", true, false, null, null, "PAUL.POWELL@ATU.IE", "AQAAAAIAAYagAAAAEJ/qzIf46kgHbhMBv5WBgoZJUUzHNppcQkhODEIhZE09nJ91lm8iRlM3RDPLf1vTxg==", null, false, "71a5ea5b-8b0d-44eb-bdec-2db58ec932e8", false, "paul.powell@atu.ie" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "643bcab1-60c3-47b3-9248-ee42e91b11c1", "e924efdf-c056-4467-b1a1-0b4ecd2ccbbe" },
                    { "82318110-804b-4126-afa0-67c519ff542c", "e924efdf-c056-4467-b1a1-0b4ecd2ccbbe" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "643bcab1-60c3-47b3-9248-ee42e91b11c1", "e924efdf-c056-4467-b1a1-0b4ecd2ccbbe" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "82318110-804b-4126-afa0-67c519ff542c", "e924efdf-c056-4467-b1a1-0b4ecd2ccbbe" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "643bcab1-60c3-47b3-9248-ee42e91b11c1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "82318110-804b-4126-afa0-67c519ff542c");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e924efdf-c056-4467-b1a1-0b4ecd2ccbbe");

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
