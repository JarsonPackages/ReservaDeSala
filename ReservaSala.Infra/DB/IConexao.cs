using ReservaSala.Infra.Util;
using System.Collections.Generic;
using System.Data;

namespace ReservaSala.Infra.DB
{
    public interface IConexao
    {
        IDbConnection Conexao();
        DataSet ObterTodos(string sql,List<Parametro> parametros);
        int Execulte(string sql, List<Parametro> parametros);
        object ExeculteEscalar(string sql);
    }
}
