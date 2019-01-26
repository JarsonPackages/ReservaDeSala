using ReservaSala.Dominio.Entidades;
using ReservaSala.Dominio.Enumerador;
using ReservaSala.Dominio.ObjetoValor;
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
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly IConexao ConexaoRepositorio;

        public UsuarioRepositorio(IConexao conexaoRepositorio)
        {
            ConexaoRepositorio = conexaoRepositorio;
        }

        public bool AlterarSenha(Guid usuario,Senha novaSenha)
        {
             List<Parametro> parametros = new List<Parametro>();
            parametros.Add(new Parametro("@Senha", novaSenha.NomeSenha));
            parametros.Add(new Parametro("@ID", usuario));
            string query = "UPDATE USUARIO SET SENHA=@Senha WHERE ID = @ID;";
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

        public bool CadastraUsuario(Usuario usuario)
        {
            List<Parametro> parametros = new List<Parametro>();
            parametros.Add(new Parametro("@Nome", usuario.Nome));
            parametros.Add(new Parametro("@Endereco", usuario.Email.Endereco));
            parametros.Add(new Parametro("@Cpf", usuario.Cpf));
            parametros.Add(new Parametro("@Senha", usuario.Senha.NomeSenha));
            parametros.Add(new Parametro("@TipoDeUsuario", usuario.TipoDeUsuario));
            parametros.Add(new Parametro("@ID", usuario.ID));
            parametros.Add(new Parametro("@DataCadastro", usuario.DataCadastro));

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

        public Usuario LoginUsuario(LoginUsuario usuario)
        {
            Usuario Usuario = default(Usuario);
            List<Parametro> parametros = new List<Parametro>();
            parametros.Add(new Parametro("@Nome", usuario.Email));
            parametros.Add(new Parametro("@Senha", usuario.Senha));

            DataSet conjuntoDeDados = new DataSet();
            conjuntoDeDados = ConexaoRepositorio.ObterTodos("SELECT * FROM USUARIO WHERE EMAIL = @EMAIL AND SENHA = @SENHA ;", parametros);
            foreach (DataRow linha in conjuntoDeDados.Tables[0].Rows)
            {
                Email email = new Email(linha["Email"].ToString());
                Senha senha = new Senha(linha["Senha"].ToString());
                Documento documento = new Documento(linha["Cpf"].ToString());

                Usuario = new Usuario(
                    linha["Nome"].ToString(), senha, (TipoUsuario)Enum.Parse(typeof(TipoUsuario),
                    linha["TipoUsuario"].ToString()), documento, email);

            }
            return Usuario;
        }

        public Usuario ObterPorId(Guid usuario)
        {
             Usuario Usuario = null;
            List<Parametro> parametros = new List<Parametro>();
            parametros.Add(new Parametro("@ID", usuario));
           
            DataSet conjuntoDeDados = new DataSet();
            conjuntoDeDados = ConexaoRepositorio.ObterTodos("SELECT * FROM USUARIO WHERE ID=@ID;", parametros);
            foreach (DataRow linha in conjuntoDeDados.Tables[0].Rows)
            {
                Email email = new Email(linha["Email"].ToString());
                Senha senha = new Senha(linha["Senha"].ToString());
                Documento documento = new Documento(linha["Cpf"].ToString());

                Usuario = new Usuario(
                    linha["Nome"].ToString(), senha, (TipoUsuario)Enum.Parse(typeof(TipoUsuario),
                    linha["TipoUsuario"].ToString()), documento, email);

            }
            return Usuario;
        }
    }
}
