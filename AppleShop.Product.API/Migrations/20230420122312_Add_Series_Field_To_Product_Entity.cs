using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppleShop.Product.API.Migrations
{
    /// <inheritdoc />
    public partial class AddSeriesFieldToProductEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Series",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Series",
                table: "Products");
        }
    }
}
