using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Week6SampleCode.Data.Migrations
{
    /// <inheritdoc />
    public partial class roleclaims : Migration
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
                values: new object[] { "6a67e5bb-28c6-46d1-9f41-ac19cd66ae06", "051260a9-b82e-4179-a6ba-b8c0af625c7e", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "5a2b96c7-2da6-4996-ab7b-a213af70db99", 0, "7235deeb-19da-4f15-bf8e-21e68dd97d4c", "paul.powell@atu.ie", true, false, null, null, "PAUL.POWELL@ATU.IE", "AQAAAAIAAYagAAAAENaJpw1jgica/WOLIERgsuAg7dcqM6fHoYD0en6LASa+br/0sv2g2sI7imKS5y2PYA==", null, false, "d6228387-987d-4569-9ae8-bc40a1b20eb8", false, "paul.powell@atu.ie" });

            migrationBuilder.InsertData(
                table: "AspNetUserClaims",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "UserId" },
                values: new object[] { 1, "http://schemas.microsoft.com/ws/2008/06/identity/claims/role", "Admin", "5a2b96c7-2da6-4996-ab7b-a213af70db99" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "6a67e5bb-28c6-46d1-9f41-ac19cd66ae06", "5a2b96c7-2da6-4996-ab7b-a213af70db99" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "6a67e5bb-28c6-46d1-9f41-ac19cd66ae06", "5a2b96c7-2da6-4996-ab7b-a213af70db99" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6a67e5bb-28c6-46d1-9f41-ac19cd66ae06");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5a2b96c7-2da6-4996-ab7b-a213af70db99");

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
