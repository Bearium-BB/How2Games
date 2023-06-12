using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace How2Games.DataAccess.Migrations.Games
{
    /// <inheritdoc />
    public partial class useridfixed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Answers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "8d099c51-2345-4ac9-94d1-5ffd060baea5");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "9272836c-fe5e-4344-b6f8-4e6274e65abc");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "f3fca3b6-a8cb-46a3-840f-bd0e17c57c11");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b7ac3d84-d8a8-4628-a254-be921b4b5630",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e308c27d-f460-4155-a314-9356f9cf3e3e", "AQAAAAEAACcQAAAAEDqMTcmdOVrQQ2BW+//SCDd/rdGKmT3MfN6W4KLwzvjtjBD8kxSEMwGF+iUt5x+cow==", "c9f9f05e-9d7f-43c8-a744-a319c3088b4f" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Answers",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

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
        }
    }
}
