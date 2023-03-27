using SpecificationDemo.Shared.Notifications;
using SpecificationDemo.Shared.Specifications.Interfaces;

namespace SpecificationDemo.Shared.Specifications.Base;

public abstract class CompositeSpecification<TCandidate> : IResultSpecification<TCandidate>, ISpecification<TCandidate>
    {
        protected readonly List<ISpecification<TCandidate>> ChildSpecifications = new();

        protected readonly List<IResultSpecification<TCandidate>> ChildResultSpecifications = new();
        
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
        
        protected CompositeSpecification(IEnumerable<ISpecification<TCandidate>> rulesToValidate) => ChildSpecifications.AddRange(rulesToValidate);
        
        protected CompositeSpecification(IEnumerable<IResultSpecification<TCandidate>> rulesToValidate) => ChildResultSpecifications.AddRange(rulesToValidate);
        
        public void AddRule(ISpecification<TCandidate> childSpecification) => ChildSpecifications.Add(childSpecification);
        
        public void AddRule(IResultSpecification<TCandidate> childSpecification) => ChildResultSpecifications.Add(childSpecification);
        
        public void AddRuleRange(IEnumerable<ISpecification<TCandidate>> rulesToAdd) => ChildSpecifications.AddRange(rulesToAdd);
        
        public void AddRuleRange(IEnumerable<IResultSpecification<TCandidate>> rulesToAdd) => ChildResultSpecifications.AddRange(rulesToAdd);
        
        public abstract bool IsPrimitiveSatisfiedBy(TCandidate subject);

        public IReadOnlyCollection<ISpecification<TCandidate>> PrimitiveChildren => ChildSpecifications.AsReadOnly();
        
        public IReadOnlyCollection<IResultSpecification<TCandidate>> Children => ChildResultSpecifications.AsReadOnly();

        public abstract Result IsSatisfiedBy(TCandidate entityToEvaluate);
    }