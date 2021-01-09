using System;

namespace EligoCore.Interfaces
{
    public interface IEntityUpdateable<TKey>
    {
        public bool IsModified { get; set; }
        public TKey UserIdModifiedBy { get; set; }
        public DateTime ModifiedAt { get; set; }
    }
}
