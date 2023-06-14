using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Npgsql;
using System.Data.SqlClient;

namespace projeto.DAL
{
    internal class AcessoPostgresql
    {
        static string serverName = "127.0.0.1";                          //localhost
        static string port = "5432";                                     //porta default
        static string userName = "postgres";                             //nome do administrador
        static string password = "3457";                            //senha do administrador
        static string databaseName = "sistlabs";                         //nome do banco de dados
        string connString = null;

        private NpgsqlConnection conn;
        private string sql;
        private NpgsqlCommand cmd;
        private DataTable dt;
        private NpgsqlDataAdapter da;
        private NpgsqlCommandBuilder cb;
        private DataTable data;

        public void Conectar()
        {
            if (conn != null)
            {
                conn.Close();
            }

            string connStr = String.Format("server={0}; port={1}; user id={2}; password={3}; database={4}; pooling=false", serverName, port, userName, password, databaseName);

            try
            {
                conn = new NpgsqlConnection(connStr);
                conn.Open();
            }
            catch (NpgsqlException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public NpgsqlCommand ExecutarComandoSQL(string comandoSql)
        { 
            NpgsqlCommand comando = new NpgsqlCommand(comandoSql, conn);
            comando.ExecuteNonQuery();
            return comando;
        }

        public NpgsqlDataReader retDataReader(string sql)
        {
            NpgsqlCommand comando = new NpgsqlCommand(sql, conn);
            NpgsqlDataReader dr = comando.ExecuteReader();
            return dr;
        }
    }
}
