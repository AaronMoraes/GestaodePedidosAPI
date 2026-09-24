using GestaodePedidosAPI.Services;
using Microsoft.EntityFrameworkCore;
using GestaodePedidosAPI.Data;
using GestaodePedidosAPI.Middleware;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

var jwtKey = Environment.GetEnvironmentVariable("JWT_KEY");

if (string.IsNullOrWhiteSpace(jwtKey))
    throw new InvalidOperationException("JWT_KEY não configurada.");

builder.WebHost.UseUrls("http://0.0.0.0:5000");

builder.Services.AddControllers();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(jwtKey)
            ),
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true,
            ClockSkew = TimeSpan.Zero
        };
    });

builder.Services.AddCors(options =>
{
    options.AddPolicy("Frontend", policy =>
    {
        policy
            .SetIsOriginAllowed(origin => true)
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=gestaodepedidos.db"));

builder.Services.AddScoped<ProdutoService>();
builder.Services.AddScoped<PedidoService>();
builder.Services.AddScoped<AdminService>();
builder.Services.AddScoped<JwtService>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.Migrate();

    var adminService = scope.ServiceProvider.GetRequiredService<AdminService>();

    var usuario = Environment.GetEnvironmentVariable("ADMIN_USUARIO");
    var senha = Environment.GetEnvironmentVariable("ADMIN_SENHA");

    if (!string.IsNullOrWhiteSpace(usuario) &&
       !string.IsNullOrWhiteSpace(senha))
    {
        await adminService.CriarAdminInicial(usuario, senha);
    }
}

app.UseMiddleware<ExceptionMiddleware>();

app.UseCors("Frontend");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.MapGet("/", () => "Gestão de Pedidos API funcionando!");

app.Run();