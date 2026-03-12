using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ClientLab
{
    public class ConexaoBanco
    {
        private readonly string? connectionString = Environment.GetEnvironmentVariable("DB_CONEXAO");

        public MySqlConnection ObterConexao ()
        {
            return new MySqlConnection (connectionString);
        }

    }
}