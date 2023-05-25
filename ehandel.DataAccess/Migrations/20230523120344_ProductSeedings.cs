using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ehandel.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ProductSeedings : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProductStatusMappings",
                keyColumns: new[] { "ProductId", "ProductStatusId" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.UpdateData(
                table: "ContactUs",
                keyColumn: "Id",
                keyValue: 1,
                column: "TimeOfContact",
                value: new DateTime(2023, 5, 23, 14, 3, 44, 171, DateTimeKind.Local).AddTicks(4827));

            migrationBuilder.InsertData(
                table: "ContactUs",
                columns: new[] { "Id", "Comment", "Company", "Email", "Name", "Phone", "TimeOfContact" },
                values: new object[,]
                {
                    { 2, "Lorem ipsum dolor sit amet.", "XYZ Corporation", "janesmith@example.com", "Jane Smith", "987-654-3210", new DateTime(2023, 5, 23, 14, 3, 44, 171, DateTimeKind.Local).AddTicks(4831) },
                    { 3, "Testing randomization.", "ABC Industries", "michaeljohnson@example.com", "Michael Johnson", "555-123-4567", new DateTime(2023, 5, 23, 14, 3, 44, 171, DateTimeKind.Local).AddTicks(4834) },
                    { 4, "Hello world!", "Global Enterprises", "emilydavis@example.com", "Emily Davis", "111-222-3333", new DateTime(2023, 5, 23, 14, 3, 44, 171, DateTimeKind.Local).AddTicks(4837) },
                    { 5, "Random comment here.", "Smith & Co.", "davidbrown@example.com", "David Brown", "444-555-6666", new DateTime(2023, 5, 23, 14, 3, 44, 171, DateTimeKind.Local).AddTicks(4841) }
                });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CategoryId", "CreatedDateTime", "Description", "ImageUrl", "Name", "Price", "ProductRatingId", "SKU" },
                values: new object[] { 9, "2023-05-23 14:03", "The Apple Watch Series is a cutting-edge wearable device that seamlessly integrates with your iPhone, providing a range of innovative features and functionalities. With its sleek design and advanced technology, it allows you to stay connected, track your fitness, monitor your health, access apps, and receive notifications, all from your wrist.", "\\img\\placeholders\\270x295.svg", "The Apple Watch Series", 30m, 4, "04acc686-02ca-4e4a-adc1-cb6bb3f297c1" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "CreatedDateTime", "Description", "ImageUrl", "Name", "Price", "ProductRatingId", "SKU" },
                values: new object[,]
                {
                    { 2, 1, "2023-05-23 14:03", "The Table Lamp is a versatile lighting fixture that adds both functionality and style to any space. With its sleek design and adjustable brightness, it provides the perfect ambiance for reading, working, or creating a cozy atmosphere. Its compact size and sturdy base make it an ideal choice for bedside tables, desks, or any tabletop surface.", "\\img\\placeholders\\270x295.svg", "Table lamp", 30m, 3, "04acc686-02ca-4e4a-adc1-cb6bb3f297c2" },
                    { 3, 8, "2023-05-23 14:03", "The ThinkPad Lenovo laptop is a powerful computing device known for its reliability and performance. Designed for professionals and business users, it offers a robust build, exceptional keyboard, and advanced security features. With its high-quality display, fast processing power, and extensive connectivity options, it empowers users to accomplish tasks efficiently and enhance productivity.", "\\img\\placeholders\\270x295.svg", "Laptop thinkpad lenovo", 30m, 5, "04acc686-02ca-4e4a-adc1-cb6bb3f297c3" },
                    { 4, 8, "2023-05-23 14:03", "Black fashion gumshoes are a trendy footwear choice that combines style and comfort. These sleek and versatile shoes feature a classic black color, making them easy to match with various outfits. With their cushioned soles and breathable materials, they provide all-day comfort for walking or casual wear. Perfect for fashion-forward individuals seeking a blend of elegance and functionality.", "\\img\\placeholders\\270x295.svg", "Gumshoes black fashion", 80m, 5, "04acc686-02ca-4e4a-adc1-cb6bb3f297c4" },
                    { 5, 4, "2023-05-23 14:03", "The woman's white dress is an elegant and timeless piece that exudes grace and sophistication. Its pristine white color symbolizes purity and femininity, while the flowing fabric drapes beautifully to enhance the wearer's silhouette. Whether worn for a special occasion or a casual outing, this dress radiates effortless style and captures the essence of femininity.", "\\img\\placeholders\\270x295.svg", "Woman white dress", 30m, 5, "04acc686-02ca-4e4a-adc1-cb6bb3f297c5" },
                    { 6, 6, "2023-05-23 14:03", "The kettle water boiler is a convenient and efficient appliance designed to quickly heat water for various purposes. With its sleek and compact design, it effortlessly fits into any kitchen space. Boasting rapid boiling capabilities, it provides hot water in a matter of minutes, making it ideal for brewing tea, coffee, or preparing instant meals. Its easy-to-use features and safety mechanisms ensure a hassle-free and enjoyable boiling experience.", "\\img\\placeholders\\270x295.svg", "Kettle water boiler", 30m, 1, "04acc686-02ca-4e4a-adc1-cb6bb3f297c6" },
                    { 7, 6, "2023-05-23 14:03", "The congee cooking rice cooker is a versatile kitchen appliance that simplifies the process of making congee, a traditional rice porridge dish. With its advanced features and settings, it ensures perfectly cooked and creamy congee every time. Whether you prefer a smooth or chunky texture, this cooker delivers consistent results, making it a convenient choice for congee lovers.", "\\img\\placeholders\\270x295.svg", "Congee cooking rice cooker", 30m, 1, "04acc686-02ca-4e4a-adc1-cb6bb3f297c7" },
                    { 8, 6, "2023-05-23 14:03", "Pizza tomato sauce kebab is a delicious fusion dish that combines the flavors of traditional pizza with the savory taste of kebab. It features a thin crust layered with tangy tomato sauce and topped with tender kebab meat, vegetables, and melted cheese. The combination of these ingredients creates a mouthwatering and satisfying culinary experience that is sure to please pizza and kebab enthusiasts alike.", "\\img\\placeholders\\270x295.svg", "Pizza tomato sauce kebab", 30m, 1, "04acc686-02ca-4e4a-adc1-cb6bb3f297c8" }
                });

            migrationBuilder.InsertData(
                table: "ProductStatusMappings",
                columns: new[] { "ProductId", "ProductStatusId" },
                values: new object[,]
                {
                    { 2, 1 },
                    { 2, 2 },
                    { 3, 1 },
                    { 3, 2 },
                    { 4, 1 },
                    { 4, 2 },
                    { 5, 1 },
                    { 5, 2 },
                    { 6, 1 },
                    { 6, 2 },
                    { 7, 1 },
                    { 7, 2 },
                    { 7, 3 },
                    { 8, 1 },
                    { 8, 2 },
                    { 8, 3 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ContactUs",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ContactUs",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ContactUs",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ContactUs",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ProductStatusMappings",
                keyColumns: new[] { "ProductId", "ProductStatusId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "ProductStatusMappings",
                keyColumns: new[] { "ProductId", "ProductStatusId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "ProductStatusMappings",
                keyColumns: new[] { "ProductId", "ProductStatusId" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "ProductStatusMappings",
                keyColumns: new[] { "ProductId", "ProductStatusId" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                table: "ProductStatusMappings",
                keyColumns: new[] { "ProductId", "ProductStatusId" },
                keyValues: new object[] { 4, 1 });

            migrationBuilder.DeleteData(
                table: "ProductStatusMappings",
                keyColumns: new[] { "ProductId", "ProductStatusId" },
                keyValues: new object[] { 4, 2 });

            migrationBuilder.DeleteData(
                table: "ProductStatusMappings",
                keyColumns: new[] { "ProductId", "ProductStatusId" },
                keyValues: new object[] { 5, 1 });

            migrationBuilder.DeleteData(
                table: "ProductStatusMappings",
                keyColumns: new[] { "ProductId", "ProductStatusId" },
                keyValues: new object[] { 5, 2 });

            migrationBuilder.DeleteData(
                table: "ProductStatusMappings",
                keyColumns: new[] { "ProductId", "ProductStatusId" },
                keyValues: new object[] { 6, 1 });

            migrationBuilder.DeleteData(
                table: "ProductStatusMappings",
                keyColumns: new[] { "ProductId", "ProductStatusId" },
                keyValues: new object[] { 6, 2 });

            migrationBuilder.DeleteData(
                table: "ProductStatusMappings",
                keyColumns: new[] { "ProductId", "ProductStatusId" },
                keyValues: new object[] { 7, 1 });

            migrationBuilder.DeleteData(
                table: "ProductStatusMappings",
                keyColumns: new[] { "ProductId", "ProductStatusId" },
                keyValues: new object[] { 7, 2 });

            migrationBuilder.DeleteData(
                table: "ProductStatusMappings",
                keyColumns: new[] { "ProductId", "ProductStatusId" },
                keyValues: new object[] { 7, 3 });

            migrationBuilder.DeleteData(
                table: "ProductStatusMappings",
                keyColumns: new[] { "ProductId", "ProductStatusId" },
                keyValues: new object[] { 8, 1 });

            migrationBuilder.DeleteData(
                table: "ProductStatusMappings",
                keyColumns: new[] { "ProductId", "ProductStatusId" },
                keyValues: new object[] { 8, 2 });

            migrationBuilder.DeleteData(
                table: "ProductStatusMappings",
                keyColumns: new[] { "ProductId", "ProductStatusId" },
                keyValues: new object[] { 8, 3 });

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.UpdateData(
                table: "ContactUs",
                keyColumn: "Id",
                keyValue: 1,
                column: "TimeOfContact",
                value: new DateTime(2023, 5, 17, 13, 46, 53, 588, DateTimeKind.Local).AddTicks(9826));

            migrationBuilder.InsertData(
                table: "ProductStatusMappings",
                columns: new[] { "ProductId", "ProductStatusId" },
                values: new object[] { 1, 3 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CategoryId", "CreatedDateTime", "Description", "ImageUrl", "Name", "Price", "ProductRatingId", "SKU" },
                values: new object[] { 1, "2023-05-17 13:46", "Placeholder description", "\\img\\products\\placeholder.svg", "Placeholder product", 99.99m, 1, "04acc686-02ca-4e4a-adc1-cb6bb3f297c4" });
        }
    }
}
