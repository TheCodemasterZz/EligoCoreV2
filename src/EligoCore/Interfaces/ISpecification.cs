using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace EligoCore.Interfaces
{
    public interface ISpecification<TEntity>
        where TEntity : class, IAggregation

    {
        Expression<Func<TEntity, bool>> Criteria { get; }

        List<Expression<Func<TEntity, object>>> Includes { get; }

        List<string> IncludeStrings { get; }
    }
}
