using FluentValidator;
using ReservaSala.Dominio.Utilidades;


namespace ReservaSala.Dominio.ObjetoValor
{
    public class Senha:Notifiable
    {
        public string NomeSenha { get; private set; }
        public Senha(string senha)
        {
            NomeSenha = senha;
            if(NomeSenha.Length < 4)
            {
                AddNotification("Senha", "Digite uma senha valida");
            }
        }

        public void Criptografar(Criptografia.TipoCriptografia tipoCriptografia)
        {
            Criptografia.Criptografar(this.NomeSenha, tipoCriptografia);
        }

    }
}
