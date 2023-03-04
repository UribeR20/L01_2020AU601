using L01_2020AU601.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace L01_2020AU601.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class motoristasController : ControllerBase
    {
        private readonly restauranteContext _restauranteContexto;
        public motoristasController(restauranteContext restauranteContexto)
        {
            _restauranteContexto = restauranteContexto;
        }


        [HttpGet]
        [Route("GetAll")]

        public IActionResult Get()
        {
            List<motoristas> listadoMotoristas = (from e in _restauranteContexto.motoristas select e).ToList();

            if (listadoMotoristas.Count() == 0)
            {
                return NotFound();
            }
            return Ok(listadoMotoristas);
        }

        [HttpPost]
        [Route("Agregar")]
        public IActionResult Post([FromBody] motoristas motoristas1)
        {
            _restauranteContexto.motoristas.Add(motoristas1);
            _restauranteContexto.SaveChanges();
            return Ok(motoristas1);
        }

        [HttpPut]
        [Route("Actualizar/{id}")]
        public IActionResult actualizar(int id, [FromBody] motoristas moto)
        {
            motoristas? motosactu = (from m in _restauranteContexto.motoristas where m.motoristaId == id select m).FirstOrDefault();

            if (motosactu == null)
            {
                return NotFound();
            }

            motosactu.motoristaId = moto.motoristaId;
            motosactu.nombreMotorista = moto.nombreMotorista;
            


            _restauranteContexto.Entry(motosactu).State = EntityState.Modified;
            _restauranteContexto.SaveChanges();
            return Ok(moto);
        }

        [HttpDelete]
        [Route("Eliminar/{id}")]

        public IActionResult eliminarMotoristas(int id)
        {
            motoristas? motosDelete = (from m in _restauranteContexto.motoristas where m.motoristaId == id select m).FirstOrDefault();

            if (motosDelete == null)
                return NotFound();
            {
                _restauranteContexto.motoristas.Attach(motosDelete);
                _restauranteContexto.motoristas.Remove(motosDelete);
                _restauranteContexto.SaveChanges();

                return Ok(motosDelete);
            }
        }

        [HttpGet]
        [Route("GetNombre/{nombreMotoristas}")]

        public IActionResult GetNombre(string nombreMotoristas)
        {
            List<motoristas> datos = (from e in _restauranteContexto.motoristas where e.nombreMotorista.Contains(nombreMotoristas) select e).ToList();
            if (datos == null) return NotFound();
            return Ok(datos);
        }






    }
}
