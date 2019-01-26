using ReservaSala.Partilha;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservaSala.Dominio.Comandos.Entrada
{
    public class LoginUsuarioComando:IComando
    {
        public string Email { get;  set; }
        public string Senha { get; set; }
    }
}
