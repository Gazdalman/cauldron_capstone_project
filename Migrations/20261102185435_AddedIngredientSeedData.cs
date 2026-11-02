using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Cauldron.Migrations
{
    /// <inheritdoc />
    public partial class AddedIngredientSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { 1, "All-Purpose Flour", "allpurposeflour" },
                    { 2, "Granulated Sugar", "granulatedsugar" },
                    { 3, "Kosher Salt", "koshersalt" },
                    { 4, "Black Pepper", "blackpepper" },
                    { 5, "Olive Oil", "oliveoil" },
                    { 6, "Baking Powder", "bakingpowder" },
                    { 7, "Vanilla Extract", "vanillaextract" },
                    { 8, "Chocolate Chips", "chocolatechips" },
                    { 9, "Maple Syrup", "maplesyrup" },
                    { 10, "Balsamic Vinegar", "balsamicvinegar" },
                    { 11, "Large Eggs", "largeeggs" },
                    { 12, "Whole Milk", "wholemilk" },
                    { 13, "Unsalted Butter", "unsaltedbutter" },
                    { 14, "Cheddar Cheese", "cheddarcheese" },
                    { 15, "Parmesan Cheese", "parmesancheese" },
                    { 16, "Heavy Cream", "heavycream" },
                    { 17, "Bacon", "bacon" },
                    { 18, "Pork Sausage", "porksausage" },
                    { 19, "Deli Turkey", "deliturkey" },
                    { 20, "Chicken Breast", "chickenbreast" },
                    { 21, "Boneless Chicken Thighs", "bonelesschickenthighs" },
                    { 22, "Bone-In Chicken Thighs", "boneinchickenthighs" },
                    { 23, "Russet Potatoes", "russetpotatoes" },
                    { 24, "Garlic", "garlic" },
                    { 25, "Yellow Onion", "yellowonion" },
                    { 26, "Romaine Lettuce", "romainelettuce" },
                    { 27, "Tomatoes", "tomatoes" },
                    { 28, "Asparagus", "asparagus" },
                    { 29, "Lemons", "lemons" },
                    { 30, "Sourdough Bread", "sourdoughbread" },
                    { 31, "Croutons", "croutons" },
                    { 32, "Coffee Beans", "coffeebeans" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 32);
        }
    }
}
