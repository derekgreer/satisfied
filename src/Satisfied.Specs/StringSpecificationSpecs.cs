using Machine.Specifications;
using Satisfied.Specs.TestSpecifications;

namespace Satisfied.Specs
{
    public class StringSpecificationSpecs
    {
        [Subject("Specification")]
        public class when_satisfying_a_satisfied_specificaton
        {
            static ISpecification<string> _nameContainsJaneSpecification;
            static bool _results;

            Establish context = () => _nameContainsJaneSpecification = new StringContainsSpecification("Jane");

            Because of = () => _results = _nameContainsJaneSpecification.IsSatisfiedBy("Jane E. Doe");

            It should_be_satisfied = () => _results.ShouldBeTrue();
        }
    }
}