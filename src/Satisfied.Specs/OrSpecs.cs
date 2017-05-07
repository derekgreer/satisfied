using Machine.Specifications;
using Satisfied.Specs.TestSpecifications;

namespace Satisfied.Specs
{
    public class OrSpecs
    {
        [Subject("Or Specification")]
        public class when_satisfying_one_unsatisfied_specification_or_one_satisfied_specification
        {
            static ISpecification<string> _nameContainsJaneOrJohnSpecification;
            static bool _results;

            Establish context = () =>
            {
                ISpecification<string> nameContainsJaneSpecification = new StringContainsSpecification("John");
                ISpecification<string> nameContainsDoeSpecification = new StringContainsSpecification("Doe");
                _nameContainsJaneOrJohnSpecification = nameContainsJaneSpecification.Or(nameContainsDoeSpecification);
            };

            Because of = () => _results = _nameContainsJaneOrJohnSpecification.IsSatisfiedBy("Jane E. Doe");

            It should_be_satisfied = () => _results.ShouldBeTrue();
        }

        [Subject("Or Specification")]
        public class when_satisfying_one_satisfied_specification_or_one_unsatisfied_specification
        {
            static ISpecification<string> _nameContainsJaneOrJohnSpecification;
            static bool _results;

            Establish context = () =>
            {
                ISpecification<string> nameContainsJaneSpecification = new StringContainsSpecification("Jane");
                ISpecification<string> nameContainsDoeSpecification = new StringContainsSpecification("Smith");
                _nameContainsJaneOrJohnSpecification = nameContainsJaneSpecification.Or(nameContainsDoeSpecification);
            };

            Because of = () => _results = _nameContainsJaneOrJohnSpecification.IsSatisfiedBy("Jane E. Doe");

            It should_be_satisfied = () => _results.ShouldBeTrue();
        }

        [Subject("Or Specification")]
        public class when_satisfying_one_unsatisfied_specification_or_another_unsatisfied_specification
        {
            static ISpecification<string> _nameContainsJaneOrJohnSpecification;
            static bool _results;

            Establish context = () =>
            {
                ISpecification<string> nameContainsJaneSpecification = new StringContainsSpecification("Sam");
                ISpecification<string> nameContainsDoeSpecification = new StringContainsSpecification("Houston");
                _nameContainsJaneOrJohnSpecification = nameContainsJaneSpecification.Or(nameContainsDoeSpecification);
            };

            Because of = () => _results = _nameContainsJaneOrJohnSpecification.IsSatisfiedBy("Jane E. Doe");

            It should_not_be_satisfied = () => _results.ShouldBeFalse();
        }
    }
}