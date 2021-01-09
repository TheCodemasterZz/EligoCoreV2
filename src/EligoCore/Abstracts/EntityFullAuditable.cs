using EligoCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace EligoCore
{
    public class EntityFullAuditable<TKey> : IEntityFullAuditable<TKey>, IEntityWithKey<TKey>
    {
        public TKey Id { get; set; }
        public bool IsDeleted {get; set;}
        public TKey UserIdDeletedBy {get; set;}
        public DateTime DeletedAt {get; set;}
        public bool IsModified {get; set;}
        public TKey UserIdModifiedBy {get; set;}
        public DateTime ModifiedAt {get; set;}
        public TKey UserIdCreatedBy {get; set;}
        public DateTime CreatedAt {get; set;}

    }
}
