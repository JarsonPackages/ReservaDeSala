using ReservaSala.Dominio.Entidades;


namespace ReservaSala.Dominio.Repositorio
{
    public interface IUsuarioRepositorio
    {
        bool CadastraUsuario(Usuario usuario);
    }
}
