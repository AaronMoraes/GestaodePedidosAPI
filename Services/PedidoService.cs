using GestaodePedidosAPI.Data;
using GestaodePedidosAPI.Models;
using GestaodePedidosAPI.DTOs;
using Microsoft.EntityFrameworkCore;

namespace GestaodePedidosAPI.Services;

public class PedidoService
{
    private readonly AppDbContext _context;

    public PedidoService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Pedido>> ListarTodos()
    {
        return await _context.Pedidos
        .Include(p => p.Itens)
        .ThenInclude(i => i.Produto)
        .ToListAsync();
    }

    public async Task<Pedido?> BuscarPorId(int id)
    {
        return await _context.Pedidos
        .Include(p => p.Itens)
        .ThenInclude(i => i.Produto)
        .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<Pedido> Criar(CriarPedidoDto dto)
    {
        var pedido = new Pedido
        {
            Data = DateTime.Now,
            Status = dto.Status
        };

        foreach (var itemDto in dto.Itens)
        {
            var item = new ItemPedido
            {
                ProdutoId = itemDto.ProdutoId,
                Quantidade = itemDto.Quantidade,
                Preco = itemDto.Preco
            };

            pedido.Itens.Add(item);
        }

        _context.Pedidos.Add(pedido);
        await _context.SaveChangesAsync();

        return pedido;
    }


}