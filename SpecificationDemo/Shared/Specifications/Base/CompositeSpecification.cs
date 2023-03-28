using SpecificationDemo.Shared.Notifications;
using SpecificationDemo.Shared.Specifications.Interfaces;

namespace SpecificationDemo.Shared.Specifications.Base;

public abstract class CompositeSpecification<TCandidate> : IResultSpecification<TCandidate>, ISpecification<TCandidate>
    {
        protected readonly List<ISpecification<TCandidate>> ChildSpecifications = new();

        protected readonly List<IResultSpecification<TCandidate>> ChildResultSpecifications = new();

        protected CompositeSpecification(
            ISpecification<TCandidate> candidate)
        {
            ChildSpecifications.Add(candidate);
        }

        protected CompositeSpecification(
            ISpecification<TCandidate> firstSpecification, 
            ISpecification<TCandidate> secondSpecification)
        {
            ChildSpecifications.Add(firstSpecification);
            ChildSpecifications.Add(secondSpecification);
        }

        protected CompositeSpecification(
            IResultSpecification<TCandidate> firstSpecification, 
            IResultSpecification<TCandidate> secondSpecification)
        {
            ChildResultSpecifications.Add(firstSpecification);
            ChildResultSpecifications.Add(secondSpecification);
        }

        public abstract bool IsSatisfiedBy(TCandidate subject);

        public abstract Result IsResultSatisfiedBy(TCandidate entityToEvaluate);
    }