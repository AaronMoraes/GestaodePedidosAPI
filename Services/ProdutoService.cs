using GestaodePedidosAPI.Data;
using GestaodePedidosAPI.Models;
using Microsoft.EntityFrameworkCore;
using GestaodePedidosAPI.DTOs;

namespace GestaodePedidosAPI.Services;

public class ProdutoService
{
    private readonly AppDbContext _context;

    public ProdutoService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Produto>> GetProdutos()
    {
        return await _context.Produtos.ToListAsync();
    }

    public async Task<Produto?> GetProdutoPorId(int id)
    {
        return await _context.Produtos.FindAsync(id);
    }

    public async Task<Produto> CriarProduto(ProdutoDto produtoDto)
    {
        ValidarProduto(produtoDto);

        var produto = new Produto
        {
            Nome = produtoDto.Nome.Trim(),
            Preco = produtoDto.Preco
        };

        _context.Produtos.Add(produto);

        await _context.SaveChangesAsync();

        return produto;
    }

    public async Task<Produto?> AtualizarProduto(int id, ProdutoDto produtoDto)
    {
        var produto = await _context.Produtos.FindAsync(id);

        if (produto == null)
        {
            return null;
        }

        ValidarProduto(produtoDto);

        produto.Nome = produtoDto.Nome.Trim();
        produto.Preco = produtoDto.Preco;

        await _context.SaveChangesAsync();

        return produto;
    }

    public async Task<bool> ExcluirProduto(int id)
    {
        var produto = await _context.Produtos.FindAsync(id);

        if (produto == null)
        {
            return false;
        }

        _context.Produtos.Remove(produto);

        await _context.SaveChangesAsync();

        return true;
    }

    private static void ValidarProduto(ProdutoDto produtoDto)
    {
        if (string.IsNullOrWhiteSpace(produtoDto.Nome))
            throw new ArgumentException("O nome do produto é obrigatório.");

        if (produtoDto.Preco < 0)
            throw new ArgumentException("O preço do produto não pode ser negativo.");
    }
}