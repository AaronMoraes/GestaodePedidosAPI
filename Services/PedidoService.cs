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
        if (dto.Itens == null || dto.Itens.Count == 0)
            throw new ArgumentException ("O pedido deve possuir pelo menos um item. ");
        
        if(dto.FormaPagamento != "pix" && dto.FormaPagamento != "cartao")
            throw new ArgumentException("Forma de Pagamento inválida. ");

        if(dto.Status != "Pendente")
            throw new ArgumentException("Status do pedido inválido. ");
            
        var pedido = new Pedido
        {
            Data = DateTime.Now,
            Status = dto.Status,
            FormaPagamento = dto.FormaPagamento
        };

        foreach (var itemDto in dto.Itens)
        {
            var produto = await  _context.Produtos
                .FirstOrDefaultAsync(p => p.Id == itemDto.ProdutoId);

            if (produto == null)
                throw new ArgumentException($"Produto com ID {itemDto.ProdutoId} nao existe. ");
            
            if (itemDto.Quantidade <= 0)
                throw new ArgumentException("A quantidade deve ser maior que zero. ");

            var item = new ItemPedido
            {
                ProdutoId = itemDto.ProdutoId,
                Quantidade = itemDto.Quantidade,
                Preco = produto.Preco  
            };

            pedido.Itens.Add(item);
        }

        _context.Pedidos.Add(pedido);
        await _context.SaveChangesAsync();

        return pedido;
    }

    public async Task<bool> Excluir(int id)
    {
        var pedido = await _context.Pedidos
            .Include(p => p.Itens)
            .FirstOrDefaultAsync(p => p.Id == id);

        if (pedido == null)
            return false;

        _context.Pedidos.Remove(pedido);

        await _context.SaveChangesAsync();

        return true;
    }


}