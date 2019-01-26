
using ReservaSala.Dominio.Entidades;
using System;
using System.Collections.Generic;

namespace ReservaSala.Dominio.Repositorio
{
    public interface ISalaRepositorio
    {
        bool CadastraSala(Sala sala);
        List<Sala> ObterTodos();
        Sala ObterPorId(Guid id);
        bool AtualizarSala(Guid idSalaAtual, Sala novoSala);
    }
}
