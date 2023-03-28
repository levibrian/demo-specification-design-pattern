using SpecificationDemo.Features.Feature1.Models;
using SpecificationDemo.Shared.Specifications.Interfaces;

namespace SpecificationDemo.Features.Feature1.Rules;

public class IsOrderHighValue : ISpecification<Order>
{
    private const int HighValueMinimumThreshold = 100;
    
    public bool IsSatisfiedBy(Order subject)
    {
        return subject.Total > HighValueMinimumThreshold;
    }
}