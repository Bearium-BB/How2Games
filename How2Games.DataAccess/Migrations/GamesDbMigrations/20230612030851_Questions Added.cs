using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace How2Games.DataAccess.Migrations.GamesDbMigrations
{
    /// <inheritdoc />
    public partial class QuestionsAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Answers_Question_QuestionId",
                table: "Answers");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Question_QuestionId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Question_Games_GameId",
                table: "Question");

            migrationBuilder.DropForeignKey(
                name: "FK_VoteQuestion_Question_QuestionId",
                table: "VoteQuestion");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Question",
                table: "Question");

            migrationBuilder.RenameTable(
                name: "Question",
                newName: "Questions");

            migrationBuilder.RenameIndex(
                name: "IX_Question_GameId",
                table: "Questions",
                newName: "IX_Questions_GameId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Questions",
                table: "Questions",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "aff7f212-92c0-473d-8855-71b43a126443");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "f3c72bd5-97ce-450d-871e-b6af939f2456");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "3cf9dec4-409f-4676-85cc-1d8c9b3b96c3");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b7ac3d84-d8a8-4628-a254-be921b4b5630",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2927610d-8609-4dac-8d3d-b57476370dec", "AQAAAAEAACcQAAAAEB4psrwLzicPhpELFBRMrHYGykqPT6WeVFCesqmr0OJbSzoc0kSbX44AHb/zImXAhg==", "94f870ac-c01e-43c2-995b-675915d737eb" });

            migrationBuilder.AddForeignKey(
                name: "FK_Answers_Questions_QuestionId",
                table: "Answers",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Questions_QuestionId",
                table: "Comments",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Games_GameId",
                table: "Questions",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VoteQuestion_Questions_QuestionId",
                table: "VoteQuestion",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Answers_Questions_QuestionId",
                table: "Answers");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Questions_QuestionId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Games_GameId",
                table: "Questions");

            migrationBuilder.DropForeignKey(
                name: "FK_VoteQuestion_Questions_QuestionId",
                table: "VoteQuestion");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Questions",
                table: "Questions");

            migrationBuilder.RenameTable(
                name: "Questions",
                newName: "Question");

            migrationBuilder.RenameIndex(
                name: "IX_Questions_GameId",
                table: "Question",
                newName: "IX_Question_GameId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Question",
                table: "Question",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "325afce0-6f02-4a98-8592-74540b7d306b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "224a8358-8580-4e51-9ec4-7771fe4ac311");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "7e9cc4e4-52d3-4643-be70-aa1aa060b269");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b7ac3d84-d8a8-4628-a254-be921b4b5630",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fca5ea9a-3dda-476e-99d3-44e3af62087c", "AQAAAAEAACcQAAAAEBPYVIYk/BmI1Htx9TWOTH/GtM9jneX05wKjPrcLyoziRiRzu+I5tb6uoulIukGHug==", "f13c8ad2-2ce1-4807-88fb-68cdde6e7567" });

            migrationBuilder.AddForeignKey(
                name: "FK_Answers_Question_QuestionId",
                table: "Answers",
                column: "QuestionId",
                principalTable: "Question",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Question_QuestionId",
                table: "Comments",
                column: "QuestionId",
                principalTable: "Question",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Question_Games_GameId",
                table: "Question",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VoteQuestion_Question_QuestionId",
                table: "VoteQuestion",
                column: "QuestionId",
                principalTable: "Question",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
