using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using EligoCore.Data.MSSQL;
using Microsoft.EntityFrameworkCore;
using EligoCore.Interfaces;
using EligoCore.Domain.Entities;

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
        }

        public DbSet<Message> Messages { get; set; }
    }
}
