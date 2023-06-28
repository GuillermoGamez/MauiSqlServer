using System;
using Microsoft.Data.SqlClient;

namespace MauiSqlServer.Common
{
	public class Connection
	{
		public string Server { get; set; }
		public string Database { get; set; }
		public string User { get; set; }
		public string Password { get; set; }

        public string GetConnection()
        {
            return GetConnection(6);
        }

        private string GetConnection(int timeout)
        {
            var bldr = new SqlConnectionStringBuilder
            {
                InitialCatalog = this.Database,
                DataSource = this.Server,
                ConnectTimeout = timeout,
                MaxPoolSize = 100,
                MultipleActiveResultSets = true,
                UserID = this.User,
                Password = this.Password,
                TrustServerCertificate = true
            };

            return bldr.ConnectionString;
        }
    }
}

