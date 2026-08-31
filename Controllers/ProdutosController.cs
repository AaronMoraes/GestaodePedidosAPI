using GestaodePedidosAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace GestaodePedidosAPI.Controllers;

[ApiController]
[Route("api/[controller]")]

public class ProdutosController: ControllerBase
{
    [HttpGet]
    public IActionResult GetProdutos()
    {
        var produtos = new List<Produto>
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
                Nome = "Guarana Antartica 350ml",
                Preco = 5.00m
            },
            new Produto
            {
                Id = 3,
                Nome = "Suco de Laranja",
                Preco = 10.00m
            }
        };

        return Ok(produtos);
    }
}