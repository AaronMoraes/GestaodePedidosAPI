using GestaodePedidosAPI.Services;
using Microsoft.EntityFrameworkCore;
using GestaodePedidosAPI.Data;
using GestaodePedidosAPI.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDbContext<AppDbContext> (options =>
    options.UseSqlite("Data Source=gestaodepedidos.db"));

builder.Services.AddScoped<ProdutoService>();
builder.Services.AddScoped<PedidoService>();

var app = builder.Build();

app.UseMiddleware<ExceptionMiddleware>();

app.MapControllers();

app.MapGet("/", () => "Gestão de Pedidos API funcionando!");

app.Run();