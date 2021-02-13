using Microsoft.EntityFrameworkCore.Migrations;

namespace PhoneBookApp.Data.Migrations
{
    public partial class AddedPhoneBookIdColunm : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Entry_PhoneBook_PhoneBookId1",
                table: "Entry");

            migrationBuilder.DropIndex(
                name: "IX_Entry_PhoneBookId1",
                table: "Entry");

            migrationBuilder.DropColumn(
                name: "PhoneBookId1",
                table: "Entry");

            migrationBuilder.AddColumn<int>(
                name: "PhoneBookId",
                table: "Entry",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Entry_PhoneBookId",
                table: "Entry",
                column: "PhoneBookId");

            migrationBuilder.AddForeignKey(
                name: "FK_Entry_PhoneBook_PhoneBookId",
                table: "Entry",
                column: "PhoneBookId",
                principalTable: "PhoneBook",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Entry_PhoneBook_PhoneBookId",
                table: "Entry");

            migrationBuilder.DropIndex(
                name: "IX_Entry_PhoneBookId",
                table: "Entry");

            migrationBuilder.DropColumn(
                name: "PhoneBookId",
                table: "Entry");

            migrationBuilder.AddColumn<int>(
                name: "PhoneBookId1",
                table: "Entry",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Entry_PhoneBookId1",
                table: "Entry",
                column: "PhoneBookId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Entry_PhoneBook_PhoneBookId1",
                table: "Entry",
                column: "PhoneBookId1",
                principalTable: "PhoneBook",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
