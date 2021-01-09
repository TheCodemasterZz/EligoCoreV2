using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using EligoCore.Data.MSSQL;
using Microsoft.EntityFrameworkCore;
using EligoCore.Interfaces;
using EligoCore.Domain.Entities;
using EligoCore.Domain.Entities.References;

namespace EligoCore.Data.MSSQL
{
    public class MyDbContext : EligoCoreDbContext<MyDbContext>
    {
        public MyDbContext(IDataSource source)
            : base(source)
        {
        }

        public MyDbContext(DbContextOptions options)
            : base(options)
        { 
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var applyGenericMethod = typeof(ModelBuilder).GetMethod("ApplyConfiguration", BindingFlags.Instance | BindingFlags.Public);

            foreach (var type in Assembly.GetExecutingAssembly().GetTypes()
                .Where(c => c.IsClass && !c.IsAbstract && !c.ContainsGenericParameters))
            {
                foreach (var iface in type.GetInterfaces())
                {
                    if (iface.IsConstructedGenericType && iface.GetGenericTypeDefinition() == typeof(IEntityTypeConfiguration<>))
                    {
                        var applyConcreteMethod = applyGenericMethod.MakeGenericMethod(iface.GenericTypeArguments[0]);
                        applyConcreteMethod.Invoke(modelBuilder, new object[] { Activator.CreateInstance(type) });
                        break;
                    }
                }
            }
        }

        public DbSet<User> Users { get; set; }
        public DbSet<RefCity> RefCities { get; set; }
        public DbSet<RefCountry> RefCountries { get; set; }
    }
}
