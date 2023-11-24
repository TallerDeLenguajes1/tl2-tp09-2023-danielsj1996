namespace tl2_tp09_2023_danielsj1996.Models
{


    public class Tablero
    {

        private int idTablero;
        private int idUsuarioPropietario;
        private string? nombreTablero;
        private string descripcion_tablero;

        public int IdTablero { get => idTablero; set => idTablero = value; }
        public int IdUsuarioPropietario { get => idUsuarioPropietario; set => idUsuarioPropietario = value; }
        public string? NombreTablero { get => nombreTablero; set => nombreTablero = value; }
        public string Descripcion_tablero { get => descripcion_tablero; set => descripcion_tablero = value; }
    }

}