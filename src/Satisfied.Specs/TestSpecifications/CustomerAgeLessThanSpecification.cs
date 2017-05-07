namespace Satisfied.Specs.TestSpecifications
{
    public class CustomerAgeLessThanSpecification : CustomerAgeComparisonSpecification
    {
        public CustomerAgeLessThanSpecification(int limit) : base(limit, ComparisonValue.LessThan)
        {
        }
    }
}
