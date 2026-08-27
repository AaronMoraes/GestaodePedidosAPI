var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.MapGet("/", () => "Gestão de Pedidos API funcionando! ");

app.Run();