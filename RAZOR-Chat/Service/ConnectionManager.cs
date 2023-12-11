using Npgsql;
using RAZOR_Chat.Interface;
using System.Data;

namespace RAZOR_Chat.Service
{
    public class ConnectionManager: IConnectionmanager
    {
        IConfiguration _configuration;
        public ConnectionManager(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public IDbConnection  getNewConnection()
        {
            var connectionString = _configuration.GetSection("SqlConnectionString").Value;
            //var connectionString = "Server=localhost; Database=RAZOR; Port=5432; User Id=postgres; Password=mahi;";
            var connection = new NpgsqlConnection(connectionString);
            return connection;
        }
        
    }
}
