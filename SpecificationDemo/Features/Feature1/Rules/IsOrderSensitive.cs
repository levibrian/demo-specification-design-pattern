using SpecificationDemo.Features.Feature1.Models;
using SpecificationDemo.Shared.Extensions;
using SpecificationDemo.Shared.Specifications.Interfaces;

namespace SpecificationDemo.Features.Feature1.Rules;

public class IsOrderSensitive : ISpecification<Order>
{
    public bool IsPrimitiveSatisfiedBy(Order subject)
    {
        return
            new IsOrderHazardous()
                .And(new IsOrderHighValue())
                .IsPrimitiveSatisfiedBy(subject);
    }
}