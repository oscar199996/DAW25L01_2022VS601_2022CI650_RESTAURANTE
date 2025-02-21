namespace L01_2022CI650_2022VS601.Models
{
    public class Pedidos
    {
        public int pedidoId { get; set; }
        public int motoristaId { get; set; }
        public int clienteId { get; set; }
        public int platoId { get; set; }
        public int cantidad { get; set; }
        public decimal precio { get; set; }
    }
}
