using GestaodePedidosAPI.Models;
using GestaodePedidosAPI.Services;
using GestaodePedidosAPI.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace GestaodePedidosAPI.Controllers;

[ApiController]
[Route ("api/[controller]")]

public class PedidosController : ControllerBase
{
    private readonly PedidoService _service;

    public PedidosController(PedidoService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<List<Pedido>>> ListarTodos()
    {
        var pedidos = await _service.ListarTodos();

        return Ok(pedidos);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Pedido>> BuscarPorId (int id)
    {
        var pedido = await _service.BuscarPorId(id);

        if (pedido == null)
            return NotFound();

        return Ok(pedido);
    }

    [HttpPost]
    public async Task<ActionResult<Pedido>> Criar(CriarPedidoDto dto)
    {
        var pedido = await _service.Criar(dto);

        return CreatedAtAction(
            nameof(BuscarPorId),
            new {id =  pedido.Id},
            pedido
        );
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Excluir(int id)
    {
        var excluido = await _service.Excluir(id);

        if(!excluido)
            return NotFound();

        return NoContent();
    }
}

