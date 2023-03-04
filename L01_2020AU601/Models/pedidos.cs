using System.ComponentModel.DataAnnotations;
namespace L01_2020AU601.Models
{
    public class pedidos
    {
        [Key]
        public int id { set; get; }
        public string pedidold { set; get; }
        public decimal motoristald { set; get; }
        public string platold { set; get; }
        public decimal cantidad { set; get; }
        public decimal precio { set; get; }
    }
}

