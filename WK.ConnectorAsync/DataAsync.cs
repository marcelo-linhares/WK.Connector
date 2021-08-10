using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Dapper;

namespace WK.ConnectorAsync
{
    public class DataAsync : IDisposable
    {

        private ConnectAsync _dbConnection;

        public DataAsync(ConnectAsync dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public async Task<Object> GetDataByPK(String Command)
        {
            Object obj = new();

            using var conn = _dbConnection.Connection;
            try
            {
                conn.Open();
                obj = await conn.ExecuteScalarAsync<Object>(Command);
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("Failure detected in [{0}] \r\nDetail: {1}", this.ToString(), ex.Message));
            }
            finally
            {
                conn.Close();
            }


            return obj;
            
        }
    }
}
