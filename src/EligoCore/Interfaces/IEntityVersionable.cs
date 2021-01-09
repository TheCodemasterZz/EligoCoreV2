using System;

namespace EligoCore.Interfaces
{
    public interface IEntityVersionable<TKey>
    {
        public bool IsMasterRecord { get; set; }
        public DateTime VersionedAt { get; set; }
        public int VersionNumber { get; set; }
        public TKey MasterRecordID { get; set; }
    }
}
