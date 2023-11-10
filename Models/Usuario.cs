namespace webapi;


public class Usuario
{
    private int id;
    private string nombreDeUsuario;


    public int Id { get => id; set => id = value; }
    public string NombreDeUsuario { get => nombreDeUsuario; set => nombreDeUsuario = value; }

    public Usuario(int id, string nombreDeUsuario)
    {
        this.id = id;
        this.nombreDeUsuario = nombreDeUsuario;
    }
    public Usuario() { }
}