using GestaodePedidosAPI.Models;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.MapGet("/api/produtos", () => 
{
    var produtos = new List<Produto>
    {
        new Produto
        {
            Id = 1,
            Nome = "Coca-Cola 350ml",
            Preco = 6.00m
        },
        new Produto
        {
            Id = 2,
            Nome = "Guarana Antartica 350ml",
            Preco = 5.00m
        },
        new Produto
        {
            Id = 3,
            Nome = "Suco de Laranja 500ml",
            Preco = 10.00m
        }
    };

    return produtos;

});

app.MapGet("/", () => "Gestão de Pedidos API funcionando!");

app.Run();
