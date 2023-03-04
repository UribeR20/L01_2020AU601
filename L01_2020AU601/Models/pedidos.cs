using System.ComponentModel.DataAnnotations;
namespace L01_2020AU601.Models
{
    public class pedidos
    {
        [Key]
       
        public int pedidoId { set; get; }
        public int motoristaId { set; get; }
        public int clienteId { set; get; }
        public int platoId { set; get; }
        public int cantidad { set; get; }
        public decimal precio { set; get; }
    }
}

