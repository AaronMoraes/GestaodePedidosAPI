using GestaodePedidosAPI.Models;
using Microsoft.AspNetCore.Mvc;
using GestaodePedidosAPI.Services;
using GestaodePedidosAPI.DTOs;

namespace GestaodePedidosAPI.Controllers;

[ApiController]
[Route("api/[controller]")]

public class ProdutosController : ControllerBase
{
    private readonly ProdutoService _produtoService;

    public ProdutosController(ProdutoService produtoService)
    {
        _produtoService = produtoService;
    }

    [HttpGet]
    public async Task<IActionResult> GetProdutos()
    {
        var produtos = await _produtoService.GetProdutos();

        return Ok(produtos);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetProdutoPorId(int id)
    {
        var produto = await _produtoService.GetProdutoPorId(id);

        if (produto == null)
        {
            return NotFound();
        }

        return Ok(produto); 
    }
    
    [HttpPost]
    public async Task<IActionResult> CriarProduto (ProdutoDto produtoDto)
    {
        var produto = await _produtoService.CriarProduto(produtoDto);

        return CreatedAtAction(
            nameof(GetProdutoPorId),
            new {id = produto.Id},
            produto
        );
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> AtualizarProduto(int id, ProdutoDto produtoDto)
    {
        var produto = await _produtoService.AtualizarProduto(id, produtoDto);

        if (produto == null)
        {
            return NotFound();
        }

        return Ok(produto);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> ExcluirProduto (int id)
    {
        var excluido = await _produtoService.ExcluirProduto(id);

        if (!excluido)
        {
            return NotFound();
        }

        return NoContent();
    }
}