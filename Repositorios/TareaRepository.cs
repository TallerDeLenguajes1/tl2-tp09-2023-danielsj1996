using System;
using System.Collections.Generic;
using System.Data.SQLite;
using tl2_tp09_2023_danielsj1996.Models;

namespace tl2_tp09_2023_danielsj1996.Repositorios
{
    public class TareaRepository
    {
        private string cadenaConexion = "Data Source=DB/kanban.db;Cache=Shared";

        public Tarea CrearTarea(int idTablero, Tarea nuevaTarea)

        {
            var query = "INSERT INTO Tarea (id_tablero, nombre_tarea, descripcion_tarea, estado_tarea, color_tarea, id_usuario_asignado) " +
                        "VALUES (@idTablero, @nombreTarea, @descripcionTarea, @estadoTarea, @colorTarea, @idUsuarioA);";

            using (SQLiteConnection connection = new SQLiteConnection(cadenaConexion))
            {
                connection.Open();
                var command = new SQLiteCommand(query, connection);
                command.Parameters.Add(new SQLiteParameter("@idTablero", idTablero));
                command.Parameters.Add(new SQLiteParameter("@nombreTarea", nuevaTarea.NombreTarea));
                command.Parameters.Add(new SQLiteParameter("@descripcionTarea", nuevaTarea.DescripcionTarea));
                command.Parameters.Add(new SQLiteParameter("@estadoTarea", nuevaTarea.EstadoTarea.ToString()));
                command.Parameters.Add(new SQLiteParameter("@colorTarea", nuevaTarea.Color));
                command.Parameters.Add(new SQLiteParameter("@idUsuarioAsignado", nuevaTarea.IdUsuarioAsignado));
                command.ExecuteNonQuery();
                connection.Close();
                return nuevaTarea;


            }
        }

        public Tarea ModificarTarea(int idTarea, Tarea tareaAModificar)
        {
                        var query = "UPDATE Tarea " +
                        "SET nombre_tarea = @nombreTarea, descripcion_tarea = @descripcionTarea, estado_tarea = @estadoTarea, color_tarea = @colorTarea, id_usuario_asignado = @idUsuarioAsignado " +
                        "WHERE id_tarea = @idTarea;";
            using (SQLiteConnection connection = new SQLiteConnection(cadenaConexion))
            {
                connection.Open();
                var command = new SQLiteCommand(query, connection);
                command.Parameters.Add(new SQLiteParameter("@nombreTarea", tareaAModificar.NombreTarea));
                command.Parameters.Add(new SQLiteParameter("@descripcionTarea", tareaAModificar.DescripcionTarea));
                command.Parameters.Add(new SQLiteParameter("@estadoTarea", tareaAModificar.EstadoTarea.ToString()));
                command.Parameters.Add(new SQLiteParameter("@colorTarea", tareaAModificar.Color));
                command.Parameters.Add(new SQLiteParameter("@idUsuarioAsignado", tareaAModificar.IdUsuarioAsignado));
                command.Parameters.Add(new SQLiteParameter("@idTarea", idTarea));
                command.ExecuteNonQuery();
                connection.Close();
            }
            return tareaAModificar;

        }

