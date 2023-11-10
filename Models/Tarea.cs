namespace TP9.Models
{
    enum EstadoTarea
    {
        Ideas, ToDo, Doing, Review, Done
    }
    public class Tarea
    {
        private int idTarea;
        private int idTablero;
        private string? nombreTarea;
        private string? descripcionTarea;
        private string? color;
        private EstadoTarea estado;
        private int? idUsuarioAsignado;

        public int IdTarea { get => idTarea; set => idTarea = value; }
        public string? NombreTarea { get => nombreTarea; set => nombreTarea = value; }
        public string? DescripcionTarea { get => descripcionTarea; set => descripcionTarea = value; }
        public string? Color { get => color; set => color = value; }
        public int? IdUsuarioAsignado { get => idUsuarioAsignado; set => idUsuarioAsignado = value; }
        internal EstadoTarea Estado { get => estado; set => estado = value; }
        public int IdTablero { get => idTablero; set => idTablero = value; }

        public Tarea(){

        estado=EstadoTarea.Ideas;
    }
    
    }
}