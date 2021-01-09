using EligoCore.Domain.Entities.References;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace EligoCore.Domain
{
    public interface IRefCountryRepository : IDisposable
    {
        Task CreateRefCountry(RefCountry refCountry, CancellationToken cancellationToken = default);
    }

    public delegate IRefCountryRepository RefCountryRepositoryResolver(string database);
}
