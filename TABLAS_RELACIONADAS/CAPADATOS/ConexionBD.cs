using System.Data;
using System.Data.SqlClient;

namespace TABLAS_RELACIONADAS.CAPADATOS
{
    class ConexionBD
    {
        static private string _connectionString = "Server=DANTES;DataBase=TABLASRELACIONADAS;Integrated Security=true";
        private SqlConnection _conn = new SqlConnection(_connectionString);

        public SqlConnection OpenConnection()
        {
            if (_conn.State == ConnectionState.Closed)
                _conn.Open();
            return _conn;
        }

        public SqlConnection CloseConnection()
        {
            if (_conn.State == ConnectionState.Open)
                _conn.Close();
            return _conn;
        }
    }
}
