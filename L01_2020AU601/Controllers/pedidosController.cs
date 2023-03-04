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
        }

    }
}
