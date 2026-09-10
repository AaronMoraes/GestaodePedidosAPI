using System.ComponentModel.DataAnnotations;

namespace GestaodePedidosAPI.DTOs;

public class ProdutoDto
{
    [Required]
    public string Nome { get; set; } = string.Empty;

    [Range(0.01, double.MaxValue)]
    public decimal Preco { get; set; }
}