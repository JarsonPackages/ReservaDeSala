using FluentValidator;
using ReservaSala.Dominio.Entidades;
using ReservaSala.Partilha;
using System.Collections.Generic;


namespace ReservaSala.Dominio.Comandos.Saida
{
    public class LoginUsuarioSaida:IComandoResultado
    {
        public LoginUsuarioSaida(bool loginEfetivado, List<Notification> notificacoes, Usuario usuarioClaims)
        {
            LoginEfetivado = loginEfetivado;
            Notificacoes = notificacoes;
            UsuarioClaims = usuarioClaims;
        }

        public bool LoginEfetivado { get; private set; }
        public List<Notification> Notificacoes { get; private set; }
        public Usuario UsuarioClaims { get; private set; }
    }
}
