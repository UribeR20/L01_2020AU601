using System.ComponentModel.DataAnnotations;
namespace L01_2020AU601.Models
{
    public class platos
    {
        [Key]

        public int platoId { set; get; }
        public string nombrePlato { set; get; }
        public decimal precio { set; get; }
    }
}
