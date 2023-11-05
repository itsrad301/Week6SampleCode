using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Week6SampleCode.Data.Migrations
{
    /// <inheritdoc />
    public partial class Addingrole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1da5ac99-5c77-434b-8be4-3bfb227613f7");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "1da5ac99-5c77-434b-8be4-3bfb227613f7", 0, "e3499b4f-cc8a-4e0e-8db8-f67032825c73", "paul.powell@atu.ie", true, false, null, null, "PAUL.POWELL@ATU.IE", "AQAAAAIAAYagAAAAEP0S2IzII6M0aizJF/gAQMLpBVmbrF99inRjLjEqVVoWZX0mYKcvJ5WmdGrUv8LVsg==", null, false, "10a6a55b-3afe-4265-a79a-3ab55ab17ee5", false, "paul.powell@atu.ie" });
        }
    }
}
