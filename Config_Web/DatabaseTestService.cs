using System;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;

namespace Config_Web
{
    public static class DatabaseTestService
    {
        /// <summary>
        /// Tenta abrir e fechar a conexao. Lanca excecao em caso de falha.
        /// Suporta OleDb (Oracle, Access, etc.) e SqlClient (SQL Server).
        /// </summary>
        public static void Test(ConnectionStringEntry entry)
        {
            if (string.IsNullOrEmpty(entry.ConnectionString))
                throw new ArgumentException("A string de conexao esta vazia.");

            string provider = (entry.ProviderName ?? string.Empty).ToLowerInvariant();
            IDbConnection connection;

            if (provider.Contains("sqlclient"))
                connection = new SqlConnection(entry.ConnectionString);
            else
                connection = new OleDbConnection(entry.ConnectionString);

            using (connection)
            {
                connection.Open();
            }
        }
    }
}
