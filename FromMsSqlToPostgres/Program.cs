using CoffeApp.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;
using MsSqlToPostgress;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MsSqlToPostgress
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var configurationBuilder = new ConfigurationBuilder();
            configurationBuilder.AddUserSecrets<Program>();

            using var transferContext = new TransferContext(new MsDbContext(), new PostgresDbContext(configurationBuilder.Build()));
            transferContext.Transfer();

            Console.WriteLine("OK");
        }
    }
}
