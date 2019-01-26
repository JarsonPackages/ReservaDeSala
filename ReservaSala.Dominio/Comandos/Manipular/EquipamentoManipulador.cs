using FluentValidator;
using ReservaSala.Dominio.Comandos.Entrada;
using ReservaSala.Dominio.Comandos.Saida;
using ReservaSala.Dominio.Entidades;
using ReservaSala.Dominio.Repositorio;
using ReservaSala.Partilha;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservaSala.Dominio.Comandos.Manipular
{
    public class EquipamentoManipulador : IComandoManipulador<CadastroEquipamentoComando>
    {
        private readonly IEquipamentoRepositorio equipamentoRepositorio;

        public EquipamentoManipulador(IEquipamentoRepositorio equipamentoRepositorio)
        {
            this.equipamentoRepositorio = equipamentoRepositorio;
        }

        public IComandoResultado Manipular(CadastroEquipamentoComando comando)
        {
            Equipamento equipamento = new Equipamento(comando.Descricao, comando.Quantidade, comando.Observacao);

            if (!equipamento.IsValid())
            {
                return new OperacaoPadraoSaida(false, (List<Notification>)equipamento.Notifications);
                    
            }
            bool equipamentoCadastrado = equipamentoRepositorio.CadastraEquipamento(equipamento);
             return new OperacaoPadraoSaida(equipamentoCadastrado);
        }
    }
}
