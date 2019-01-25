using FluentValidator;
using System.Text.RegularExpressions;


namespace ReservaSala.Dominio.ObjetoValor
{
    public class Email:Notifiable
    {
        public Email(string endereco)
        {
            Endereco = endereco;
            if (!ValidaEmail(Endereco))
            {
                AddNotification("Email", "O email digitado esta invalido");
            }
        }

        public string Endereco { get; private set; }

        public bool ValidaEmail(string email)
        {
            Regex rg = new Regex(@"^[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\.\-]?[a-zA-Z0-9]+)*)\.([A-Za-z]{2,})$");

            return rg.IsMatch(email);
           
        }
    }
}
