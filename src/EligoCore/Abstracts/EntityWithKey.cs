using EligoCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace EligoCore
{
    public abstract class EntityWithKey<TKey> : IEntityWithKey<TKey>
    {
        public TKey Id { get; }
    }
}
