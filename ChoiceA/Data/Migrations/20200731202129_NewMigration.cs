using Microsoft.EntityFrameworkCore.Migrations;

namespace ChoiceA.Data.Migrations
{
    public partial class NewMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AspNetUserId",
                table: "Students",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Students_AspNetUserId",
                table: "Students",
                column: "AspNetUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_AspNetUsers_AspNetUserId",
                table: "Students",
                column: "AspNetUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_AspNetUsers_AspNetUserId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_AspNetUserId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "AspNetUserId",
                table: "Students");
        }
    }
}
