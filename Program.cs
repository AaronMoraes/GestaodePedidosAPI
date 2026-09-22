using GestaodePedidosAPI.Services;
using Microsoft.EntityFrameworkCore;
using GestaodePedidosAPI.Data;
using GestaodePedidosAPI.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.UseUrls("http://0.0.0.0:5000");

builder.Services.AddControllers();

builder.Services.AddCors(options =>
{
    options.AddPolicy("Frontend", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

builder.Services.AddDbContext<AppDbContext> (options =>
    options.UseSqlite("Data Source=gestaodepedidos.db"));

builder.Services.AddScoped<ProdutoService>();
builder.Services.AddScoped<PedidoService>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.Migrate();
}

app.UseMiddleware<ExceptionMiddleware>();

app.UseCors("Frontend");

app.MapControllers();

app.MapGet("/", () => "Gestão de Pedidos API funcionando!");

app.Run();