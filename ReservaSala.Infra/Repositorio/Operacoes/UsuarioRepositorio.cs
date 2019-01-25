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
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly IConexao ConexaoRepositorio;
        public bool CadastraUsuario(Usuario usuario)
        {
            List<Parametro> parametros = new List<Parametro>();
            parametros.Add(new Parametro("@Nome", usuario.Nome));
            parametros.Add(new Parametro("@Endereco", usuario.Email.Endereco));
            parametros.Add(new Parametro("@Cpf", usuario.Cpf));
            parametros.Add(new Parametro("@Senha", usuario.Senha.NomeSenha));
            parametros.Add(new Parametro("@TipoDeUsuario", usuario.TipoDeUsuario));
            parametros.Add(new Parametro("@ID", usuario.ID));

            string queryInsercao = UtilOperacao.GerarConsultaDeInserir("Usuario", parametros);
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
