using System.ComponentModel.DataAnnotations;

namespace L01_2020AU601.Models
{
    public class motoristas
    {
        [Key]

        public int motoristaId { set; get; }
        public string nombreMotorista { set; get; }

    }
}
