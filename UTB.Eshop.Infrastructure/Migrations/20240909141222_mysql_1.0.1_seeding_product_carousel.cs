using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace UTB.Eshop.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class mysql_101_seeding_product_carousel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Carousel",
                columns: new[] { "Id", "ImageAlt", "ImageSrc" },
                values: new object[,]
                {
                    { 1, "First slide", "/img/carousel/information-technology-specialist.jpg" },
                    { 2, "Second slide", "/img/carousel/Information-Technology-1-1.jpg" },
                    { 3, "Third slide", "/img/carousel/itec-index-banner.jpg" }
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "Description", "ImageSrc", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "nejlepší rohlík na světě", "/img/products/produkty-01.jpg", "Rohlík", 2.0 },
                    { 2, "nejlepší chleba v galaxii", "/img/products/produkty-02.jpg", "Chleba", 50.0 },
                    { 3, "nejlepší bageta ve vesmíru", "/img/products/produkty-05.jpg", "Bageta", 40.0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Carousel",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Carousel",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Carousel",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
