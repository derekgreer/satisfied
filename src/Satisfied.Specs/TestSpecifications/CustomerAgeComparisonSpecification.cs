using System;
using System.Linq.Expressions;
using Satisfied.Specs.Models;

namespace Satisfied.Specs.TestSpecifications
{
    public class CustomerAgeComparisonSpecification : Specification<Customer>
    {
        readonly ComparisonValue _comparisionValue;
        readonly int _value;

        public CustomerAgeComparisonSpecification(int value, ComparisonValue comparisionValue)
        {
            _value = value;
            _comparisionValue = comparisionValue;
        }

        public override Expression<Func<Customer, bool>> ToExpression()
        {
            switch (_comparisionValue)
            {
                case ComparisonValue.LessThan:
                    return customer => customer.Age < _value;
                case ComparisonValue.GreaterThan:
                    return customer => customer.Age > _value;
                case ComparisonValue.Equal:
                    return customer => customer.Age == _value;
            }

            return customer => false;
        }
    }
}