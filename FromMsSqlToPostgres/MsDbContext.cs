using Microsoft.EntityFrameworkCore;
using MsSqlToPostgress;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MsSqlToPostgress
{
    public class MsDbContext : AppDbContext
    {
        private const string ConnectionString = "Data Source=CMDB-80515;Initial Catalog=CoffeAppDb;Integrated Security=True;" +
            "Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);
            base.OnConfiguring(optionsBuilder);
        }
    }
}
