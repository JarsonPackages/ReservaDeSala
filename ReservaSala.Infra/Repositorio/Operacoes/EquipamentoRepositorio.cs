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
    public class EquipamentoRepositorio : IEquipamentoRepositorio
    {
        private readonly IConexao ConexaoRepositorio;

        public EquipamentoRepositorio(IConexao conexaoRepositorio)
        {
            ConexaoRepositorio = conexaoRepositorio;
        }

        public bool AtualizarEquipamento(Guid idEquipamentoAtual, Equipamento novoEquipamento)
        {
            string query = "UPDATE EQUIPAMENTO SET Descricao=@Descricao, Quantidade=@Quantidade, Observacao=@Observacao where id=@ID ";

            List<Parametro> parametros = new List<Parametro>();
            parametros.Add(new Parametro("@ID", idEquipamentoAtual));
            parametros.Add(new Parametro("@Descricao", novoEquipamento.Descricao));
            parametros.Add(new Parametro("@Quantidade", novoEquipamento.Quantidade));
            parametros.Add(new Parametro("@Observacao", novoEquipamento.Observacao));


            int insercaoUsuario = ConexaoRepositorio.Execulte(query, parametros);
            if (insercaoUsuario > 0)
            {
                return true;

            }
            else
            {
                return false;
            }
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

        public Equipamento ObterPorId(Guid id)
        {
            Equipamento equipamento = null;

            DataSet conjuntoDeDados = new DataSet();
            List<Parametro> parametros = new List<Parametro>();
            parametros.Add(new Parametro("@ID", id));
            conjuntoDeDados = ConexaoRepositorio.ObterTodos("SELECT * FROM Equipamento Where ID = @ID ;", null);

            foreach (DataRow linha in conjuntoDeDados.Tables[0].Rows)
            {

                equipamento = new Equipamento(linha["Descricao"].ToString(), (int)linha["Quantidade"], linha["Descricao"].ToString());
            }

            return equipamento;
        }

        public List<Equipamento> ObterTodos()
        {
            List<Equipamento> equipamentos = new List<Equipamento>();


            DataSet conjuntoDeDados = new DataSet();
            conjuntoDeDados = ConexaoRepositorio.ObterTodos("SELECT * FROM Equipamento ;", null);

            foreach (DataRow linha in conjuntoDeDados.Tables[0].Rows)
            {

                equipamentos.Add(new Equipamento(linha["Descricao"].ToString(), (int)linha["Quantidade"], linha["Descricao"].ToString()));
            }

            return equipamentos;
        }
    }
}
