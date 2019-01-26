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
    public class SalaManipulador : IComandoManipulador<CadastroSalaComando>
    {
        private readonly ISalaRepositorio salaRepositorio;

        public SalaManipulador(ISalaRepositorio salaRepositorio)
        {
            this.salaRepositorio = salaRepositorio;
        }

        public IComandoResultado Manipular(CadastroSalaComando comando)
        {

            Sala sala = new Sala(comando.IDBloco, comando.Nome, comando.Descricao);
            if (!sala.IsValid())
            {
                return new OperacaoPadraoSaida( false, (List<Notification>) sala.Notifications);
            }
            else
            {
                bool cadastroSala = salaRepositorio.CadastraSala(sala);
                return new OperacaoPadraoSaida( cadastroSala);

            }
        }
    }
}
