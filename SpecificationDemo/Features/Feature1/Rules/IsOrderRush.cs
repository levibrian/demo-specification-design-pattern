using SpecificationDemo.Features.Feature1.Models;
using SpecificationDemo.Shared.Extensions;
using SpecificationDemo.Shared.Specifications.Interfaces;

namespace SpecificationDemo.Features.Feature1.Rules;

public class IsOrderRush : ISpecification<Order>
{
    public bool IsPrimitiveSatisfiedBy(Order subject)
    {
        return 
            new IsOrderDomestic()
            .And(new IsOrderHighValue())
            .And(new IsOrderInStock())
            .And(new IsOrderHazardous().Not())
            .IsPrimitiveSatisfiedBy(subject);
    } 
}