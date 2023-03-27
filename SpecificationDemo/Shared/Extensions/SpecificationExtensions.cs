using SpecificationDemo.Shared.Specifications;
using SpecificationDemo.Shared.Specifications.Interfaces;

namespace SpecificationDemo.Shared.Extensions;

public static class SpecificationExtensions
{
    public static ISpecification<T> And<T>(
        this ISpecification<T> firstSpecification,
        ISpecification<T> secondSpecification)
    {
        return new AndSpecification<T>(firstSpecification, secondSpecification);
    }

    public static ISpecification<T> Or<T>(this ISpecification<T> firstSpecification,
        ISpecification<T> secondSpecification)
    {
        return new OrSpecification<T>(firstSpecification, secondSpecification);
    }
}