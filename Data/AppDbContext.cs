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
}