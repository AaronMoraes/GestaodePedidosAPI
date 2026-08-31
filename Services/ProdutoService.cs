using GestaodePedidosAPI.Models;

namespace GestaodePedidosAPI.Services;

public class ProdutoService
{
    public List<Produto> GetProdutos()
    {
        return new List<Produto>
        {
            new Produto
            {
                Id = 1,
                Nome = "Coca-Cola 350ml",
                Preco = 6.00m
            },
            new Produto
            {
                Id = 2,
                Nome = "Guaraná Antarctica 350ml",
                Preco = 5.00m
            },
            new Produto
            {
                Id = 3,
                Nome = "Suco de Laranja 500ml",
                Preco = 10.00m
            }
        };
    }
}