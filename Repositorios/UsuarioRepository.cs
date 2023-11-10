using System.Data.SQLite;

namespace webapi
{
    public class UsuariosRepository : IUsuarioRepository
    {
        private string cadenaConexion = "Data Source=DB/kanvas.db;Cache=Shared";

        public List<Usuario> GetAll()
        {
            var queryString = @"SELECT * FROM usuarios;";
            List<Usuario> usuarios = new List<Usuario>();
            using (SQLiteConnection connection = new SQLiteConnection(cadenaConexion))
            {
                SQLiteCommand command = new SQLiteCommand(queryString, connection);
                connection.Open();

                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var usuario = new Usuario();
                        usuario.Id = Convert.ToInt32(reader["id"]);
                        usuario.NombreDeUsuario = reader["nombre_de_usuario"].ToString();
                        usuarios.Add(usuario);
                    }
                }
                connection.Close();
            }
            return usuarios;
        }

        public Usuario GetById(int idusuario)
        {
            SQLiteConnection connection = new SQLiteConnection(cadenaConexion);
            var usuario = new Usuario();
            SQLiteCommand command = connection.CreateCommand();
            command.CommandText = $"SELECT * FROM usuarios WHERE id = '{usuario.Id}';";
            command.CommandText = "SELECT * FROM usuarios WHERE id = @idusuario";
            command.Parameters.Add(new SQLiteParameter("@idusuario", usuario.Id));
            connection.Open();
            using (SQLiteDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    usuario.Id = Convert.ToInt32(reader["id"]);
                    usuario.NombreDeUsuario = reader["nombre_de_usuario"].ToString();
                }
            }
            connection.Close();

            return (usuario);
        }

        public void Create(Usuario usuario)
        {
            var query = $"INSERT INTO usuarios (nombre_de_usuario) VALUES (@nombre_de_usuario)";
            using (SQLiteConnection connection = new SQLiteConnection(cadenaConexion))
            {

                connection.Open();

                var command = new SQLiteCommand(query, connection);
                command.Parameters.Add(new SQLiteParameter("@nombre_de_usuario", usuario.NombreDeUsuario));

                command.ExecuteNonQuery();

                connection.Close();
            }
        }

        public void Update(Usuario usuario, int id)
        {
            var query = $"UPDATE usuarios SET nombre_de_usuario = '@name' WHERE id = '@idBuscado';";
            using (SQLiteConnection connection = new SQLiteConnection(cadenaConexion))
            {

                connection.Open();
                var command = new SQLiteCommand(query, connection);
                command.Parameters.Add(new SQLiteParameter("@name", usuario.NombreDeUsuario));
                command.Parameters.Add(new SQLiteParameter("@idBuscado", id));
                command.ExecuteNonQuery();
                connection.Close();
            }


        }

        public void Remove(int id)
        {
            var query = $"DELETE FROM usuarios WHERE id='@idBuscado';";
            using (SQLiteConnection connection = new SQLiteConnection(cadenaConexion))
            {

                connection.Open();
                var command = new SQLiteCommand(query, connection);
                command.Parameters.Add(new SQLiteParameter("@idBuscado", id));
                command.ExecuteNonQuery();
                connection.Close();

            }

        }
    }

}
