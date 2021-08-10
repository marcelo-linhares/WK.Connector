using System;
using System.Data;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace WK.ConnectorAsync
{
    public class ConnectAsync : IDisposable
    {
        private String _connectionStringPropertyName = "DefaultConnection";

        public String ConnectionStringPropertyName
        { 
            get { return _connectionStringPropertyName; }
            set { _connectionStringPropertyName = value; }
        }

        public IDbConnection Connection { get; }

        public IDbTransaction Transaction { get; set; }
        
        public ConnectAsync(IConfiguration configuration)
        {
            Connection = new SqlConnection(configuration.GetConnectionString(this.ConnectionStringPropertyName));
        }

        public void Dispose() => Connection?.Dispose();

    }
}
