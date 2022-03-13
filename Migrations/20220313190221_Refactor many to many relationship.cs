using Microsoft.EntityFrameworkCore.Migrations;

namespace MyULibrary_API.Migrations
{
    public partial class Refactormanytomanyrelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LoanHistory_Book_BookID",
                table: "LoanHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_LoanHistory_User_UserId",
                table: "LoanHistory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LoanHistory",
                table: "LoanHistory");

            migrationBuilder.DropIndex(
                name: "IX_LoanHistory_BookID",
                table: "LoanHistory");

            migrationBuilder.RenameColumn(
                name: "BookID",
                table: "LoanHistory",
                newName: "BookId");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "LoanHistory",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BookId",
                table: "LoanHistory",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_LoanHistory",
                table: "LoanHistory",
                columns: new[] { "BookId", "UserId", "LoanDate" });

            migrationBuilder.AddForeignKey(
                name: "FK_LoanHistory_Book_BookId",
                table: "LoanHistory",
                column: "BookId",
                principalTable: "Book",
                principalColumn: "BookID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LoanHistory_User_UserId",
                table: "LoanHistory",
                column: "UserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LoanHistory_Book_BookId",
                table: "LoanHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_LoanHistory_User_UserId",
                table: "LoanHistory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LoanHistory",
                table: "LoanHistory");

            migrationBuilder.RenameColumn(
                name: "BookId",
                table: "LoanHistory",
                newName: "BookID");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "LoanHistory",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "BookID",
                table: "LoanHistory",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LoanHistory",
                table: "LoanHistory",
                column: "LoanDate");

            migrationBuilder.CreateIndex(
                name: "IX_LoanHistory_BookID",
                table: "LoanHistory",
                column: "BookID");

            migrationBuilder.AddForeignKey(
                name: "FK_LoanHistory_Book_BookID",
                table: "LoanHistory",
                column: "BookID",
                principalTable: "Book",
                principalColumn: "BookID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LoanHistory_User_UserId",
                table: "LoanHistory",
                column: "UserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
