namespace PawGuide.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class AddingColumnForPicFileInBusiness : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Businesses",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Businesses");
        }
    }
}
