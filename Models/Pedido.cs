namespace GestaodePedidosAPI.Models;

public class Pedido
{
    public int Id { get; set; }
    public DateTime Data { get; set; }
    public string Status { get; set; }
    public ICollection<ItemPedido> Itens { get; set; } = new List<ItemPedido>();
}