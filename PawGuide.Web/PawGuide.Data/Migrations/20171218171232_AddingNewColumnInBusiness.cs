namespace PawGuide.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class AddingNewColumnInBusiness : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Businesses",
                maxLength: 90,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "Businesses");
        }
    }
}
