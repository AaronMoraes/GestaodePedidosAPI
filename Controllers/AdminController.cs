using GestaodePedidosAPI.DTOs;
using GestaodePedidosAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace GestaodePedidosAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AdminController : ControllerBase
{
    private readonly AdminService _adminService;
    private readonly JwtService _jwtService;

    public AdminController(AdminService adminService, JwtService jwtService)
    {
        _adminService = adminService;
        _jwtService = jwtService;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginAdminDto dto)
    {
        var admin = await _adminService.BuscarPorUsuario(dto.Usuario);

        if (admin == null)
            return Unauthorized(new {message = "Usuário ou senha inválidos." });

        var senhaValida = _adminService.VerificarSenha(admin, dto.Senha);
        
        if(!senhaValida)
           return Unauthorized(new {message = "Usuário ou senha inválidos." });


        var token = _jwtService.GerarToken(admin);

        return Ok(new
        {
         message = "Login realizado com sucesso.",
         token = token 
        });
    }
}