using SpecificationDemo.Shared.Notifications;

namespace SpecificationDemo.Shared.Specifications.Interfaces;

public interface IResultSpecification<in T>
{
    Result IsSatisfiedBy(T subject);
}