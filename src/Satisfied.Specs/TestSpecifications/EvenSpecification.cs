using System;
using System.Linq.Expressions;

namespace Satisfied.Specs.TestSpecifications
{
    public class EvenSpecification : Specification<int>
    {
        public override Expression<Func<int, bool>> ToExpression()
        {
            return i => i % 2 == 0;
        }
    }
}