using System;

namespace EligoCore.Interfaces
{
    public interface IEntityDeleteable<TKey>
    {
        public bool IsDeleted { get; set; }
        public TKey UserIdDeletedBy { get; set; }
        public DateTime DeletedAt { get; set; }
    }
}
