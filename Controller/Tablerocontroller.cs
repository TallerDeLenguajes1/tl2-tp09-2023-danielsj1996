using Microsoft.AspNetCore.Mvc;
using tl2_tp09_2023_danielsj1996.Models;
using tl2_tp09_2023_danielsj1996.Repositorios;

namespace tl2_tp09_2023_danielsj1996.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TableroController : ControllerBase
    {
        private readonly TableroRepository tableroRepository;

        public TableroController()
        {
            tableroRepository = new TableroRepository();
        }

        [HttpPost]
        public ActionResult CrearTablero(Tablero nuevoTablero)
        {
            tableroRepository.CrearTablero(nuevoTablero);
            return Ok(nuevoTablero);
        }

        [HttpDelete("{id}")]
        public ActionResult EliminarTablero(int id)
        {
            tableroRepository.EliminarTableroPorId(id);
            return Ok("Tablero eliminado");
        }

        [HttpGet]
        public ActionResult<List<Tablero>> ListarTodosTableros()
        {
            var tableros = tableroRepository.ListarTableros();
            if (tableros != null)
            {
                return Ok(tableros);
            }
            return NotFound("No se encontraron tableros.");
        }

        [HttpPut("{id}")]
        public ActionResult ModificarTablero(int id, Tablero modificarTablero)
        {
            tableroRepository.ModificarTablero(modificarTablero, id);
            return Ok(modificarTablero);
        }

        [HttpGet("{id}")]
        public ActionResult<Tablero> ObtenerTableroPorId(int id)
        {
            var tablero = tableroRepository.BuscarTableroPorId(id);
            if (tablero != null)
            {
                return Ok(tablero);
            }
            return NotFound("Tablero no encontrado");
        }
    }
}