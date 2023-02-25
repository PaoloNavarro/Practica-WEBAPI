using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WEB_API.Models;
using Microsoft.EntityFrameworkCore;

namespace WEB_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquiposController : ControllerBase
    {
        private readonly equiposContext _equiposConext;

        public EquiposController(equiposContext equiposContext)
        {
            _equiposConext = equiposContext;
        }
        [HttpGet]
        [Route("getall")]

        public IActionResult ObtenerEquipos()
        {
            List<equipos> ListadoEquipo = (from e in _equiposConext.equipos select e).ToList();
            if (ListadoEquipo.Count == 0)
            {
                return NotFound();
            }
            return Ok(ListadoEquipo);
        }
        //NUEVO
        [HttpGet]
        [Route("getbyid/{id}/{nombre}")]
        //AAJAAA
        public IActionResult get(int id) {

            equipos? unEquipo = (from e in _equiposConext.equipos
                                 where e.id_equipos == id
                                 select e).FirstOrDefault();
            if (unEquipo == null) {
                return NotFound();
            }
            return Ok(unEquipo);
        }
        [HttpGet]
        [Route("find")]
        public IActionResult buscar(string filtro) {

            List<equipos> equiposList = (from e in _equiposConext.equipos
                                         where e.nombre.Contains(filtro) || e.descripcion.Contains(filtro)
                                         select e).ToList();

            if (equiposList.Any())
            {
                return Ok(equiposList);
            }

            return NotFound();


        }
        [HttpPost]
        [Route("add")]
        public IActionResult Crear([FromBody] equipos equipoNuevo) {

            try
            {
                _equiposConext.equipos.Add(equipoNuevo);
                _equiposConext.SaveChanges();

                return Ok(equipoNuevo);

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        
        }
        [HttpPut]
        [Route("actualizar")]

        public IActionResult actualizarEquipo(int id,[FromBody]equipos equipoModificar)
        {
            equipos? equipoExiste = (from e in _equiposConext.equipos
                                    where e.id_equipos ==id
                                    select e).FirstOrDefault();
            if(equipoExiste == null)
                return NotFound();

            equipoExiste.nombre = equipoModificar.nombre;
            equipoExiste.descripcion = equipoModificar.descripcion;

            _equiposConext.Entry(equipoExiste).State = EntityState.Modified;
            _equiposConext.SaveChanges();

            return Ok(equipoExiste);
        }
        [HttpDelete]
        [Route("delete/{id}")]
        public IActionResult eliminarEquipo(int id)
        {
            equipos? equipoExiste = (from e in _equiposConext.equipos
                                     where e.id_equipos == id
                                     select e).FirstOrDefault();
            if (equipoExiste == null)
                return NotFound();
            
            _equiposConext.Attach(equipoExiste);
            _equiposConext.Remove(equipoExiste);
            _equiposConext.SaveChanges();

            return Ok(equipoExiste);


        }




    }
}
