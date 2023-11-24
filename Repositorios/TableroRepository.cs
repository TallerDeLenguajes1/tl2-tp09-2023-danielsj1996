using System.Data.SQLite;
using tl2_tp09_2023_danielsj1996.Models;

namespace tl2_tp09_2023_danielsj1996.Repositorios
{
    public class TableroRepository : ITableroRepository
    {
        private string cadenaConexion = "Data Source=DB/kanban.db;Cache=Shared";

        public void CrearTablero(Tablero nuevotablero)
        {
            var query = "INSERT INTO Tablero (id_usuario_propietario,nombre_tablero,descripcion_tablero) VALUES (@idPropietario,@nombreTablero,@descripcionTablero);";
            using (SQLiteConnection connection = new SQLiteConnection(cadenaConexion))
            {

                connection.Open();
                var command = new SQLiteCommand(query, connection);
                command.Parameters.Add(new SQLiteParameter("@@idPropietario", nuevotablero.IdUsuarioPropietario));
                command.Parameters.Add(new SQLiteParameter("@nombreTablero", nuevotablero.NombreTablero));
                command.Parameters.Add(new SQLiteParameter("@descripcionTablero", nuevotablero.Descripcion_tablero));

                command.ExecuteNonQuery();

                connection.Close();
            }
        }


        public void EliminarTableroPorId(int id)
        {
            var query = "DELETE FROM Tablero WHERE id_tablero= @idBuscado";
            using (SQLiteConnection connection = new SQLiteConnection(cadenaConexion))
            {

                connection.Open();
                var command = new SQLiteCommand(query, connection);
                command.Parameters.Add(new SQLiteParameter("@idBuscado", id));
                command.ExecuteNonQuery();
                connection.Close();

            }

        }
        public List<Tablero> MostrarTableroPorIdDeUsuario(int idusuario)
        {
            var query = "SELECT * FROM Usuario WHERE id_usuario_propietario = @id_usuario";
            List<Tablero> tableros = new List<Tablero>();
            using (SQLiteConnection connection = new SQLiteConnection(cadenaConexion))
            {
                connection.Open();
                var command = new SQLiteCommand(query, connection);
                command.Parameters.Add(new SQLiteParameter("@id_usuario", idusuario));

                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var tablero = new Tablero
                        {

                            IdTablero = Convert.ToInt32(reader["id_tablero"]),
                            NombreTablero = reader["nombre_tablero"].ToString(),
                            Descripcion_tablero = reader["descripcion_tablero"].ToString(),
                            IdUsuarioPropietario = Convert.ToInt32(reader["id_usuario_propietario"])

                        };
                        tableros.Add(tablero);
                        connection.Close();
                    }
                }
            }
            return tableros;
        }
        public List<Tablero> ListarTableros()
        {
            var query = "SELECT * FROM Tablero";
            List<Tablero> listaDeTableros = new List<Tablero>();
            using (SQLiteConnection connection = new SQLiteConnection(cadenaConexion))
            {
                connection.Open();
                var command = new SQLiteCommand(query, connection);
                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var tableros = new Tablero();
                        tableros.IdTablero = Convert.ToInt32(reader["id_tablero"]);
                        tableros.NombreTablero = reader["nombre_tablero"].ToString();
                        tableros.Descripcion_tablero = reader["descripcion_tablero"].ToString();
                        tableros.IdUsuarioPropietario = Convert.ToInt32(reader["id_usuario_propietario"]);
                        listaDeTableros.Add(tableros);
                    }
                }
                connection.Close();
            }
            return listaDeTableros;
        }


        public void ModificarTablero(Tablero modificarTablero, int id)
        {
            var query = "UPDATE Tablero SET id_usuario_propietario= @idPropietario,nombre_tablero=@nombreTablero,descripcion_tablero=@descripcionTablero WHERE id_tablero = @idRecibe";
            using (SQLiteConnection connection = new SQLiteConnection(cadenaConexion))
            {

                connection.Open();
                var command = new SQLiteCommand(query, connection);
                command.Parameters.Add(new SQLiteParameter("@idPropietario", modificarTablero.IdUsuarioPropietario));
                command.Parameters.Add(new SQLiteParameter("@nombreTablero", modificarTablero.NombreTablero));
                command.Parameters.Add(new SQLiteParameter("@descripcionTablero", modificarTablero.Descripcion_tablero));
                command.Parameters.Add(new SQLiteParameter("@idBuscado", id));
                command.ExecuteNonQuery();
                connection.Close();
            }


        }

        public Tablero BuscarTableroPorId(int idTablero)
        {
            var query = "SELECT * FROM Tablero WHERE id_tablero=@idTablero;";
            using (SQLiteConnection connection = new SQLiteConnection(cadenaConexion))
            {
                connection.Open();
                var command = new SQLiteCommand(query, connection);
                command.Parameters.Add(new SQLiteParameter("@idTablero", idTablero));
                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        var tablero = new Tablero
                        {

                            IdTablero = Convert.ToInt32(reader["id_tablero"]),
                            NombreTablero = reader["nombre_tablero"].ToString(),
                            Descripcion_tablero = reader["descripcion_tablero"].ToString(),
                            IdUsuarioPropietario = Convert.ToInt32(reader["id_usuario_propietario"])
                        };
                        connection.Close();
                        return tablero;
                    }
                }
                return null;
            }

        }
    }
}