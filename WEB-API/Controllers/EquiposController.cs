using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WEB_API.Models;

namespace WEB_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquiposController : ControllerBase
    {
        private readonly equiposContext _equiposConext;

        public EquiposController(equiposContext equiposContext)
        {
            _equiposConext= equiposContext;
        }
        [HttpGet]
        [Route("getall")]

        public IActionResult ObtenerEquipos()
        {
            List<equipos> ListadoEquipo =(from e in _equiposConext.equipos select e).ToList();
            if (ListadoEquipo.Count == 0)
            {
                return NotFound();
            }
            return Ok(ListadoEquipo);
        }
    }
}
