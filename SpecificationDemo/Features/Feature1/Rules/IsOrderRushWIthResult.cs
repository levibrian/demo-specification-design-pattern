using SpecificationDemo.Features.Feature1.Domain;
using SpecificationDemo.Shared.Notifications;
using SpecificationDemo.Shared.Specifications.Interfaces;

namespace SpecificationDemo.Features.Feature1.Rules;

public class IsOrderRushWIthResult : IResultSpecification<Order>
{
    public Result IsResultSatisfiedBy(Order subject)
    {
        var expression = new IsOrderRush().IsSatisfiedBy(subject);

        return expression 
            ? Result.Ok() : 
            Result.Failure(1001, "Order is not rush.");
    }
}