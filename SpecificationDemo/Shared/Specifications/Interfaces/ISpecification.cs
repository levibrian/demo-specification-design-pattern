namespace SpecificationDemo.Shared.Specifications.Interfaces;

public interface ISpecification<in T>
{
    bool IsPrimitiveSatisfiedBy(T subject);
}