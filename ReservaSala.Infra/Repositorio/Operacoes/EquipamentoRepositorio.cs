using ReservaSala.Dominio.Entidades;
using ReservaSala.Dominio.Repositorio;
using ReservaSala.Infra.DB;
using ReservaSala.Infra.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservaSala.Infra.Repositorio.Operacoes
{
    public class EquipamentoRepositorio : IEquipamentoRepositorio
    {
        private readonly IConexao ConexaoRepositorio;

        public EquipamentoRepositorio(IConexao conexaoRepositorio)
        {
            ConexaoRepositorio = conexaoRepositorio;
        }
        public bool CadastraEquipamento(Equipamento equipamento)
        {
            List<Parametro> parametros = new List<Parametro>();
             parametros.Add(new Parametro("@ID", equipamento.ID));
            parametros.Add(new Parametro("@DataCadastro", equipamento.DataCadastro));
            parametros.Add(new Parametro("@Descricao", equipamento.Descricao));
            parametros.Add(new Parametro("@Quantidade", equipamento.Quantidade));
            parametros.Add(new Parametro("@Observacao", equipamento.Observacao));
            
            string queryInsercao = UtilOperacao.GerarConsultaDeInserir("Equipamento", parametros);
            int insercaoUsuario = ConexaoRepositorio.Execulte(queryInsercao, parametros);
            if (insercaoUsuario > 0)
            {
                return true;

            }
            else
            {
                return false;
            }
        }
    }
}
