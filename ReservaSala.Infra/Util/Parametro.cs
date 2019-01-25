using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservaSala.Infra.Util
{
    public class Parametro
    {
        public Parametro(string nome, object valor)
        {
            Nome = nome;
            Valor = valor;
        }

        public string Nome { get; private set; }
        public object Valor { get; private set; }
    }
}
