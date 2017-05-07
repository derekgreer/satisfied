using System;
using System.Linq.Expressions;
using Satisfied.Specs.Models;

namespace Satisfied.Specs.TestSpecifications
{
    public class CustomerNameContainsSpecification : Specification<Customer>
    {
        readonly string _partial;

        public CustomerNameContainsSpecification(string partial)
        {
            _partial = partial;
        }

        public override Expression<Func<Customer, bool>> ToExpression()
        {
            return customer => customer.Name.Contains(_partial);
        }
    }
}