using ReservaSala.Dominio.ObjetoValor;
using ReservaSala.Infra.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservaSala.Dominio.Entidades
{
    public class LoginUsuario:Entidade
    {
        public LoginUsuario(Email email, Senha senha)
        {
            Email = email;
            Senha = senha;
        }

        public Email Email { get; private set; }
        public Senha Senha { get; private set; }
    }
}
