using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Education.Data.Migrations
{
    /// <inheritdoc />
    public partial class content : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Video",
                table: "Contents",
                type: "nvarchar(120)",
                maxLength: 120,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Thumb",
                table: "Contents",
                type: "nvarchar(120)",
                maxLength: 120,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.UpdateData(
                table: "AppRole",
                keyColumn: "Id",
                keyValue: "1ca97892-b6b9-426a-a8ec-c00dc4e70918",
                column: "ConcurrencyStamp",
                value: "1f25d1fc-220c-42a2-aafc-6c011636aa18");

            migrationBuilder.UpdateData(
                table: "AppRole",
                keyColumn: "Id",
                keyValue: "8D04DCE2-969A-435D-BBA4-DF3F325983DC",
                column: "ConcurrencyStamp",
                value: "b0a2cf22-d2f5-4705-b24c-59635e1c7199");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: "1cab8792-b6b9-426a-a8ec-cabdc4e70918",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "9db7875a-5cf9-4a27-aebd-8a08be47dbe6", "AQAAAAEAACcQAAAAEO57xgPWmmG7Cry32aWE1zCAaHnKIj6ejD/19qMETuZMMpGFsZo2XMoUouwbpi8LBA==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: "69BD714F-9576-45BA-B5B7-F00649BE00DE",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e9c0ca23-0ba2-4a4a-a7ee-96f58343ab71", "AQAAAAEAACcQAAAAED5pvzUVIesRzeg82Ty3OaoHRsdtVUTgx2lcVmcD/TebglMHpIz0VAlOuP1cLlbkfQ==" });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2023, 12, 7, 21, 56, 34, 159, DateTimeKind.Local).AddTicks(5909));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2023, 12, 7, 21, 56, 34, 159, DateTimeKind.Local).AddTicks(5910));

            migrationBuilder.UpdateData(
                table: "Contents",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2023, 12, 7, 21, 56, 34, 159, DateTimeKind.Local).AddTicks(5883));

            migrationBuilder.UpdateData(
                table: "Contents",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2023, 12, 7, 21, 56, 34, 159, DateTimeKind.Local).AddTicks(5884));

            migrationBuilder.UpdateData(
                table: "Contents",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2023, 12, 7, 21, 56, 34, 159, DateTimeKind.Local).AddTicks(5885));

            migrationBuilder.UpdateData(
                table: "Contents",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2023, 12, 7, 21, 56, 34, 159, DateTimeKind.Local).AddTicks(5886));

            migrationBuilder.UpdateData(
                table: "Contents",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateCreated",
                value: new DateTime(2023, 12, 7, 21, 56, 34, 159, DateTimeKind.Local).AddTicks(5887));

            migrationBuilder.UpdateData(
                table: "Contents",
                keyColumn: "Id",
                keyValue: 6,
                column: "DateCreated",
                value: new DateTime(2023, 12, 7, 21, 56, 34, 159, DateTimeKind.Local).AddTicks(5889));

            migrationBuilder.UpdateData(
                table: "Contents",
                keyColumn: "Id",
                keyValue: 7,
                column: "DateCreated",
                value: new DateTime(2023, 12, 7, 21, 56, 34, 159, DateTimeKind.Local).AddTicks(5890));

            migrationBuilder.UpdateData(
                table: "Contents",
                keyColumn: "Id",
                keyValue: 8,
                column: "DateCreated",
                value: new DateTime(2023, 12, 7, 21, 56, 34, 159, DateTimeKind.Local).AddTicks(5891));

            migrationBuilder.UpdateData(
                table: "Playlists",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2023, 12, 7, 21, 56, 34, 159, DateTimeKind.Local).AddTicks(5861));

            migrationBuilder.UpdateData(
                table: "Playlists",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2023, 12, 7, 21, 56, 34, 159, DateTimeKind.Local).AddTicks(5870));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Video",
                table: "Contents",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(120)",
                oldMaxLength: 120);

            migrationBuilder.AlterColumn<string>(
                name: "Thumb",
                table: "Contents",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(120)",
                oldMaxLength: 120);

            migrationBuilder.UpdateData(
                table: "AppRole",
                keyColumn: "Id",
                keyValue: "1ca97892-b6b9-426a-a8ec-c00dc4e70918",
                column: "ConcurrencyStamp",
                value: "d0286e3e-5cc1-488d-8f95-34db515a9e99");

            migrationBuilder.UpdateData(
                table: "AppRole",
                keyColumn: "Id",
                keyValue: "8D04DCE2-969A-435D-BBA4-DF3F325983DC",
                column: "ConcurrencyStamp",
                value: "d59ac540-cb68-48bf-b8b0-0faf9aa02014");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: "1cab8792-b6b9-426a-a8ec-cabdc4e70918",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "c5bcdd7f-a46a-4182-8c01-c2403e7839aa", "AQAAAAEAACcQAAAAEIc8sm74V+TNmGDw0pLVa8IB6B+JO6fbMGvhxncYgI+rEOgHvr8eu+0FAt21NDtgow==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: "69BD714F-9576-45BA-B5B7-F00649BE00DE",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "9fb8d2e3-727f-47ed-9591-e910d2b1f820", "AQAAAAEAACcQAAAAENcJsOD7nm7smb8H67yyKd3b+ynPtxXMfCWaSkYXrgFSVz+Nzs1lRPlqqSZ7JV8FZg==" });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2023, 12, 5, 22, 18, 40, 806, DateTimeKind.Local).AddTicks(9193));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2023, 12, 5, 22, 18, 40, 806, DateTimeKind.Local).AddTicks(9195));

            migrationBuilder.UpdateData(
                table: "Contents",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2023, 12, 5, 22, 18, 40, 806, DateTimeKind.Local).AddTicks(9122));

            migrationBuilder.UpdateData(
                table: "Contents",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2023, 12, 5, 22, 18, 40, 806, DateTimeKind.Local).AddTicks(9124));

            migrationBuilder.UpdateData(
                table: "Contents",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2023, 12, 5, 22, 18, 40, 806, DateTimeKind.Local).AddTicks(9125));

            migrationBuilder.UpdateData(
                table: "Contents",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2023, 12, 5, 22, 18, 40, 806, DateTimeKind.Local).AddTicks(9126));

            migrationBuilder.UpdateData(
                table: "Contents",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateCreated",
                value: new DateTime(2023, 12, 5, 22, 18, 40, 806, DateTimeKind.Local).AddTicks(9126));

            migrationBuilder.UpdateData(
                table: "Contents",
                keyColumn: "Id",
                keyValue: 6,
                column: "DateCreated",
                value: new DateTime(2023, 12, 5, 22, 18, 40, 806, DateTimeKind.Local).AddTicks(9127));

            migrationBuilder.UpdateData(
                table: "Contents",
                keyColumn: "Id",
                keyValue: 7,
                column: "DateCreated",
                value: new DateTime(2023, 12, 5, 22, 18, 40, 806, DateTimeKind.Local).AddTicks(9128));

            migrationBuilder.UpdateData(
                table: "Contents",
                keyColumn: "Id",
                keyValue: 8,
                column: "DateCreated",
                value: new DateTime(2023, 12, 5, 22, 18, 40, 806, DateTimeKind.Local).AddTicks(9129));

            migrationBuilder.UpdateData(
                table: "Playlists",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2023, 12, 5, 22, 18, 40, 806, DateTimeKind.Local).AddTicks(9086));

            migrationBuilder.UpdateData(
                table: "Playlists",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2023, 12, 5, 22, 18, 40, 806, DateTimeKind.Local).AddTicks(9098));
        }
    }
}
