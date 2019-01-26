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
    public class UsuarioManipulador : IComandoManipulador<CadastroUsuarioComando>,IComandoManipulador<LoginUsuarioComando>
    {
        IUsuarioRepositorio UsuarioRepositorio;

        public UsuarioManipulador(IUsuarioRepositorio _UsuarioRepositorio)
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
                OperacaoPadraoSaida UsuarioSaida = new OperacaoPadraoSaida(false,(List<Notification>)usuario.Notifications);
        
                return UsuarioSaida;
            }

            senha.Criptografar(Utilidades.Criptografia.TipoCriptografia.MD5);

            bool usuarioCadastrado = UsuarioRepositorio.CadastraUsuario(usuario);

            return new OperacaoPadraoSaida(usuarioCadastrado);
        }

        public IComandoResultado Manipular(LoginUsuarioComando comando)
        {
            Email email = new Email(comando.Email);
            Senha senha = new Senha(comando.Senha);

            LoginUsuario usuarioLogin = new LoginUsuario(email,senha);
            usuarioLogin.AdicionaNotificacoes(email.Notifications, senha.Notifications);
            if (!usuarioLogin.IsValid())
            {
                  return new LoginUsuarioSaida(false,(List<Notification>) usuarioLogin.Notifications,null  );
            }
            Usuario usuario = UsuarioRepositorio.LoginUsuario(usuarioLogin);
            bool loginRealizado= usuario == null ? false :true ;

            return new LoginUsuarioSaida(loginRealizado,(List<Notification>) usuarioLogin.Notifications,usuario  );

        }
    }
}
