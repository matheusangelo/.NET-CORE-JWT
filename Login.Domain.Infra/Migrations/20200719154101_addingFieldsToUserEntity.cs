using Microsoft.EntityFrameworkCore.Migrations;

namespace Login.Domain.Infra.Migrations
{
    public partial class addingFieldsToUserEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "users",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "users");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "users");
        }
    }
}
