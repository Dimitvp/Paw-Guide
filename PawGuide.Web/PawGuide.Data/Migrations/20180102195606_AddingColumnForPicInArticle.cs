namespace PawGuide.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;


    public partial class AddingColumnForPicInArticle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PicUrl",
                table: "Articles",
                maxLength: 2000,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PicUrl",
                table: "Articles");
        }
    }
}
