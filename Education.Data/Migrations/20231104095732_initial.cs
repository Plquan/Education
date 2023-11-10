using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Education.Data.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppRole",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppRole", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppRoleClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppUserLogins",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProviderKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserLogins", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "AppUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserRoles", x => new { x.UserId, x.RoleId });
                });

            migrationBuilder.CreateTable(
                name: "AppUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserTokens", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Playlists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Thumb = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Playlists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Playlists_AppUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookMarks",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PlaylistId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookMarks", x => new { x.UserId, x.PlaylistId });
                    table.ForeignKey(
                        name: "FK_BookMarks_AppUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookMarks_Playlists_PlaylistId",
                        column: x => x.PlaylistId,
                        principalTable: "Playlists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Contents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlaylistId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Video = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Thumb = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contents_Playlists_PlaylistId",
                        column: x => x.PlaylistId,
                        principalTable: "Playlists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ContentId = table.Column<int>(type: "int", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_AppUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comments_Contents_ContentId",
                        column: x => x.ContentId,
                        principalTable: "Contents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Likes",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ContentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Likes", x => new { x.UserId, x.ContentId });
                    table.ForeignKey(
                        name: "FK_Likes_AppUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Likes_Contents_ContentId",
                        column: x => x.ContentId,
                        principalTable: "Contents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AppRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1ca97892-b6b9-426a-a8ec-c00dc4e70918", "18a08220-e4c5-4d8c-8a5f-cb50e86abe59", "Student", "Student", "Student" },
                    { "8D04DCE2-969A-435D-BBA4-DF3F325983DC", "2143c241-c776-4b6f-a6fd-ff9151a677ca", "Teacher", "Tutor", "Tutor" }
                });

            migrationBuilder.InsertData(
                table: "AppUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "1ca97892-b6b9-426a-a8ec-c00dc4e70918", "1cab8792-b6b9-426a-a8ec-cabdc4e70918" },
                    { "8D04DCE2-969A-435D-BBA4-DF3F325983DC", "69BD714F-9576-45BA-B5B7-F00649BE00DE" }
                });

            migrationBuilder.InsertData(
                table: "AppUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "Image", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "1cab8792-b6b9-426a-a8ec-cabdc4e70918", 0, "c6174dac-55a7-4a46-a39b-1e26fadf1c0a", "Levanquan118@gmail.com", true, "/images/pic-7.jpg", false, null, "Levanquan118@gmail.com", null, "AQAAAAEAACcQAAAAELzAJl2IJD3cFYAJTmSlE46oIxeqnoyh7XyWzZSBtVIPfZZm0bywb5qngZfxM0jVuw==", null, false, "", false, "HeHe" },
                    { "69BD714F-9576-45BA-B5B7-F00649BE00DE", 0, "6cf23fa9-4e7a-4c6d-955f-197a13aadd17", "phamlequan118@gmail.com", true, "/images/pic-1.jpg", false, null, "phamlequan118@gmail.com", null, "AQAAAAEAACcQAAAAEOy2aTY32N9muVCM5lEZvs5eT13epjXBUwy7N+4Wp4HxAMr8YdBrm45H4r3gMvH3IA==", null, false, "", false, "Quan" }
                });

            migrationBuilder.InsertData(
                table: "Playlists",
                columns: new[] { "Id", "DateCreated", "Description", "Status", "Thumb", "Title", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 11, 4, 16, 57, 32, 71, DateTimeKind.Local).AddTicks(6222), "Description", 1, "/images/thumb-1.png", "HTML tutorial", "69BD714F-9576-45BA-B5B7-F00649BE00DE" },
                    { 2, new DateTime(2023, 11, 4, 16, 57, 32, 71, DateTimeKind.Local).AddTicks(6235), "Description", 1, "/images/thumb-2.png", "CSS tutorial", "69BD714F-9576-45BA-B5B7-F00649BE00DE" }
                });

            migrationBuilder.InsertData(
                table: "BookMarks",
                columns: new[] { "PlaylistId", "UserId" },
                values: new object[,]
                {
                    { 1, "1cab8792-b6b9-426a-a8ec-cabdc4e70918" },
                    { 2, "1cab8792-b6b9-426a-a8ec-cabdc4e70918" }
                });

            migrationBuilder.InsertData(
                table: "Contents",
                columns: new[] { "Id", "DateCreated", "Description", "PlaylistId", "Status", "Thumb", "Title", "Video" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 11, 4, 16, 57, 32, 71, DateTimeKind.Local).AddTicks(6272), "cai lmao", 1, 1, "/images/post-1-1.png", "HTML tutorial (Part 1)", "/images/vid-1.mp4" },
                    { 2, new DateTime(2023, 11, 4, 16, 57, 32, 71, DateTimeKind.Local).AddTicks(6274), "cai lmao", 1, 1, "/images/post-1-2.png", "HTML tutorial (Part 2)", "/images/vid-1.mp4" },
                    { 3, new DateTime(2023, 11, 4, 16, 57, 32, 71, DateTimeKind.Local).AddTicks(6276), "cai lmao", 1, 1, "/images/post-1-3.png", "HTML tutorial (Part 3)", "/images/vid-1.mp4" },
                    { 4, new DateTime(2023, 11, 4, 16, 57, 32, 71, DateTimeKind.Local).AddTicks(6277), "cai lmao", 1, 1, "/images/post-1-4.png", "HTML tutorial (Part 4)", "/images/vid-1.mp4" },
                    { 5, new DateTime(2023, 11, 4, 16, 57, 32, 71, DateTimeKind.Local).AddTicks(6280), "cai lmao", 2, 1, "/images/post-2-1.png", "HTML tutorial (Part 1)", "/images/vid-2.mp4" },
                    { 6, new DateTime(2023, 11, 4, 16, 57, 32, 71, DateTimeKind.Local).AddTicks(6281), "cai lmao", 2, 1, "/images/post-2-2.png", "HTML tutorial (Part 2)", "/images/vid-2.mp4" },
                    { 7, new DateTime(2023, 11, 4, 16, 57, 32, 71, DateTimeKind.Local).AddTicks(6282), "cai lmao", 2, 1, "/images/post-2-3.png", "HTML tutorial (Part 3)", "/images/vid-2.mp4" },
                    { 8, new DateTime(2023, 11, 4, 16, 57, 32, 71, DateTimeKind.Local).AddTicks(6284), "cai lmao", 2, 1, "/images/post-2-4.png", "HTML tutorial (Part 4)", "/images/vid-2.mp4" }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "ContentId", "DateCreated", "Message", "UserId" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2023, 11, 4, 16, 57, 32, 71, DateTimeKind.Local).AddTicks(6384), "xin chao casc ban", "1cab8792-b6b9-426a-a8ec-cabdc4e70918" },
                    { 2, 2, new DateTime(2023, 11, 4, 16, 57, 32, 71, DateTimeKind.Local).AddTicks(6386), "xin chao casc ban 2", "1cab8792-b6b9-426a-a8ec-cabdc4e70918" }
                });

            migrationBuilder.InsertData(
                table: "Likes",
                columns: new[] { "ContentId", "UserId" },
                values: new object[,]
                {
                    { 1, "1cab8792-b6b9-426a-a8ec-cabdc4e70918" },
                    { 2, "1cab8792-b6b9-426a-a8ec-cabdc4e70918" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookMarks_PlaylistId",
                table: "BookMarks",
                column: "PlaylistId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ContentId",
                table: "Comments",
                column: "ContentId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserId",
                table: "Comments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Contents_PlaylistId",
                table: "Contents",
                column: "PlaylistId");

            migrationBuilder.CreateIndex(
                name: "IX_Likes_ContentId",
                table: "Likes",
                column: "ContentId");

            migrationBuilder.CreateIndex(
                name: "IX_Playlists_UserId",
                table: "Playlists",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppRole");

            migrationBuilder.DropTable(
                name: "AppRoleClaims");

            migrationBuilder.DropTable(
                name: "AppUserClaims");

            migrationBuilder.DropTable(
                name: "AppUserLogins");

            migrationBuilder.DropTable(
                name: "AppUserRoles");

            migrationBuilder.DropTable(
                name: "AppUserTokens");

            migrationBuilder.DropTable(
                name: "BookMarks");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Likes");

            migrationBuilder.DropTable(
                name: "Contents");

            migrationBuilder.DropTable(
                name: "Playlists");

            migrationBuilder.DropTable(
                name: "AppUsers");
        }
    }
}
