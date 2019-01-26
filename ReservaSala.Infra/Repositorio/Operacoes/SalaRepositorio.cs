using ReservaSala.Dominio.Entidades;
using ReservaSala.Dominio.Repositorio;
using ReservaSala.Infra.DB;
using ReservaSala.Infra.Util;
using System;
using System.Collections.Generic;
using System.Data;

namespace ReservaSala.Infra.Repositorio.Operacoes
{
    public class SalaRepositorio : ISalaRepositorio
    {
        private readonly IConexao ConexaoRepositorio;

        public SalaRepositorio(IConexao conexaoRepositorio)
        {
            ConexaoRepositorio = conexaoRepositorio;
        }

        public bool AtualizarSala(Guid idSalaAtual, Sala novoSala)
        {
            string query = "UPDATE Sala SET Nome=@Nome,ContemDataShow=@ContemDataShow,ContemSom=@ContemSom,IDBloco=@IDBloco,Observacao=@Observacao,QuantidadeDeLugares=@QuantidadeDeLugares where ID = @ID;";
             List<Parametro> parametros = new List<Parametro>();
            parametros.Add(new Parametro("@ID", novoSala.ID));
            parametros.Add(new Parametro("@Nome", novoSala.Nome));
            parametros.Add(new Parametro("@ContemDataShow", novoSala.ContemDataShow));
            parametros.Add(new Parametro("@ContemSom", novoSala.ContemSom));
            parametros.Add(new Parametro("@IDBloco", novoSala.IDBloco));
            parametros.Add(new Parametro("@Observacao", novoSala.Observacao));
            parametros.Add(new Parametro("@QuantidadeDeLugares", novoSala.QuantidadeDeLugares));
        }

        public bool CadastraSala(Sala sala)
        {
            List<Parametro> parametros = new List<Parametro>();
            parametros.Add(new Parametro("@ID", sala.ID));
            parametros.Add(new Parametro("@DataCadastro", sala.DataCadastro));
            parametros.Add(new Parametro("@Nome", sala.Nome));
            parametros.Add(new Parametro("@ContemDataShow", sala.ContemDataShow));
            parametros.Add(new Parametro("@ContemSom", sala.ContemSom));
            parametros.Add(new Parametro("@IDBloco", sala.IDBloco));
            parametros.Add(new Parametro("@Observacao", sala.Observacao));
            parametros.Add(new Parametro("@QuantidadeDeLugares", sala.QuantidadeDeLugares));
            
            string query = UtilOperacao.GerarConsultaDeInserir("Sala", parametros);
            int insercao = ConexaoRepositorio.Execulte(query, parametros);
            if (insercao > 0)
            {
                return true;

            }
            else
            {
                return false;
            }
        }

        public Sala ObterPorId(Guid id)
        {
             Sala sala = null;
            List<Parametro> parametros = new List<Parametro>();
            parametros.Add(new Parametro("@ID", id));
           
            DataSet conjuntoDeDados = new DataSet();
            conjuntoDeDados = ConexaoRepositorio.ObterTodos("SELECT * FROM Sala WHERE ID=@ID;", parametros);
            foreach (DataRow linha in conjuntoDeDados.Tables[0].Rows)
            {
                sala = new Sala(Guid.Parse(linha["IDBloco"].ToString()),linha["Nome"].ToString(),(bool)linha["ContemDataShow"],(bool)linha["ContemSom"],(int)linha["QuantidadeDeLugares"],linha["Observacao"].ToString());
            }
            return sala;
        }

        public List<Sala> ObterTodos()
        {
            List<Sala> salas = new List<Sala>();

            DataSet conjuntoDeDados = new DataSet();
            conjuntoDeDados = ConexaoRepositorio.ObterTodos("SELECT * FROM Sala ;", null);

            foreach (DataRow linha in conjuntoDeDados.Tables[0].Rows)
            {
                salas.Add(new Sala(Guid.Parse(linha["IDBloco"].ToString()),linha["Nome"].ToString(),(bool)linha["ContemDataShow"],(bool)linha["ContemSom"],(int)linha["QuantidadeDeLugares"],linha["Observacao"].ToString()));
            }

            return salas;
        }
    }
}
