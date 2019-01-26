using ReservaSala.Infra.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservaSala.Dominio.Entidades
{
    public class Equipamento:Entidade
    {
        public Equipamento(string descricao, int quantidade, string observacao)
        {
            Descricao = descricao;
            Quantidade = quantidade;
            Observacao = observacao;
            if (string.IsNullOrEmpty(this.Descricao))
            {
                AddNotification("Descricao", "Preencha o campo descrição.");
            }
        }

        public string Descricao { get; private set; }
        public int Quantidade { get; private set; }
        public string Observacao { get; private set; }
    }
}
