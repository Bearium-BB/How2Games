using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace How2Games.DataAccess.Migrations.GamesDbMigrations
{
    /// <inheritdoc />
    public partial class RemovingSomeManyToManyRelationships : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GameTag");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "PostComments");

            migrationBuilder.DropTable(
                name: "PostImages");

            migrationBuilder.DropTable(
                name: "PostTexts");

            migrationBuilder.DropTable(
                name: "QuestionComments");

            migrationBuilder.DropTable(
                name: "QuestionImages");

            migrationBuilder.DropTable(
                name: "QuestionTexts");

            migrationBuilder.DropTable(
                name: "Texts");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Questions",
                table: "Questions");

            migrationBuilder.RenameTable(
                name: "Questions",
                newName: "Question");

            migrationBuilder.AddColumn<string>(
                name: "How2GamesUserId",
                table: "Posts",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Text",
                table: "Posts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ViewCount",
                table: "Games",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AnswerId",
                table: "Comments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "How2GamesUserId",
                table: "Comments",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PostId",
                table: "Comments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "QuestionId",
                table: "Comments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "How2GamesUserId",
                table: "Answers",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GameId",
                table: "Question",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Text",
                table: "Question",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ViewCount",
                table: "Question",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Question",
                table: "Question",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "DeveloperTags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeveloperTags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GenreTags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenreTags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PublisherTags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PublisherTags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VoteAnswer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    AnswerId = table.Column<int>(type: "int", nullable: false),
                    Vote = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VoteAnswer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VoteAnswer_Answers_AnswerId",
                        column: x => x.AnswerId,
                        principalTable: "Answers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VoteQuestion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    QuestionId = table.Column<int>(type: "int", nullable: false),
                    Vote = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VoteQuestion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VoteQuestion_Question_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Question",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GameDeveloperTag",
                columns: table => new
                {
                    DeveloperTagsId = table.Column<int>(type: "int", nullable: false),
                    GamesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameDeveloperTag", x => new { x.DeveloperTagsId, x.GamesId });
                    table.ForeignKey(
                        name: "FK_GameDeveloperTag_DeveloperTags_DeveloperTagsId",
                        column: x => x.DeveloperTagsId,
                        principalTable: "DeveloperTags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GameDeveloperTag_Games_GamesId",
                        column: x => x.GamesId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GameGenreTag",
                columns: table => new
                {
                    GamesId = table.Column<int>(type: "int", nullable: false),
                    GenreTagsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameGenreTag", x => new { x.GamesId, x.GenreTagsId });
                    table.ForeignKey(
                        name: "FK_GameGenreTag_Games_GamesId",
                        column: x => x.GamesId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GameGenreTag_GenreTags_GenreTagsId",
                        column: x => x.GenreTagsId,
                        principalTable: "GenreTags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GamePublisherTag",
                columns: table => new
                {
                    GamesId = table.Column<int>(type: "int", nullable: false),
                    PublisherTagsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GamePublisherTag", x => new { x.GamesId, x.PublisherTagsId });
                    table.ForeignKey(
                        name: "FK_GamePublisherTag_Games_GamesId",
                        column: x => x.GamesId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GamePublisherTag_PublisherTags_PublisherTagsId",
                        column: x => x.PublisherTagsId,
                        principalTable: "PublisherTags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Posts_How2GamesUserId",
                table: "Posts",
                column: "How2GamesUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_AnswerId",
                table: "Comments",
                column: "AnswerId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_How2GamesUserId",
                table: "Comments",
                column: "How2GamesUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_PostId",
                table: "Comments",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_QuestionId",
                table: "Comments",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_Answers_How2GamesUserId",
                table: "Answers",
                column: "How2GamesUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Question_GameId",
                table: "Question",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_GameDeveloperTag_GamesId",
                table: "GameDeveloperTag",
                column: "GamesId");

            migrationBuilder.CreateIndex(
                name: "IX_GameGenreTag_GenreTagsId",
                table: "GameGenreTag",
                column: "GenreTagsId");

            migrationBuilder.CreateIndex(
                name: "IX_GamePublisherTag_PublisherTagsId",
                table: "GamePublisherTag",
                column: "PublisherTagsId");

            migrationBuilder.CreateIndex(
                name: "IX_VoteAnswer_AnswerId",
                table: "VoteAnswer",
                column: "AnswerId");

            migrationBuilder.CreateIndex(
                name: "IX_VoteQuestion_QuestionId",
                table: "VoteQuestion",
                column: "QuestionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Answers_AspNetUsers_How2GamesUserId",
                table: "Answers",
                column: "How2GamesUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Answers_AnswerId",
                table: "Comments",
                column: "AnswerId",
                principalTable: "Answers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_AspNetUsers_How2GamesUserId",
                table: "Comments",
                column: "How2GamesUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Posts_PostId",
                table: "Comments",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Question_QuestionId",
                table: "Comments",
                column: "QuestionId",
                principalTable: "Question",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_AspNetUsers_How2GamesUserId",
                table: "Posts",
                column: "How2GamesUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Question_Games_GameId",
                table: "Question",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Answers_AspNetUsers_How2GamesUserId",
                table: "Answers");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Answers_AnswerId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_AspNetUsers_How2GamesUserId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Posts_PostId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Question_QuestionId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Posts_AspNetUsers_How2GamesUserId",
                table: "Posts");

            migrationBuilder.DropForeignKey(
                name: "FK_Question_Games_GameId",
                table: "Question");

            migrationBuilder.DropTable(
                name: "GameDeveloperTag");

            migrationBuilder.DropTable(
                name: "GameGenreTag");

            migrationBuilder.DropTable(
                name: "GamePublisherTag");

            migrationBuilder.DropTable(
                name: "VoteAnswer");

            migrationBuilder.DropTable(
                name: "VoteQuestion");

            migrationBuilder.DropTable(
                name: "DeveloperTags");

            migrationBuilder.DropTable(
                name: "GenreTags");

            migrationBuilder.DropTable(
                name: "PublisherTags");

            migrationBuilder.DropIndex(
                name: "IX_Posts_How2GamesUserId",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Comments_AnswerId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_How2GamesUserId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_PostId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_QuestionId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Answers_How2GamesUserId",
                table: "Answers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Question",
                table: "Question");

            migrationBuilder.DropIndex(
                name: "IX_Question_GameId",
                table: "Question");

            migrationBuilder.DropColumn(
                name: "How2GamesUserId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "Text",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "ViewCount",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "AnswerId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "How2GamesUserId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "PostId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "QuestionId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "How2GamesUserId",
                table: "Answers");

            migrationBuilder.DropColumn(
                name: "GameId",
                table: "Question");

            migrationBuilder.DropColumn(
                name: "Text",
                table: "Question");

            migrationBuilder.DropColumn(
                name: "ViewCount",
                table: "Question");

            migrationBuilder.RenameTable(
                name: "Question",
                newName: "Questions");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Questions",
                table: "Questions",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Data = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PostComments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CommentId = table.Column<int>(type: "int", nullable: false),
                    PostId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostComments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PostImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageId = table.Column<int>(type: "int", nullable: false),
                    PostId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostImages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PostTexts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PostId = table.Column<int>(type: "int", nullable: false),
                    TextId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostTexts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "QuestionComments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CommentId = table.Column<int>(type: "int", nullable: false),
                    QuestionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionComments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "QuestionImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageId = table.Column<int>(type: "int", nullable: false),
                    QuestionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionImages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "QuestionTexts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestionId = table.Column<int>(type: "int", nullable: false),
                    TextBoxId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionTexts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Texts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Texts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GameTag",
                columns: table => new
                {
                    GamesId = table.Column<int>(type: "int", nullable: false),
                    TagsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameTag", x => new { x.GamesId, x.TagsId });
                    table.ForeignKey(
                        name: "FK_GameTag_Games_GamesId",
                        column: x => x.GamesId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GameTag_Tags_TagsId",
                        column: x => x.TagsId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GameTag_TagsId",
                table: "GameTag",
                column: "TagsId");
        }
    }
}
