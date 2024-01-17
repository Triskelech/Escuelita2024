using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Context
{
    public class TestDataBaseFixture
    {
        private string ConnectionString = GetConnectionStrings();

        private static readonly object _lock = new();
        private static bool _databaseInitialized;

        public TestDataBaseFixture()
        {
            lock (_lock)
            {
                if (!_databaseInitialized)
                {
                    using (var context = CreateContext())
                    {
                        context.Database.EnsureDeleted();
                        context.Database.EnsureCreated();
                    }

                    _databaseInitialized = true;
                }
            }
        }

        public EscuelitaContext CreateContext()
            => new EscuelitaContext(
                new DbContextOptionsBuilder<EscuelitaContext>()
                    .UseSqlServer(ConnectionString)
                    .Options);

        static string GetConnectionStrings()
        {
            var configuration = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json", false, false)
                   .AddEnvironmentVariables()
                   .Build();

            return configuration.GetValue<string>("ConnectionStrings:clean");
        }
    }
}
