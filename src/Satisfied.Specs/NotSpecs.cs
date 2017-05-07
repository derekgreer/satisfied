using Machine.Specifications;
using Satisfied.Specs.TestSpecifications;

namespace Satisfied.Specs
{
    public class NotSpecs
    {
        [Subject("Negated Specification")]
        public class when_satisfying_a_negated_satisfied_specification
        {
            static ISpecification<int> _notEven;
            static bool _results;

            Establish context = () => _notEven = new EvenSpecification().Not();

            Because of = () => _results = _notEven.IsSatisfiedBy(2);

            It should_not_be_satisfied = () => _results.ShouldBeFalse();
        }

        [Subject("Negated Specification")]
        public class when_negating_an_unsatisfied_specification
        {
            static ISpecification<int> _notEven;
            static bool _results;

            Establish context = () => _notEven = new EvenSpecification().Not();

            Because of = () => _results = _notEven.IsSatisfiedBy(3);

            It should_be_satisfied = () => _results.ShouldBeTrue();
        }
    }
}