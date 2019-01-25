using FluentValidator;
using ReservaSala.Dominio.Comandos.Entrada;
using ReservaSala.Dominio.Comandos.Saida;
using ReservaSala.Dominio.Entidades;
using ReservaSala.Dominio.Enumerador;
using ReservaSala.Dominio.ObjetoValor;
using ReservaSala.Partilha;
using System.Collections.Generic;
using ReservaSala.Dominio.Utilidades;
using ReservaSala.Dominio.Repositorio;

namespace ReservaSala.Dominio.Comandos.Manipular
{
    public class CadastroUsuarioManipular : IComandoManipulador<CadastroUsuarioComando>
    {
        IUsuarioRepositorio UsuarioRepositorio;

        public CadastroUsuarioManipular(IUsuarioRepositorio _UsuarioRepositorio)
        {
            UsuarioRepositorio = _UsuarioRepositorio;
        }
        public IComandoResultado Manipular(CadastroUsuarioComando comando)
        {
            Senha senha = new Senha(comando.Senha);

            Email email = new Email(comando.Email);

            Documento documento = new Documento(comando.CPF);

            Usuario usuario = new Usuario(comando.Nome, senha, (TipoUsuario)comando.TipoUsuario, documento, email);
            usuario.AdicionaNotificacoes(documento.Notifications, email.Notifications, senha.Notifications);


            if (!usuario.IsValid())
            {
                CadastroUsuarioSaida UsuarioSaida = new CadastroUsuarioSaida();
                UsuarioSaida.UsuarioCadastrado = false;
                UsuarioSaida.Notificacoes = (List<Notification>)usuario.Notifications;
                return UsuarioSaida;
            }



            senha.Criptografar(Utilidades.Criptografia.TipoCriptografia.MD5);

            bool usuarioCadastrado = UsuarioRepositorio.CadastraUsuario(usuario);


            CadastroUsuarioSaida cadastroUsuarioSaida = new CadastroUsuarioSaida();

            cadastroUsuarioSaida.Notificacoes = (List<Notification>)usuario.Notifications;
            cadastroUsuarioSaida.UsuarioCadastrado = usuarioCadastrado;

            return cadastroUsuarioSaida;
        }


    }
}
