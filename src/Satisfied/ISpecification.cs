using System;
using System.Linq.Expressions;

namespace Satisfied
{
    public interface ISpecification<T>
    {
        bool IsSatisfiedBy(T entity);
        ISpecification<T> And(ISpecification<T> specification);
        ISpecification<T> Or(ISpecification<T> specification);
        ISpecification<T> Not();
        Expression<Func<T, bool>> ToExpression();
    }
}