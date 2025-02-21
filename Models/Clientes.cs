using System.ComponentModel.DataAnnotations;

namespace L01_2022CI650_2022VS601.Models
{
    public class Clientes
    {
        [Key]
        public int clienteId { get; set; }
        public string nombreCliente { get; set; }
        public string direccion { get; set; }
    }
}
