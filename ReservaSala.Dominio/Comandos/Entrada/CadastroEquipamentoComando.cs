using ReservaSala.Partilha;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservaSala.Dominio.Comandos.Entrada
{
    public class CadastroEquipamentoComando:IComando
    {
        public string Descricao { get;  set; }
        public int Quantidade { get;  set; }
        public string Observacao { get;  set; }
    }
}
