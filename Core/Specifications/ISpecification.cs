using System;
using System.Linq.Expressions;

namespace Core.Specifications
{
    public interface ISpecification<T>
    {
        Expression<Func<T, bool>> Criteria {get;} // To use as a where clause
        List<Expression<Func<T, object>>> Includes {get;} // To use for the includes
    }
}