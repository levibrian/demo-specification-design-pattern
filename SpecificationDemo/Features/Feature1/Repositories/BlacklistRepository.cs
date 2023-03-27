using SpecificationDemo.Features.Feature1.Models;

namespace SpecificationDemo.Features.Feature1.Repositories;

public interface IBlacklistRepository
{
    IEnumerable<Person> GetBlacklisted();
}

public class BlacklistRepository : IBlacklistRepository
{
    public IEnumerable<Person> GetBlacklisted()
    {
        return new List<Person>
        {
            new() {Age = 25, FirstName = "Bruce", LastName = "Wilkins"},
            new() {Age = 25, FirstName = "Axel", LastName = "Gorris"},
            new() {Age = 10, FirstName = "Eric", LastName = "Garcia"},
            new() {Age = 25, FirstName = "Istvan", LastName = "Bokor"},
            new() {Age = 25, FirstName = "Victor", LastName = "Martos"},
        };
    }
}