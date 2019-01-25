
using ReservaSala.Infra.DB;
using ReservaSala.Infra.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;


namespace ReservaSala.Infra.BancoDriver
{
    class MSqlServer : IConexao
    {


        private IDbConnection ObterConexao;
        public MSqlServer(IDbConnection Conexao)
        {
            Conexao.ConnectionString = "";
           
            ObterConexao = Conexao;
        }


        public object ExeculteEscalar(string sql)
        {
            object escalar;
            try
            {

                using (var conexao = Conexao())
                {
                    SqlCommand cmd = new SqlCommand(sql, new SqlConnection(conexao.ConnectionString));
                    conexao.Open();
                    escalar = cmd.ExecuteScalar();
                    conexao.Close();
                }

                return escalar;
            }
            catch (Exception msg)
            {

                return -1;
            }
            finally
            {
                if (Conexao().State == ConnectionState.Open)
                {
                    Conexao().Close();
                }

            }
        }


        public int Execulte(string sql, List<Parametro> parametros)
        {

            int quantidadeDeLinhasAtingidas;
            try
            {

                using (var conexao = Conexao())
                {
                    SqlCommand cmd = new SqlCommand(sql, new SqlConnection(conexao.ConnectionString));
                    conexao.Open();
                    quantidadeDeLinhasAtingidas = cmd.ExecuteNonQuery();
                    conexao.Close();
                }

                return quantidadeDeLinhasAtingidas;
            }
            catch (Exception msg)
            {

                return -1;
            }
            finally
            {
                if (Conexao().State == ConnectionState.Open)
                {
                    Conexao().Close();
                }

            }
        }

        public IDbConnection Conexao()
        {
            return this.ObterConexao;
        }

        public DataSet ObterTodos(string sql)
        {
            try
            {
                using (var conexao = Conexao())
                {
                    SqlDataAdapter DA = new SqlDataAdapter(sql, new SqlConnection(conexao.ConnectionString));
                    DataSet DS = new DataSet();
                    conexao.Open();
                    DA.Fill(DS);
                    conexao.Close();
                    return DS;
                }



            }
            catch (Exception msg)
            {

                return null;
            }
            finally
            {
                if (Conexao().State == ConnectionState.Open)
                {
                    Conexao().Close();
                }

            }
        }

    }
}
