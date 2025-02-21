using System.ComponentModel.DataAnnotations;

namespace L01_2022CI650_2022VS601.Models
{
    public class Motoristas
    {
        [Key]
        public int motoristaId { get; set; }
        public string nombreMotorista { get; set; }
    }
}
