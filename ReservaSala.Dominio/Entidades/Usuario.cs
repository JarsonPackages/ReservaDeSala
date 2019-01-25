using ReservaSala.Dominio.Enumerador;
using ReservaSala.Dominio.ObjetoValor;
using ReservaSala.Infra.Entidades;


namespace ReservaSala.Dominio.Entidades
{
    public class Usuario:Entidade
    {
        public Usuario(string nome, Senha senha, TipoUsuario tipoDeUsuario, Documento cpf, Email email)
        {
            Nome = nome;
            Senha = senha;
            TipoDeUsuario = tipoDeUsuario;
            Cpf = cpf;
            Email = email;
        }

        public string Nome { get; private set; }
        public Senha Senha { get; private set; }
        public TipoUsuario TipoDeUsuario { get; private set; }
        public Documento Cpf { get; private set; }
        public Email Email { get; private set; }
    }
}
