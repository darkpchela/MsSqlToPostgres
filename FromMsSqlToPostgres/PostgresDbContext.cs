using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MsSqlToPostgress;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MsSqlToPostgress
{
    public class PostgresDbContext : AppDbContext
    {
        private readonly IConfiguration _configuration;

        public PostgresDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = new NpgsqlConnectionStringBuilder()
            {
                Username = _configuration["Postgres:Username"],
                Password = _configuration["Postgres:Password"],
                Host = _configuration["Postgres:Host"],
                Database = _configuration["Postgres:Database"],
                Port = int.Parse(_configuration["Postgres:Port"]),
                TrustServerCertificate = true
            }.ToString();
            optionsBuilder.UseNpgsql(connectionString);
            base.OnConfiguring(optionsBuilder);
        }
    }
}
