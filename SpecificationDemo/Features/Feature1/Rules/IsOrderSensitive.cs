using SpecificationDemo.Features.Feature1.Domain;
using SpecificationDemo.Shared.Extensions;
using SpecificationDemo.Shared.Specifications.Interfaces;

namespace SpecificationDemo.Features.Feature1.Rules;

public class IsOrderSensitive : ISpecification<Order>
{
    public bool IsSatisfiedBy(Order subject) =>
        new IsOrderHighValue()
            .And(new IsOrderInStock())
            .And(new IsOrderHazardous())
        .IsSatisfiedBy(subject);
}