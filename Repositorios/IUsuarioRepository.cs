using TP9.Models;

namespace TP9{
public interface IUsuarioRepository
{
    public void CrearUsuario(Usuario usuarios);
    public List<Usuario> TraerTodosLosUsuarios();
    public Usuario TraerUsuariosPorId(int id);
    public void Eliminarusuario(int id);
    public void ModificarUsuario(Usuario Usuarios,int id);

}
}