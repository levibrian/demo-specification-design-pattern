using SpecificationDemo.Features.Feature1.Domain;
using SpecificationDemo.Shared.Specifications.Interfaces;

namespace SpecificationDemo.Features.Feature1.Rules;

public class IsOrderDomestic : ISpecification<Order>
{
    private const string DomesticCountryCode = "ESP";
    
    public bool IsSatisfiedBy(Order subject) => subject.ShippingAddress?.Country == DomesticCountryCode;
}