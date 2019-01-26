using FluentValidator;
using ReservaSala.Dominio.Comandos.Entrada;
using ReservaSala.Dominio.Comandos.Saida;
using ReservaSala.Dominio.Entidades;
using ReservaSala.Dominio.Repositorio;
using ReservaSala.Partilha;
using System.Collections.Generic;

namespace ReservaSala.Dominio.Comandos.Manipular
{
    public class BlocoManipulador : IComandoManipulador<CadastroBlocoComando>
    {
        private readonly IBlocoRepositorio blocoRepositorio;

        public BlocoManipulador(IBlocoRepositorio blocoRepositorio)
        {
            this.blocoRepositorio = blocoRepositorio;
        }

        public IComandoResultado Manipular(CadastroBlocoComando comando)
        {
            Bloco bloco = new Bloco(comando.Nome, comando.Descricao);
            if (!bloco.IsValid())
            {
                return new OperacaoPadraoSaida(false, (List<Notification>)bloco.Notifications);
            }
            else
            {
                bool blocoCadastrado =  blocoRepositorio.CadastraBloco(bloco);
                return new OperacaoPadraoSaida(blocoCadastrado);
            }
        }
    }
}
