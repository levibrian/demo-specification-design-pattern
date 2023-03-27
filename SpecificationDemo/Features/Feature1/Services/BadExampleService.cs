using SpecificationDemo.Features.Feature1.Models;
using SpecificationDemo.Features.Feature1.Repositories;
using SpecificationDemo.Shared.Notifications;

namespace SpecificationDemo.Features.Feature1.Services;

public class BadExampleService
{
    private readonly IBlacklistRepository blacklistRepository;

    public BadExampleService(IBlacklistRepository blacklistRepository)
    {
        this.blacklistRepository = blacklistRepository;
    }
    
    public Result Handle(Person person)
    {
        if (string.IsNullOrEmpty(person.FirstName))
        {
            return Result.Failure(2001, "First name is empty.");
        }

        if (string.IsNullOrEmpty(person.LastName))
        {
            return Result.Failure(2002, "Last name is empty.");
        }
        
        if (person.Age < 18)
        {
            return Result.Failure(2003, "Person is under age.");
        }
        
        // Lets say we have a blacklist and we need to find said person.
        var blacklistedPeople = blacklistRepository.GetBlacklisted();

        if (blacklistedPeople.Any(p =>
                p.FirstName == person.FirstName && p.LastName == person.LastName && p.Age == person.Age))
        {
            return Result.Failure(2004, "Person is Blacklisted.");
        }
        
        // Do some operations like: saving person to database.
        // Process(person);
        
        return Result.Ok();
    }
}