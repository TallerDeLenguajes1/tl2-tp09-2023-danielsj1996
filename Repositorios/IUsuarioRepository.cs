using tl2_tp09_2023_danielsj1996.Models;

namespace tl2_tp09_2023_danielsj1996.Repositorios
{
public interface IUsuarioRepository
{
    public void CrearUsuario(Usuario usuarios);
    public List<Usuario> TraerTodosLosUsuarios();
    public Usuario TraerUsuariosPorId(int id);
    public void Eliminarusuario(int id);
    public void ModificarUsuario(Usuario Usuarios,int id);

}
}