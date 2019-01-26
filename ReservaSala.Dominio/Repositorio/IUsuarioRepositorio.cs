using ReservaSala.Dominio.Entidades;
using ReservaSala.Dominio.ObjetoValor;
using System;

namespace ReservaSala.Dominio.Repositorio
{
    public interface IUsuarioRepositorio
    {
        bool CadastraUsuario(Usuario usuario);
        bool AlterarSenha(Guid usuario,Senha senha);
        Usuario ObterPorId(Guid usuario);
        Usuario LoginUsuario(LoginUsuario usuario);
    }
}
