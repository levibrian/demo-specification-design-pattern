using SpecificationDemo.Features.Feature1.Models;
using SpecificationDemo.Shared.Specifications.Interfaces;

namespace SpecificationDemo.Features.Feature1.Rules;

public class IsOrderDomestic : ISpecification<Order>
{
    private const string DomesticCountryCode = "ESP";
    
    public bool IsPrimitiveSatisfiedBy(Order subject)
    {
        return subject.ShippingAddress?.Country == DomesticCountryCode;
    }
}