using Machine.Specifications;
using Satisfied.Specs.Models;
using Satisfied.Specs.TestSpecifications;

namespace Satisfied.Specs
{
    public class CompositeSpecificationSpecs
    {
        [Subject("Composite Specifications")]
        public class when_chaining_satisfied_specifications
        {
            static ISpecification<Customer> _specification;
            static bool _results;

            Establish context = () =>
            {
                ISpecification<Customer> nameContainsJohn = new CustomerNameContainsSpecification("John");
                ISpecification<Customer> nameContainsSally = new CustomerNameContainsSpecification("Sally");
                ISpecification<Customer> ageIsGreaterThan18 = new CustomerAgeComparisonSpecification(18, ComparisonValue.GreaterThan);
                ISpecification<Customer> isActive = new CustomerIsActiveSpecification();
                ISpecification<Customer> hasWaiver = new CustomerHasAgeWaiverSpecification();

                _specification = nameContainsJohn.Or(nameContainsSally).And(ageIsGreaterThan18.Or(hasWaiver)).And(isActive.Not());
            };

            Because of = () => _results = _specification.IsSatisfiedBy(new Customer {Name = "John Doe", Age = 17, IsActive = false, HasWaiver = true});

            It should_be_satisfied = () => _results.ShouldBeTrue();
        }

        [Subject("Composite Specifications")]
        public class when_chaining_with_an_unsatisfied_specification
        {
            static ISpecification<Customer> _specification;
            static bool _results;

            Establish context = () =>
            {
                ISpecification<Customer> nameContainsJohn = new CustomerNameContainsSpecification("John");
                ISpecification<Customer> nameContainsSally = new CustomerNameContainsSpecification("Sally");
                ISpecification<Customer> ageIsGreaterThan18 = new CustomerAgeComparisonSpecification(18, ComparisonValue.GreaterThan);
                ISpecification<Customer> isActive = new CustomerIsActiveSpecification();
                ISpecification<Customer> hasWaiver = new CustomerHasAgeWaiverSpecification();

                _specification = nameContainsJohn.Or(nameContainsSally).And(ageIsGreaterThan18.Or(hasWaiver)).And(isActive.Not());
            };

            Because of = () => _results = _specification.IsSatisfiedBy(new Customer { Name = "John Doe", Age = 17, IsActive = false, HasWaiver = false });

            It should_not_be_satisfied = () => _results.ShouldBeFalse();
        }
    }
}