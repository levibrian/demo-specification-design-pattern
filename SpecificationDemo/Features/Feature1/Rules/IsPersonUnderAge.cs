using SpecificationDemo.Features.Feature1.Models;
using SpecificationDemo.Shared.Specifications.Interfaces;

namespace SpecificationDemo.Features.Feature1.Rules;

public class IsPersonUnderAge : ISpecification<Person>
{
    private const int MinimumAge = 18;
    
    public bool IsPrimitiveSatisfiedBy(Person subject)
    {
        return subject.Age < MinimumAge;
    }
}