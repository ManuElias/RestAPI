using Microsoft.Extensions.Logging;
using NSubstitute;
using Rocket.DataAccess;
using Rocket.Services;
using Xunit;

namespace Rocket.xUnitTests;

public class PersonServiceTest
{
    private readonly IPersonDatabaseAccess _personDatabaseAccess = Substitute.For<IPersonDatabaseAccess>();
    private readonly ILogger<PersonService> _logger = Substitute.For<ILogger<PersonService>>();
    private readonly PersonService _testObject;


    public PersonServiceTest()
    {
        _personDatabaseAccess.GetPersonsAsync().Returns(CreatePersons());
        _testObject = new(_personDatabaseAccess, _logger);
    }

    [Fact]
    public async Task Test()
    {
        var persons = await _testObject.GetPersonsByFirstName(string.Empty, "Eli");
        Assert.Equal(4, persons.Count());
    }

    [Fact]
    public async Task Test2()
    { 
        await _testObject.GetPersonsAsync();
        _logger.Received().LogInformation("Huhu someone logged here.");
    }

    private IEnumerable<Person> CreatePersons()
    {
        yield return new Person(1, "Jonas", "Elias");
        yield return new Person(2, "Matei", "Elias");
        yield return new Person(3, "Aaaron", "Elias");
        yield return new Person(4, "Michael", "Elias");
        yield return new Person(5, "Linda", "Atalay");
    }
}