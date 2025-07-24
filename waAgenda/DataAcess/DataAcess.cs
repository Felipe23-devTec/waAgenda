
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
namespace waAgenda
{
    public class DataAcess
    {
        private string StringConexao = "Data Source=FELIPE\\SQLEXPRESS;Database=DbAplicacaoClientes;Integrated Security=True;TrustServerCertificate=True";

        public DataSet Consultar(string NomeProcedure, List<SqlParameter> parametros)
        {
            SqlCommand comando = new SqlCommand();
            SqlConnection conexao = new SqlConnection(StringConexao);
            conexao.Open();

            DataSet ds = new DataSet();

            return ds;
        }
    }
}