using GestaodePedidosAPI.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace GestaodePedidosAPI.Services;

public class JwtService
{
    private readonly string _jwtKey;

    public JwtService()
    {
        _jwtKey = Environment.GetEnvironmentVariable("JWT_KEY")
            ?? throw new InvalidOperationException("JWT_KEY não configurada");
    }

    public string GerarToken(Admin admin)
    {
        var clamis = new[]
        {
            new Claim(ClaimTypes.Name, admin.Usuario),
            new Claim(ClaimTypes.NameIdentifier, admin.Id.ToString())
        };

        var chave = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(_jwtKey)
        );

        var credenciais = new SigningCredentials(
            chave,
            SecurityAlgorithms.HmacSha256
        );


        var token = new JwtSecurityToken(
            claims: clamis,
            expires: DateTime.UtcNow.AddHours(2),
            signingCredentials: credenciais
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}