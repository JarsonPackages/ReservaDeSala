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
    public class BlocoRepositorio:IBlocoRepositorio
    {
        private readonly IConexao ConexaoRepositorio;

        public BlocoRepositorio(IConexao conexaoRepositorio)
        {
            ConexaoRepositorio = conexaoRepositorio;
        }
        public bool CadastraBloco(Bloco bloco)
        {
            List<Parametro> parametros = new List<Parametro>();
            parametros.Add(new Parametro("@ID", bloco.ID));
            parametros.Add(new Parametro("@DataCadastro", bloco.DataCadastro));
            parametros.Add(new Parametro("@Nome", bloco.Nome));
            parametros.Add(new Parametro("@Descricao", bloco.Descricao));
            
            string queryInsercao = UtilOperacao.GerarConsultaDeInserir("Bloco", parametros);
            int insercao = ConexaoRepositorio.Execulte(queryInsercao, parametros);
            if (insercao > 0)
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
