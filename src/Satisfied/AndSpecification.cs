using System;
using System.Linq.Expressions;
using Satisfied.Visitors;

namespace Satisfied
{
    public class AndSpecification<T> : Specification<T>
    {
        readonly ISpecification<T> _left;
        readonly ISpecification<T> _right;

        public AndSpecification(ISpecification<T> left, ISpecification<T> right)
        {
            _right = right;
            _left = left;
        }

        public override Expression<Func<T, bool>> ToExpression()
        {
            var parameter = Expression.Parameter(typeof(T));
            var leftExpression = _left.ToExpression();
            var rightExpression = _right.ToExpression();
            var leftVisitor = new ParameterReplacmentExpressionVisitor(leftExpression.Parameters[0], parameter);
            var rightVisitor = new ParameterReplacmentExpressionVisitor(rightExpression.Parameters[0], parameter);
            var visitedLeftExpression = leftVisitor.Visit(leftExpression.Body);
            var visitedRightExpression = rightVisitor.Visit(rightExpression.Body);
            var andExpression = Expression.AndAlso(visitedLeftExpression, visitedRightExpression);
            return Expression.Lambda<Func<T, bool>>(andExpression, parameter);
        }
    }
}