using System.Collections.Generic;
using tl2_tp09_2023_danielsj1996.Models;

namespace tl2_tp09_2023_danielsj1996.Repositorios
{
    public interface ITareaRepository
    {
        Tarea CrearTarea(int idTablero, Tarea nuevaTarea);
        Tarea ModificarTarea(int idTarea, Tarea tareaModificada);
        Tarea ObtenerTareaPorId(int idTarea); //
        List<Tarea> ListarTareasPorUsuario(int idUsuario);
        List<Tarea> ListarTareasDeTablero(int idTablero);
        void EliminarTarea(int idTarea);
        void AsignarUsuarioATarea(int idUsuario, int idTarea);
    }
}