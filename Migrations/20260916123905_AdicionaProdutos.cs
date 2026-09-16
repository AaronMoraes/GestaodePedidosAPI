using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GestaodePedidosAPI.Migrations
{
    /// <inheritdoc />
    public partial class AdicionaProdutos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Produtos",
                columns: new[] { "Id", "Nome", "Preco" },
                values: new object[,]
                {
                    { 13, "Coca-Cola 350ml", 6.00m },
                    { 14, "Coca-Cola 1L", 10.00m },
                    { 15, "Coca-Cola 2L", 15.00m },
                    { 16, "Guaraná Antarctica 350mL", 5.00m },
                    { 17, "Sprite 350mL", 5.00m },
                    { 18, "Fanta Laranja 350ml", 5.00m },
                    { 19, "Fanta Uva 350ml", 5.00m },
                    { 20, "Suco de Laranja 500ml", 10.00m },
                    { 21, "Suco de Uva 500ml", 12.00m },
                    { 30, "Combo Família", 80.00m },
                    { 31, "Dogão no Prato", 35.00m },
                    { 32, "Combo Casal", 45.00m },
                    { 33, "Combo Kids", 35.00m },
                    { 34, "Combo Bacon", 55.00m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: 34);
        }
    }
}
