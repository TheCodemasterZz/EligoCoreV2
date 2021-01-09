using EligoCore.Domain;
using EligoCore.Service.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EligoCore.Service
{
    public class RefCountryService : IRefCountryService
    {
        private readonly RefCountryRepositoryResolver _refCountryRepository;
        public RefCountryService(RefCountryRepositoryResolver refCountryRepository)
        {
            _refCountryRepository = refCountryRepository ?? throw new ArgumentNullException(nameof(refCountryRepository));
        }

        public Task CreateRefCountryAsync(RefCountryDto dto, CancellationToken cancellationToken = default)
        {
            return null;
        }
    }
}
