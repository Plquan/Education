using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Education.Data.Migrations
{
    /// <inheritdoc />
    public partial class updateuser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AppRole",
                keyColumn: "Id",
                keyValue: "8D04DCE2-969A-435D-BBA4-DF3F325983DC",
                column: "ConcurrencyStamp",
                value: "351ed65f-2b79-4c2f-92db-2c9fa680427d");

            migrationBuilder.UpdateData(
                table: "AppRole",
                keyColumn: "Id",
                keyValue: "8E04DCE2-970A-435D-BBA4-DF3F325983DC",
                column: "ConcurrencyStamp",
                value: "55de9683-f1cb-4111-a159-7600709e63a2");

            migrationBuilder.InsertData(
                table: "AppUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "8D04DCE2-969A-435D-BBA4-DF3F325983DC", "69BD714F-9576-45BA-B5B7-F00649BE00DE" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: "69BD714F-9576-45BA-B5B7-F00649BE00DE",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "3db32e4f-0d29-4733-8588-5aa9fed039bf", "AQAAAAEAACcQAAAAEPfX9BrTEKuwGQK1x2y01ur7GfSySjsK/88p76X1gxtEgBegDQM81WgUrT7rYxgnmg==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: "70BD714F-9576-45BA-B5B7-F00649BE00DE",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "42c7e74d-c6d7-4e5f-8032-6aec5c80d990", "AQAAAAEAACcQAAAAENIrs4RCCpvEzowJmdhYvS4vkI4wiHDOZsDj8lsGeB6bKeCOJKjMB1vzdS4bosnYBg==" });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2024, 1, 1, 14, 26, 57, 659, DateTimeKind.Local).AddTicks(3780));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2024, 1, 1, 14, 26, 57, 659, DateTimeKind.Local).AddTicks(3782));

            migrationBuilder.UpdateData(
                table: "Contents",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2024, 1, 1, 14, 26, 57, 659, DateTimeKind.Local).AddTicks(3744));

            migrationBuilder.UpdateData(
                table: "Contents",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2024, 1, 1, 14, 26, 57, 659, DateTimeKind.Local).AddTicks(3746));

            migrationBuilder.UpdateData(
                table: "Contents",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2024, 1, 1, 14, 26, 57, 659, DateTimeKind.Local).AddTicks(3747));

            migrationBuilder.UpdateData(
                table: "Contents",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2024, 1, 1, 14, 26, 57, 659, DateTimeKind.Local).AddTicks(3748));

            migrationBuilder.UpdateData(
                table: "Contents",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateCreated",
                value: new DateTime(2024, 1, 1, 14, 26, 57, 659, DateTimeKind.Local).AddTicks(3749));

            migrationBuilder.UpdateData(
                table: "Contents",
                keyColumn: "Id",
                keyValue: 6,
                column: "DateCreated",
                value: new DateTime(2024, 1, 1, 14, 26, 57, 659, DateTimeKind.Local).AddTicks(3749));

            migrationBuilder.UpdateData(
                table: "Contents",
                keyColumn: "Id",
                keyValue: 7,
                column: "DateCreated",
                value: new DateTime(2024, 1, 1, 14, 26, 57, 659, DateTimeKind.Local).AddTicks(3751));

            migrationBuilder.UpdateData(
                table: "Contents",
                keyColumn: "Id",
                keyValue: 8,
                column: "DateCreated",
                value: new DateTime(2024, 1, 1, 14, 26, 57, 659, DateTimeKind.Local).AddTicks(3752));

            migrationBuilder.UpdateData(
                table: "Playlists",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2024, 1, 1, 14, 26, 57, 659, DateTimeKind.Local).AddTicks(3710));

            migrationBuilder.UpdateData(
                table: "Playlists",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2024, 1, 1, 14, 26, 57, 659, DateTimeKind.Local).AddTicks(3721));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "8D04DCE2-969A-435D-BBA4-DF3F325983DC", "69BD714F-9576-45BA-B5B7-F00649BE00DE" });

            migrationBuilder.UpdateData(
                table: "AppRole",
                keyColumn: "Id",
                keyValue: "8D04DCE2-969A-435D-BBA4-DF3F325983DC",
                column: "ConcurrencyStamp",
                value: "0cabaaff-f6f8-4203-9c25-c323da89d567");

            migrationBuilder.UpdateData(
                table: "AppRole",
                keyColumn: "Id",
                keyValue: "8E04DCE2-970A-435D-BBA4-DF3F325983DC",
                column: "ConcurrencyStamp",
                value: "3d94ed3f-b26c-4edb-9521-5b13ef9c284b");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: "69BD714F-9576-45BA-B5B7-F00649BE00DE",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "5ca22ef4-abbc-4515-9cfd-d62ca56682f0", "AQAAAAEAACcQAAAAEF+xi6umeFThg8mWfzRfwLlZGN1z/sVwHi8UFOSWAZEQ1fNtlNLgC1iXfDkeIB94EA==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: "70BD714F-9576-45BA-B5B7-F00649BE00DE",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e4616f74-f8e2-47f0-ac2f-4c0ff8f7ddeb", "AQAAAAEAACcQAAAAEEvWYy91Fr0n3K13WVPzkSSPBxAkFCJ1v/zI6whTf4x5yESBk9ebRaIp6Ow8hI5VCA==" });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2024, 1, 1, 14, 14, 2, 772, DateTimeKind.Local).AddTicks(2364));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2024, 1, 1, 14, 14, 2, 772, DateTimeKind.Local).AddTicks(2366));

            migrationBuilder.UpdateData(
                table: "Contents",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2024, 1, 1, 14, 14, 2, 772, DateTimeKind.Local).AddTicks(2320));

            migrationBuilder.UpdateData(
                table: "Contents",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2024, 1, 1, 14, 14, 2, 772, DateTimeKind.Local).AddTicks(2322));

            migrationBuilder.UpdateData(
                table: "Contents",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2024, 1, 1, 14, 14, 2, 772, DateTimeKind.Local).AddTicks(2323));

            migrationBuilder.UpdateData(
                table: "Contents",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2024, 1, 1, 14, 14, 2, 772, DateTimeKind.Local).AddTicks(2324));

            migrationBuilder.UpdateData(
                table: "Contents",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateCreated",
                value: new DateTime(2024, 1, 1, 14, 14, 2, 772, DateTimeKind.Local).AddTicks(2325));

            migrationBuilder.UpdateData(
                table: "Contents",
                keyColumn: "Id",
                keyValue: 6,
                column: "DateCreated",
                value: new DateTime(2024, 1, 1, 14, 14, 2, 772, DateTimeKind.Local).AddTicks(2325));

            migrationBuilder.UpdateData(
                table: "Contents",
                keyColumn: "Id",
                keyValue: 7,
                column: "DateCreated",
                value: new DateTime(2024, 1, 1, 14, 14, 2, 772, DateTimeKind.Local).AddTicks(2327));

            migrationBuilder.UpdateData(
                table: "Contents",
                keyColumn: "Id",
                keyValue: 8,
                column: "DateCreated",
                value: new DateTime(2024, 1, 1, 14, 14, 2, 772, DateTimeKind.Local).AddTicks(2328));

            migrationBuilder.UpdateData(
                table: "Playlists",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2024, 1, 1, 14, 14, 2, 772, DateTimeKind.Local).AddTicks(2297));

            migrationBuilder.UpdateData(
                table: "Playlists",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2024, 1, 1, 14, 14, 2, 772, DateTimeKind.Local).AddTicks(2308));
        }
    }
}
