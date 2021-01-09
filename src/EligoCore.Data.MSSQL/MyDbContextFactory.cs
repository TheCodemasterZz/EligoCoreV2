using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace EligoCore.Data.MSSQL
{
    class MyDbContextFactory : IDesignTimeDbContextFactory<MyDbContext>
    {
        public MyDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
              .SetBasePath(Directory.GetCurrentDirectory()) // TODO: Uygulama Adresi ile değiştirilecek
              .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
              //.AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json", optional: false, reloadOnChange: true)
              .Build();

            var builder = new DbContextOptionsBuilder<MyDbContext>();

            var connectionString = configuration.GetConnectionString("MyDb");

            builder.UseSqlServer(connectionString);

            return new MyDbContext(builder.Options);
        }
    }
}
