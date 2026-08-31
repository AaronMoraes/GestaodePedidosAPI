using GestaodePedidosAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace GestaodePedidosAPI.Controllers;

[ApiController]
[Route("api/[controller]")]

public class ProdutosController : ControllerBase;
{
    private readonly ProdutoService _produtoService;

    public ProdutosController(ProdutoService produtoService)
    {
        _produtoService = produtoService;
    }

    [HttpGet]
    public IActionResult GetProdutos()
    {
        var produtos = _produtoService.GetProdutos();

        return Ok(produtos);
    }
}