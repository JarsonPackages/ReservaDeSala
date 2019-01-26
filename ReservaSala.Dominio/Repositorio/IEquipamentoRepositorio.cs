using ReservaSala.Dominio.Entidades;
using System;
using System.Collections.Generic;

namespace ReservaSala.Dominio.Repositorio
{
    public interface IEquipamentoRepositorio
    {
        bool CadastraEquipamento(Equipamento equipamento);
         List<Equipamento> ObterTodos();
        Equipamento ObterPorId(Guid id);
        bool AtualizarEquipamento(Guid idEquipamentoAtual, Equipamento novoEquipamento);
    }
}
