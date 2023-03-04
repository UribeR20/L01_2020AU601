using L01_2020AU601.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace L01_2020AU601.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class platosController : ControllerBase
    {
        private readonly restauranteContext _restauranteContexto;
        public platosController(restauranteContext restauranteContexto)
        {
            _restauranteContexto = restauranteContexto;


        }

        [HttpGet]
        [Route("GetAll")]

        public IActionResult Get()
        {
            List<platos> listadoplatos = (from e in _restauranteContexto.platos select e).ToList();

            if (listadoplatos.Count() == 0)
            {
                return NotFound();
            }
            return Ok(listadoplatos);
        }



        [HttpPost]
        [Route("Agregar")]
        public IActionResult Post([FromBody] platos platos1)
        {
            _restauranteContexto.platos.Add(platos1);
            _restauranteContexto.SaveChanges();
            return Ok(platos1);

        }

        [HttpPut]
        [Route("Actualizar/{id}")]
        public IActionResult actualizar(int id, [FromBody] platos plato)
        {
            platos? platosactu = (from m in _restauranteContexto.platos where m.platoId == id select m).FirstOrDefault();

            if (platosactu == null)
            {
                return NotFound();
            }

            platosactu.platoId = plato.platoId;
            platosactu.nombrePlato = plato.nombrePlato;
            platosactu.precio = plato.precio;
            

            _restauranteContexto.Entry(platosactu).State = EntityState.Modified;
            _restauranteContexto.SaveChanges();
            return Ok(plato);
        }
        [HttpDelete]
        [Route("Eliminar/{id}")]

        public IActionResult eliminarPlatos(int id)
        {
            platos? platosDelete = (from m in _restauranteContexto.platos where m.platoId == id select m).FirstOrDefault();

            if (platosDelete == null)
                return NotFound();
            {
                _restauranteContexto.platos.Attach(platosDelete);
                _restauranteContexto.platos.Remove(platosDelete);
                _restauranteContexto.SaveChanges();

                return Ok(platosDelete);

            }
        }


        [HttpGet]
        [Route("GetValor/{valorM}")]

        public IActionResult GetValor(decimal valorM)
        {
            List<platos> datos = (from e in _restauranteContexto.platos where e.precio<valorM select e).ToList();
            if (datos == null) return NotFound();
            return Ok(datos);
        }


    }
}
