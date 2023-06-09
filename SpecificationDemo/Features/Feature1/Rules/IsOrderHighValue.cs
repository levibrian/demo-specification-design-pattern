using SpecificationDemo.Features.Feature1.Domain;
using SpecificationDemo.Shared.Specifications.Interfaces;

namespace SpecificationDemo.Features.Feature1.Rules;

public class IsOrderHighValue : ISpecification<Order>
{
    private const int HighValueMinimumThreshold = 100;
    
    public bool IsSatisfiedBy(Order subject) => subject.Total > HighValueMinimumThreshold;
}