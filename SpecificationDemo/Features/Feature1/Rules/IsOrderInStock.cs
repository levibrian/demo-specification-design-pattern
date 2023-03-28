using SpecificationDemo.Features.Feature1.Domain;
using SpecificationDemo.Shared.Specifications.Interfaces;

namespace SpecificationDemo.Features.Feature1.Rules;

public class IsOrderInStock : ISpecification<Order>
{
    public bool IsSatisfiedBy(Order subject)
    {
        return subject.Items.Any(item => item.IsInStock);
    }
}