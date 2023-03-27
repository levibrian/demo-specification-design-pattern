using SpecificationDemo.Shared.Notifications;
using SpecificationDemo.Shared.Specifications.Base;
using SpecificationDemo.Shared.Specifications.Interfaces;

namespace SpecificationDemo.Shared.Specifications;

public class AndSpecification<T> : CompositeSpecification<T>
{
    public AndSpecification(
        ISpecification<T> firstSpecification, 
        ISpecification<T> secondSpecification) : base(firstSpecification, secondSpecification)
    {
    }
     
    public AndSpecification(IEnumerable<ISpecification<T>> rulesToValidate) : base(rulesToValidate)
    {
    }

    public override bool IsPrimitiveSatisfiedBy(T subject)
    {
        if (!ChildSpecifications.Any()) return true;
            
        var rulesResult = 
            ChildSpecifications
                .Select(rule => 
                    rule.IsPrimitiveSatisfiedBy(subject));

        return rulesResult.Any(expression => expression);
    }

    public override Result IsSatisfiedBy(T subject)
    {
        if (!ChildResultSpecifications.Any()) return Result.Ok();
            
        var rulesResult = ChildResultSpecifications
            .Select(rule => rule.IsSatisfiedBy(subject))
            .ToList();

        return rulesResult.All(result => result.IsSuccess) 
            ? Result.Ok() 
            : Result.Failure(rulesResult.SelectMany(x => x.Errors));
    }
}