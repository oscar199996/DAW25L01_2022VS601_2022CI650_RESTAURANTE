using System.ComponentModel.DataAnnotations;

namespace L01_2022CI650_2022VS601.Models
{
    public class Platos
    {
        [Key]
        public int platoId { get; set; }
        public string nombrePlato { get; set; } = string.Empty;
        public decimal precio { get; set; }
    }
}
