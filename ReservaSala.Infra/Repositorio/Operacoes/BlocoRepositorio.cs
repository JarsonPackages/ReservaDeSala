using ReservaSala.Dominio.Entidades;
using ReservaSala.Dominio.Repositorio;
using ReservaSala.Infra.DB;
using ReservaSala.Infra.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservaSala.Infra.Repositorio.Operacoes
{
    public class BlocoRepositorio : IBlocoRepositorio
    {
        private readonly IConexao ConexaoRepositorio;

        public BlocoRepositorio(IConexao conexaoRepositorio)
        {
            ConexaoRepositorio = conexaoRepositorio;
        }

        public bool AtualizarBloco(Guid idBlocoAtual, Bloco novoBloco)
        {
            string atualizar = "UPDATE BLOCO SET NOME=@Nome,Descricao=@Descricao where id=@ID";
             List<Parametro> parametros = new List<Parametro>();
            parametros.Add(new Parametro("@ID", idBlocoAtual));
            parametros.Add(new Parametro("@Nome", novoBloco.Nome));
            parametros.Add(new Parametro("@Descricao", novoBloco.Descricao));
            int insercao = ConexaoRepositorio.Execulte(atualizar, parametros);
            if (insercao > 0)
            {
                return true;

            }
            else
            {
                return false;
            }
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

        public Bloco ObterPorId(Guid id)
        {
            Bloco bloco = null;
            List<Parametro> parametros = new List<Parametro>();
            parametros.Add(new Parametro("@ID", id));
            DataSet conjuntoDeDados = new DataSet();
            conjuntoDeDados = ConexaoRepositorio.ObterTodos("SELECT * FROM Bloco WHERE ID=@ID ;", parametros);
            foreach (DataRow linha in conjuntoDeDados.Tables[0].Rows)
            {
                 bloco = new Bloco(linha["Nome"].ToString(), linha["Descricao"].ToString());
                break;
            }
            return bloco;
        }

        public List<Bloco> ObterTodos()
        {
            List<Bloco> blocos = new List<Bloco>();
            DataSet conjuntoDeDados = new DataSet();
            conjuntoDeDados = ConexaoRepositorio.ObterTodos("SELECT * FROM Bloco ;", null);

            foreach (DataRow linha in conjuntoDeDados.Tables[0].Rows)
            {
                
                blocos.Add(new Bloco(linha["Nome"].ToString(), linha["Descricao"].ToString()));
            }

            return blocos;
        }
    }
}