        public Tarea ObtenerTareaPorId(int idTarea)
        {

            var query = "SELECT * FROM Tarea WHERE id_tarea = @idTarea;";
            using (SQLiteConnection connection = new SQLiteConnection(cadenaConexion))
            {
                connection.Open();
                var command = new SQLiteCommand(query, connection);
                command.Parameters.Add(new SQLiteParameter("@idTarea", idTarea));
                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        var tarea = new Tarea();
                        tarea.IdTarea = Convert.ToInt32(reader["id_tarea"]);
                        tarea.IdTablero = Convert.ToInt32(reader["id_tablero"]);
                        tarea.NombreTarea = reader["nombre_tarea"].ToString();
                        tarea.DescripcionTarea = reader["descripcion_tarea"].ToString();
                        tarea.Color = reader["color_tarea"].ToString();
                        tarea.EstadoTarea = (EstadoTarea)Enum.Parse(typeof(EstadoTarea), reader["estado_tarea"].ToString());
                        tarea.IdUsuarioAsignado = Convert.ToInt32(reader["id_usuario_asignado"]);
                        return tarea;
                    }
                }
                connection.Close();
            }
            return null;
        }

        public List<Tarea> ListarTareasPorUsuario(int idUsuario)
        {


            var query = "SELECT * FROM Tarea WHERE id_usuario_asignado = @id_usuario";
            List<Tarea> listaDeTareas = new List<Tarea>();
            using (SQLiteConnection connection = new SQLiteConnection(cadenaConexion))
            {
                connection.Open();
                var command = new SQLiteCommand(query, connection);
                command.Parameters.Add(new SQLiteParameter("@id_usuario", idUsuario));
                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var tarea = new Tarea();
                        tarea.IdTarea = Convert.ToInt32(reader["id_tarea"]);
                        tarea.IdTablero = Convert.ToInt32(reader["id_tablero"]);
                        tarea.NombreTarea = reader["nombre_tarea"].ToString();
                        tarea.DescripcionTarea = reader["descripcion_tarea"].ToString();
                        tarea.Color = reader["color_tarea"].ToString();
                        tarea.EstadoTarea = (EstadoTarea)Enum.Parse(typeof(EstadoTarea), reader["estado_tarea"].ToString());
                        tarea.IdUsuarioAsignado = Convert.ToInt32(reader["id_usuario_asignado"]);
                        listaDeTareas.Add(tarea);
                    }
                }
                connection.Close();
            }
            return listaDeTareas;

        }

        public List<Tarea> ListarTareasDeTablero(int idTablero)
        {

            var query = "SELECT * FROM Tarea WHERE id_tablero = @idTablero";
            List<Tarea> listaDeTareas = new List<Tarea>();
            using (SQLiteConnection connection = new SQLiteConnection(cadenaConexion))
            {
                connection.Open();
                var command = new SQLiteCommand(query, connection);
                command.Parameters.Add(new SQLiteParameter("@idTablero", idTablero));
                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var tarea = new Tarea();
                        tarea.IdTarea = Convert.ToInt32(reader["id_tarea"]);
                        tarea.IdTablero = Convert.ToInt32(reader["id_tablero"]);
                        tarea.NombreTarea = reader["nombre_tarea"].ToString();
                        tarea.DescripcionTarea = reader["descripcion_tarea"].ToString();
                        tarea.Color = reader["color_tarea"].ToString();
                        tarea.EstadoTarea = (EstadoTarea)Enum.Parse(typeof(EstadoTarea), reader["estado_tarea"].ToString());
                        tarea.IdUsuarioAsignado = Convert.ToInt32(reader["id_usuario_asignado"]);
                        listaDeTareas.Add(tarea);
                    }
                }
                connection.Close();
            }
            return listaDeTareas;
        }

        public void EliminarTarea(int idTarea)
        {

            var query = "DELETE FROM Tarea WHERE id_tarea= @idTarea;";
            using (SQLiteConnection connection = new SQLiteConnection(cadenaConexion))
            {
                connection.Open();
                var command = new SQLiteCommand(query, connection);
                command.Parameters.Add(new SQLiteParameter("@idTarea", idTarea));
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
        public void AsignarUsuarioATarea(int idUsuario, int idTarea)
        {

            var query = "UPDATE Tarea SET id_usuario_asignado = @idUsuario WHERE id_tarea=@idTarea;";
            using (SQLiteConnection connection = new SQLiteConnection(cadenaConexion))
            {
                connection.Open();
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {

                    command.Parameters.Add(new SQLiteParameter("@idUsuario", idUsuario));
                    command.Parameters.Add(new SQLiteParameter("@idTarea", idTarea));
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }
    }
}