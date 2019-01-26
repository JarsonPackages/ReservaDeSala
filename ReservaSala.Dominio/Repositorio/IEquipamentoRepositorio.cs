using ReservaSala.Dominio.Entidades;


namespace ReservaSala.Dominio.Repositorio
{
    public interface IEquipamentoRepositorio
    {
        bool CadastraEquipamento(Equipamento equipamento);
    }
}
