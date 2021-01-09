using System;

namespace EligoCore.Interfaces
{
    public interface IEntityInsertable<TKey>
    {
        public TKey UserIdCreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
