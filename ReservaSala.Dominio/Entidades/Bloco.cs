using ReservaSala.Infra.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservaSala.Dominio.Entidades
{
    public class Bloco : Entidade
    {
        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public Bloco(string Nome, string descricao)
        {
          
            this.Descricao = descricao;
          

            if (string.IsNullOrEmpty(this.Nome))
            {
                AddNotification("Nome", "Preencha o campo descrição!");
            }
        }
        public Bloco()
        {

        }
    }
}
