using FluentValidator;
using ReservaSala.Partilha;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservaSala.Dominio.Comandos.Saida
{
    public class OperacaoPadraoSaida:IComandoResultado
    {
        public OperacaoPadraoSaida(bool entidadeCadastrado)
        {
            EntidadeCadastrado = entidadeCadastrado;
        }

        public OperacaoPadraoSaida(bool entidadeCadastrado, List<Notification> notificacoes)
        {
            EntidadeCadastrado = entidadeCadastrado;
            Notificacoes = notificacoes;
        }
     

        public bool EntidadeCadastrado { get; private set; }
        public List<Notification> Notificacoes { get; private set; }
    }
}
