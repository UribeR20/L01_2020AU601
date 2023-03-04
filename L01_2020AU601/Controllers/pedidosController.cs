using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using L01_2020AU601.Models;

namespace L01_2020AU601.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class pedidosController : Controller
    {
       private readonly restauranteContext _restauranteContexto;
        public pedidosController(restauranteContext restauranteContexto) 
        {
            _restauranteContexto= restauranteContexto;


        }

        [HttpGet]
        [Route("GetAll")]

        public IActionResult Get()
        {
            List<pedidos> listadoPedidos=(from e in _restauranteContexto.pedidos select e).ToList();

            if (listadoPedidos.Count() == 0)
            {
                return NotFound();
            }
            return Ok(listadoPedidos);
        }

        [HttpPost]
        [Route ("Agregar")]
        public IActionResult Post([FromBody] pedidos pedido1) 
        {
            _restauranteContexto.pedidos.Add(pedido1);
            _restauranteContexto.SaveChanges();
            return Ok(pedido1);
                
        }

        [HttpPut]
        [Route("Actualizar/{id}")]
        public IActionResult actualizar(int id, [FromBody] pedidos pedido)
        {
            pedidos? pedidoactu = (from m in _restauranteContexto.pedidos where m.pedidoId== id select m).FirstOrDefault();

            if (pedidoactu == null)
            {
                return NotFound();
            }

            pedidoactu.motoristaId = pedido.motoristaId;
            pedidoactu.clienteId = pedido.clienteId;
            pedidoactu.platoId = pedido.platoId;
            pedidoactu.cantidad = pedido.cantidad;
            pedidoactu.precio = pedido.precio;

            _restauranteContexto.Entry(pedidoactu).State = EntityState.Modified;
            _restauranteContexto.SaveChanges();
            return Ok(pedido);
        }


        [HttpDelete]
        [Route("Eliminar/{id}")]

        public IActionResult eliminarPedido(int id)
        {
            pedidos? pedidoDelete= (from m in _restauranteContexto.pedidos where m.pedidoId == id select m).FirstOrDefault();

            if (pedidoDelete==null) 
                return NotFound();
            {
                _restauranteContexto.pedidos.Attach(pedidoDelete);
                _restauranteContexto.pedidos.Remove(pedidoDelete);
                _restauranteContexto.SaveChanges();

                return Ok(pedidoDelete);

            }
        }

        [HttpGet]
        [Route("GetDatos/{idCliente}/{idMotorista}")]

        public IActionResult GetDatos(int idCliente,int idMotorista) 
        {
           List<pedidos> datos = (from e in _restauranteContexto.pedidos where e.motoristaId  == idMotorista && e.clienteId== idCliente select e).ToList();
            if (datos==null) return NotFound();
            return Ok(datos);
        }



    }
}
