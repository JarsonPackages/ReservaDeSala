using ReservaSala.Dominio.Entidades;
using System;
using System.Collections.Generic;

namespace ReservaSala.Dominio.Repositorio
{
    public interface IBlocoRepositorio
    {
        bool CadastraBloco(Bloco bloco);
        List<Bloco> ObterTodos();
        Bloco ObterPorId(Guid id);
        bool AtualizarBloco(Guid idBlocoAtual, Bloco novoBloco);

    }
}
