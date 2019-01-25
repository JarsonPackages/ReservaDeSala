using System.Collections.Generic;
using System.Text;

namespace ReservaSala.Infra.Util
{
    public static class UtilOperacao
    {
        public static  string GerarConsultaDeInserir(string Tabela, List<Parametro> parametros)
        {
            StringBuilder montaStringInsercao = new StringBuilder();
            montaStringInsercao.Append(string.Format("INSERT INTO {0} values(", Tabela));
            for (int i = 0; i < parametros.Count; i++)
            {
                montaStringInsercao.Append(parametros[i].Nome + " , ");
                if (i == parametros.Count - 1)
                {
                    montaStringInsercao.Append(parametros[i].Nome + " );");
                }
            }
            return montaStringInsercao.ToString();
        }
    }
}
