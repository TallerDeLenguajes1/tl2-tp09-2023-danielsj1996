using System.Data.SQLite;
using TP9.Models;

namespace TP9.Repositorios
{
    public class UsuariosRepository : IUsuarioRepository
    {
        private string cadenaConexion = "Data Source=DB/kanban.db;Cache=Shared";

        public void CrearUsuario(Usuario usuario)
        {
            var query = "INSERT INTO usuarios (nombre_de_usuario) VALUES (@nombre_de_usuario)";
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
            var query = "SELECT * FROM usuarios;";
            List<Usuario> usuarios = new List<Usuario>();
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
                        usuarios.Add(usuario);
                    }
                }
                connection.Close();
            }
            return usuarios;
        }

        public Usuario TraerUsuariosPorId(int idusuario)
        {
            var query = "SELECT * FROM Usuarios WHERE id_usuario = @id_usuario";
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
            var query = "DELETE FROM usuarios WHERE id= @idBuscado";
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
            var query = "UPDATE usuarios SET nombre_de_usuario = @nombre_de_usuario WHERE id = @idBuscado";
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
