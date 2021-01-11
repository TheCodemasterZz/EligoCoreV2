using EligoCore.Domain.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace EligoCore.Domain
{
    public interface IMessageRepository : IDisposable
    {
        Task CreateMessage(Message message, CancellationToken cancellationToken = default);
    }

    public delegate IMessageRepository MessageRepositoryResolver(string database);
}
