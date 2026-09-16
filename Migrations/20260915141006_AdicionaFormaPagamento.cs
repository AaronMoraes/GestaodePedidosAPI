using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestaodePedidosAPI.Migrations
{
    /// <inheritdoc />
    public partial class AdicionaFormaPagamento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FormaPagamento",
                table: "Pedidos",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FormaPagamento",
                table: "Pedidos");
        }
    }
}
