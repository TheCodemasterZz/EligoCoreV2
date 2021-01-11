using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EligoCore.Interfaces;
using EligoCore.Domain;
using EligoCore.Domain.Entities;

namespace EligoCore.Data.MSSQL.Repositories
{
    public class MessageRepository : IMessageRepository
    {
        private readonly IUnitOfWork _unitOfWork;

        public MessageRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task CreateMessage(Message message, CancellationToken cancellationToken = default)
        {
            await _unitOfWork.AddAsync(message, cancellationToken);
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