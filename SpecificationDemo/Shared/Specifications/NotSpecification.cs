using SpecificationDemo.Shared.Notifications;
using SpecificationDemo.Shared.Specifications.Base;
using SpecificationDemo.Shared.Specifications.Interfaces;

namespace SpecificationDemo.Shared.Specifications;

public class NotSpecification<T> : CompositeSpecification<T>
{
    private readonly ISpecification<T> candidate;

    public NotSpecification(ISpecification<T> candidate) : base(candidate)
    {
        this.candidate = candidate;
    }

    public override bool IsPrimitiveSatisfiedBy(T subject)
    {
        return !candidate.IsPrimitiveSatisfiedBy(subject);
    }

    public override Result IsSatisfiedBy(T entityToEvaluate)
    {
        // NOT GOING TO BE USED
        throw new NotImplementedException();
    }
}