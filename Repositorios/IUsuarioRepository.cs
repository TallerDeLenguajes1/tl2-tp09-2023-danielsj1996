namespace webapi;
public interface IUsuarioRepository
{
    public List<Usuario> GetAll();
    public Usuario GetById(int id);
    public void Create(Usuario usuarios);
    public void Remove(int id);
    public void Update(Usuario Usuarios,int id);

}