using HrSystem.Core.Interfaces.Repositories;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace HrSystem.Data
{
    public class DapperContext : IDapperContext
    {
        private readonly IConfiguration _configuration;
        public DapperContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IDbConnection GetDbConnection()
        {
            string _connectionString = _configuration.GetConnectionString("DefaultConnection");
            return new SqlConnection(_connectionString);
        }

        public IDbConnection GetAuthServiceDbConnection()
        {
            string _connectionString = _configuration.GetConnectionString("AuthServiceConnection");
            return new SqlConnection(_connectionString);
        }
        public IDbConnection GetNGInterfaceDbConnection()
        {
            string _connectionString = _configuration.GetConnectionString("NGInterfacetConnection");
            return new SqlConnection(_connectionString);
        }



    }
}