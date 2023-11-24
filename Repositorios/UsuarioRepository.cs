using System.Data.SQLite;
using tl2_tp09_2023_danielsj1996.Models;

namespace tl2_tp09_2023_danielsj1996.Repositorios
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private string cadenaConexion = "Data Source=DB/kanban.db;Cache=Shared";

        public void CrearUsuario(Usuario usuario)
        {
            var query = "INSERT INTO Usuario (nombre_de_usuario) VALUES (@nombre_de_usuario)";
            using (SQLiteConnection connection = new SQLiteConnection(cadenaConexion))
            {

                connection.Open();
                var command = new SQLiteCommand(query, connection);
                command.Parameters.Add(new SQLiteParameter("@nombre_de_usuario", usuario.NombreDeUsuario));
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
        public List<Usuario> TraerTodosLosUsuarios()
        {
            var query = "SELECT * FROM Usuario;";
            List<Usuario> listaDeUsuarios = new List<Usuario>();
            using (SQLiteConnection connection = new SQLiteConnection(cadenaConexion))
            {
                connection.Open();
                SQLiteCommand command = new SQLiteCommand(query, connection);

                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var usuario = new Usuario();
                        usuario.Id = Convert.ToInt32(reader["id_usuario"]);
                        usuario.NombreDeUsuario = reader["nombre_de_usuario"].ToString();
                        listaDeUsuarios.Add(usuario);
                    }
                }
                connection.Close();
            }
            return listaDeUsuarios;
        }

        public Usuario TraerUsuariosPorId(int idusuario)
        {
            var query = "SELECT * FROM Usuario WHERE id_usuario = @id_usuario";
            using (SQLiteConnection connection = new SQLiteConnection(cadenaConexion))
            {
                connection.Open();
                var command = new SQLiteCommand(query, connection);
                command.Parameters.Add(new SQLiteParameter("@id_usuario", idusuario));
                var usuario = new Usuario();
                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        usuario.Id = Convert.ToInt32(reader["id_usuario"]);
                        usuario.NombreDeUsuario = reader["nombre_de_usuario"].ToString();
                    }
                    connection.Close();
                    return usuario;
                }
            }
        }


        public void Eliminarusuario(int id)
        {
            var query = "DELETE FROM Usuario WHERE id_usuario= @idBuscado";
            using (SQLiteConnection connection = new SQLiteConnection(cadenaConexion))
            {

                connection.Open();
                var command = new SQLiteCommand(query, connection);
                command.Parameters.Add(new SQLiteParameter("@idBuscado", id));
                command.ExecuteNonQuery();
                connection.Close();

            }

        }
        public void ModificarUsuario(Usuario usuario, int id)
        {
            var query = "UPDATE Usuario SET nombre_de_usuario = @nombre_de_usuario WHERE id = @idBuscado";
            using (SQLiteConnection connection = new SQLiteConnection(cadenaConexion))
            {

                connection.Open();
                var command = new SQLiteCommand(query, connection);
                command.Parameters.Add(new SQLiteParameter("@nombre_de_usuario", usuario.NombreDeUsuario));
                command.Parameters.Add(new SQLiteParameter("@idBuscado", id));
                command.ExecuteNonQuery();
                connection.Close();
            }


        }

    }

}
