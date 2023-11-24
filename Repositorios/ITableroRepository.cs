using tl2_tp09_2023_danielsj1996.Models;

namespace tl2_tp09_2023_danielsj1996
{
    public interface ITableroRepository
    {
        public List<Tablero> ListarTableros();
        public List<Tablero> MostrarTableroPorIdDeUsuario(int id);
        public void CrearTablero(Tablero tablero);
        public void EliminarTableroPorId(int id);
        public void ModificarTablero(Tablero tablero, int id);

    public Tablero BuscarTableroPorId(int idTablero);
    
    }
}