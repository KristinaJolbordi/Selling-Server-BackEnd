using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinalProjectWebAPI.Migrations
{
    public partial class UpdateProductAgeRecommendation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AgeRecommendation",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AgeRecommendation",
                table: "Products");
        }
    }
}
