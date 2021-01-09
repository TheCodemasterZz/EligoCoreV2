using System;
using System.Collections.Generic;
using System.Text;

namespace EligoCore.Interfaces
{
    public interface IEntityFullAuditable<TKey>: 
        IEntityDeleteable<TKey>, 
        IEntityUpdateable<TKey>, 
        IEntityInsertable<TKey>,
        IEntityWithKey<TKey>
    {
    }
}
