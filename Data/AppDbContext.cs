using GestaodePedidosAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace GestaodePedidosAPI.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    { 
    }

    public DbSet<Produto> Produtos => Set<Produto>();
    public DbSet<Pedido> Pedidos => Set<Pedido>();
    public DbSet<ItemPedido> ItensPedido => Set<ItemPedido>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ItemPedido>()
            .HasOne(item => item.Pedido)
            .WithMany(pedido => pedido.Itens)
            .HasForeignKey(item => item.PedidoId);

        modelBuilder.Entity<ItemPedido>()
            .HasOne(item => item.Produto)
            .WithMany()
            .HasForeignKey(item => item.ProdutoId);

        //HasData fala para o EF que quando o banco for criado através das migrations, esses dados tem que existir.
        modelBuilder.Entity<Produto>().HasData(
            new Produto {Id = 13, Nome = "Coca-Cola 350ml", Preco = 6.00m},
            new Produto { Id = 14, Nome = "Coca-Cola 1L", Preco = 10.00m },
            new Produto { Id = 15, Nome = "Coca-Cola 2L", Preco = 15.00m },
            new Produto { Id = 16, Nome = "Guaraná Antarctica 350mL", Preco = 5.00m },
            new Produto { Id = 17, Nome = "Sprite 350mL", Preco = 5.00m },
            new Produto { Id = 18, Nome = "Fanta Laranja 350ml", Preco = 5.00m },
            new Produto { Id = 19, Nome = "Fanta Uva 350ml", Preco = 5.00m },
            new Produto { Id = 20, Nome = "Suco de Laranja 500ml", Preco = 10.00m },
            new Produto { Id = 21, Nome = "Suco de Uva 500ml", Preco = 12.00m },

            new Produto { Id = 30, Nome = "Combo Família", Preco = 80.00m },
            new Produto { Id = 31, Nome = "Dogão no Prato", Preco = 35.00m },
            new Produto { Id = 32, Nome = "Combo Casal", Preco = 45.00m },
            new Produto { Id = 33, Nome = "Combo Kids", Preco = 35.00m },
            new Produto { Id = 34, Nome = "Combo Bacon", Preco = 55.00m }
        );
    }
}