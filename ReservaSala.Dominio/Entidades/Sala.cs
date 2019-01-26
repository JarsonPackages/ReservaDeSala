using ReservaSala.Infra.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservaSala.Dominio.Entidades
{
    public class Sala : Entidade
    {
        public Sala(Guid bloco, string nome, string observacao)
        {
            IDBloco = bloco;
            Nome = nome;
            Observacao = observacao;
        
            if (string.IsNullOrEmpty(this.Nome))
            {
                AddNotification("Nome", "Preencha o campo descrição!");
            }
        }

      
        public Guid IDBloco { get; private set; }
        public string Nome { get; private set; }
        public bool ContemDataShow { get; private set; }
        public bool ContemSom { get; private set; }
        public int QuantidadeDeLugares { get; private set; }
        public string Observacao { get; private set; }
    }
}
