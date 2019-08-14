using Microsoft.EntityFrameworkCore.Migrations;

namespace LoginApp.Migrations
{
    public partial class updateFullNameAgain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Fullname",
                table: "AspNetUsers",
                newName: "FullName");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
