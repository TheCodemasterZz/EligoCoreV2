using EligoCore.Interfaces;
using System;
using Microsoft.Extensions.Configuration;

namespace EligoCore
{
    public sealed class EligoCoreDataSource : IDataSource
    {
        readonly string _connstring;

        public EligoCoreDataSource(string connectionString)
        {
            _connstring = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
        }

        public EligoCoreDataSource(IConfiguration configuration, string connectionStringName)
            : this(configuration.GetConnectionString(connectionStringName))
        { }

        public string GetConnectionString()
        {
            return _connstring;
        }
    }
}
