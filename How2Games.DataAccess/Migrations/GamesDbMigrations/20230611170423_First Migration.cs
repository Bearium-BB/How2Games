using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace How2Games.DataAccess.Migrations.GamesDbMigrations
{
    /// <inheritdoc />
    public partial class FirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Text",
                table: "Question",
                newName: "HTML");

            migrationBuilder.RenameColumn(
                name: "Text",
                table: "Comments",
                newName: "HTML");

            migrationBuilder.RenameColumn(
                name: "Text",
                table: "Answers",
                newName: "HTML");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Question",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1", "325afce0-6f02-4a98-8592-74540b7d306b", "Admin", "ADMIN" },
                    { "2", "224a8358-8580-4e51-9ec4-7771fe4ac311", "User", "USER" },
                    { "3", "7e9cc4e4-52d3-4643-be70-aa1aa060b269", "Blacklist", "BLACKLISTED" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "b7ac3d84-d8a8-4628-a254-be921b4b5630", 0, "fca5ea9a-3dda-476e-99d3-44e3af62087c", "abc1@gmail.com", false, "Zack Zed", false, null, null, null, "AQAAAAEAACcQAAAAEBPYVIYk/BmI1Htx9TWOTH/GtM9jneX05wKjPrcLyoziRiRzu+I5tb6uoulIukGHug==", null, false, "f13c8ad2-2ce1-4807-88fb-68cdde6e7567", false, "ZackZad" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "1", "b7ac3d84-d8a8-4628-a254-be921b4b5630" });

            migrationBuilder.CreateIndex(
                name: "IX_Answers_QuestionId",
                table: "Answers",
                column: "QuestionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Answers_Question_QuestionId",
                table: "Answers",
                column: "QuestionId",
                principalTable: "Question",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Answers_Question_QuestionId",
                table: "Answers");

            migrationBuilder.DropIndex(
                name: "IX_Answers_QuestionId",
                table: "Answers");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1", "b7ac3d84-d8a8-4628-a254-be921b4b5630" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b7ac3d84-d8a8-4628-a254-be921b4b5630");

            migrationBuilder.RenameColumn(
                name: "HTML",
                table: "Question",
                newName: "Text");

            migrationBuilder.RenameColumn(
                name: "HTML",
                table: "Comments",
                newName: "Text");

            migrationBuilder.RenameColumn(
                name: "HTML",
                table: "Answers",
                newName: "Text");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Question",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
