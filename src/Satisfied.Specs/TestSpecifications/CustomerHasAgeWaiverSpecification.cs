using System;
using System.Linq.Expressions;
using Satisfied.Specs.Models;

namespace Satisfied.Specs.TestSpecifications
{
    public class CustomerHasAgeWaiverSpecification : Specification<Customer>
    {
        public override Expression<Func<Customer, bool>> ToExpression()
        {
            return customer => customer.HasWaiver;
        }
    }
}