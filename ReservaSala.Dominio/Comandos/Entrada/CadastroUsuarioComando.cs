using ReservaSala.Partilha;


namespace ReservaSala.Dominio.Comandos.Entrada
{
    public class CadastroUsuarioComando:IComando
    {
        public string Nome { get; set; }
        public string  Email { get;  set; }
        public string Senha { get; set; }
        public string CPF { get; set; }
        public int TipoUsuario { get; set; }
    }
}
