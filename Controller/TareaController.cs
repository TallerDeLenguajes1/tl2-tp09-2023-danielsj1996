using Microsoft.AspNetCore.Mvc;
using tl2_tp09_2023_danielsj1996.Models;
using tl2_tp09_2023_danielsj1996.Repositorios;

namespace tl2_tp09_2023_danielsj1996.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TareaController : ControllerBase
    {
        private readonly TareaRepository tareaRepository;

        public TareaController()
        {
            tareaRepository = new TareaRepository();
        }

        [HttpPost]
        public ActionResult<Tarea> CrearTarea(int idTablero, Tarea nuevaTarea)
        {
            var tareaCreada = tareaRepository.CrearTarea(idTablero, nuevaTarea);
            return Ok(tareaCreada);
        }

        [HttpPut("{idTarea}")]
        public ActionResult<Tarea> ModificarTarea(int idTarea, Tarea tareaModificada)
        {
            var tareaModificad = tareaRepository.ModificarTarea(idTarea, tareaModificada);
            return Ok(tareaModificad);
        }

        [HttpGet("{idTarea}")]
        public ActionResult<Tarea> ObtenerTarea(int idTarea)
        {
            var tarea = tareaRepository.ObtenerTareaPorId(idTarea);
            if (tarea != null)
            {
                return Ok(tarea);
            }
            return NotFound("Tarea no encontrada");
        }

        [HttpGet("usuario/{idUsuario}")]
        public ActionResult<List<Tarea>> ListarTareasPorUsuario(int idUsuario)
        {
            var tareas = tareaRepository.ListarTareasPorUsuario(idUsuario);
            return Ok(tareas);
        }

        [HttpGet("tablero/{idTablero}")]
        public ActionResult<List<Tarea>> ListarTareasPorTablero(int idTablero)
        {
            var tareas = tareaRepository.ListarTareasDeTablero(idTablero);
            return Ok(tareas);
        }

        [HttpDelete("{idTarea}")]
        public ActionResult EliminarTarea(int idTarea)
        {
            tareaRepository.EliminarTarea(idTarea);
            return Ok("Tarea eliminada");
        }

        [HttpPost("asignar")]
        public ActionResult AsignarUsuarioATarea(int idUsuario, int idTarea)
        {
            tareaRepository.AsignarUsuarioATarea(idUsuario, idTarea);
            return Ok("Usuario asignado a tarea");
        }

        [HttpPut("{id}/Nombre/{nombre}")]
        public ActionResult ModificarNombreTarea(int id, string nombre)
        {
            var tareaExistente = tareaRepository.ObtenerTareaPorId(id);
            if (tareaExistente == null)
            {
                return NotFound("Tarea no encontrada");
            }

            tareaExistente.NombreTarea = nombre;
            var tareaModificada = tareaRepository.ModificarTarea(id, tareaExistente);

            return Ok(tareaModificada);
        }


        [HttpPut("{id}/Estado/{estado}")]
        public ActionResult<Tarea> ModificarEstadoTarea(int id, EstadoTarea estado)
        {
            var tareaExistente = tareaRepository.ObtenerTareaPorId(id);
            if (tareaExistente != null)
            {
                tareaExistente.EstadoTarea = estado;
                var tareaModificada = tareaRepository.ModificarTarea(id, tareaExistente);
                return Ok(tareaModificada);
            }
            return NotFound("Tarea no encontrada");
        }

    }
}