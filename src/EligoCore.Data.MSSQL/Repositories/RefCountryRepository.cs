using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EligoCore.Interfaces;
using EligoCore.Domain;
using EligoCore.Domain.Entities.References;

namespace EligoCore.Data.MSSQL.Repositories
{
    public class RefCountryRepository : IRefCountryRepository
    {
        private readonly IUnitOfWork _unitOfWork;

        public RefCountryRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task CreateRefCountry(RefCountry refCountry, CancellationToken cancellationToken = default)
        {
            await _unitOfWork.AddAsync(refCountry, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_unitOfWork != null) _unitOfWork.Dispose();
            }
        }
    }
}