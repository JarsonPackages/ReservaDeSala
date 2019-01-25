using FluentValidator;
using ReservaSala.Partilha;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservaSala.Dominio.Comandos.Saida
{
    public class CadastroUsuarioSaida:IComandoResultado
    {
        public bool UsuarioCadastrado { get;  set; }
        public List<Notification> Notificacoes { get;  set; }
    }
}
