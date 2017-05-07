using System;
using System.Linq.Expressions;

namespace Satisfied.Specs.TestSpecifications
{
    public class StringContainsSpecification : Specification<string>
    {
        readonly string _partial;

        public StringContainsSpecification(string partial)
        {
            _partial = partial;
        }

        public override Expression<Func<string, bool>> ToExpression()
        {
            return name => name.Contains(_partial);
        }
    }
}