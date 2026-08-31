using GestaodePedidosAPI.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddScoped<ProdutoService>();

var app = builder.Build();

app.MapControllers();

app.MapGet("/", () => "Gestão de Pedidos API funcionando!");

app.Run();