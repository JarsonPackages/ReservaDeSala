using ReservaSala.Partilha;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservaSala.Dominio.Comandos.Entrada
{
    public class CadastroSalaComando:IComando
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public Guid IDBloco { get; private set; }
    }
}
