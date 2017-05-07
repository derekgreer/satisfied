using System.Linq.Expressions;

namespace Satisfied.Visitors
{
    class ParameterReplacmentExpressionVisitor : ExpressionVisitor
    {
        readonly Expression _newValue;
        readonly Expression _oldValue;

        public ParameterReplacmentExpressionVisitor(Expression oldValue, Expression newValue)
        {
            _oldValue = oldValue;
            _newValue = newValue;
        }

        public override Expression Visit(Expression node)
        {
            return node == _oldValue ? _newValue : base.Visit(node);
        }
    }
}