using Machine.Specifications;
using Satisfied.Specs.TestSpecifications;

namespace Satisfied.Specs
{
    public class AndSpecs
    {
        [Subject("And Specification")]
        public class when_satisfying_two_satisfied_specificatons
        {
            static ISpecification<string> _nameContainsJaneAndDoeSpecification;
            static bool _results;

            Establish context = () =>
            {
                ISpecification<string> nameContainsJaneSpecification = new StringContainsSpecification("Jane");
                ISpecification<string> nameContainsDoeSpecification = new StringContainsSpecification("Doe");
                _nameContainsJaneAndDoeSpecification = nameContainsJaneSpecification.And(nameContainsDoeSpecification);
            };

            Because of = () => _results = _nameContainsJaneAndDoeSpecification.IsSatisfiedBy("Jane E. Doe");

            It should_be_satisfied = () => _results.ShouldBeTrue();
        }

        [Subject("And Specification")]
        public class when_satisfying_one_satisfied_specificaton_and_one_unsatisfied_specification
        {
            static ISpecification<string> _nameContainsJaneAndDoeSpecification;
            static bool _results;

            Establish context = () =>
            {
                ISpecification<string> nameContainsJaneSpecification = new StringContainsSpecification("Jane");
                ISpecification<string> nameContainsDoeSpecification = new StringContainsSpecification("Smith");
                _nameContainsJaneAndDoeSpecification = nameContainsJaneSpecification.And(nameContainsDoeSpecification);
            };

            Because of = () => _results = _nameContainsJaneAndDoeSpecification.IsSatisfiedBy("Jane E. Doe");

            It should_not_be_satisfied = () => _results.ShouldBeFalse();
        }

        [Subject("And Specification")]
        public class when_satisfying_one_unsatisfied_specificaton_and_one_satisfied_specification
        {
            static ISpecification<string> _nameContainsJaneAndDoeSpecification;
            static bool _results;

            Establish context = () =>
            {
                ISpecification<string> nameContainsJaneSpecification = new StringContainsSpecification("John");
                ISpecification<string> nameContainsDoeSpecification = new StringContainsSpecification("Doe");
                _nameContainsJaneAndDoeSpecification = nameContainsJaneSpecification.And(nameContainsDoeSpecification);
            };

            Because of = () => _results = _nameContainsJaneAndDoeSpecification.IsSatisfiedBy("Jane E. Doe");

            It should_not_be_satisfied = () => _results.ShouldBeFalse();
        }

        [Subject("And Specification")]
        public class when_satisfying_two_unsatisfied_specifiations
        {
            static ISpecification<string> _nameContainsJaneAndDoeSpecification;
            static bool _results;

            Establish context = () =>
            {
                ISpecification<string> nameContainsJaneSpecification = new StringContainsSpecification("Sam");
                ISpecification<string> nameContainsDoeSpecification = new StringContainsSpecification("Houston");
                _nameContainsJaneAndDoeSpecification = nameContainsJaneSpecification.And(nameContainsDoeSpecification);
            };

            Because of = () => _results = _nameContainsJaneAndDoeSpecification.IsSatisfiedBy("Jane E. Doe");

            It should_not_be_satisfied = () => _results.ShouldBeFalse();
        }
    }
}