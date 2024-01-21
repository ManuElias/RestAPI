namespace Rocket.DataAccess;

public class PersonDatabaseAccessEntityFramework : IPersonDatabaseAccess
{
    private readonly RocketDbContext _rocketDbContext;

    public PersonDatabaseAccessEntityFramework(RocketDbContext rocketDbContext)
    {
        _rocketDbContext = rocketDbContext;
    }

    public IEnumerable<Person> GetPersons()
    {
        //async?
        return _rocketDbContext.Persons;
    }

    public async Task<Person> AddPerson(Person person)
    {
        _rocketDbContext.Persons.Add(person);
        await _rocketDbContext.SaveChangesAsync();
        return person;
    }

    public async Task<Person> RemovePerson(Person person)
    {
        _rocketDbContext.Remove(person);
        await _rocketDbContext.SaveChangesAsync();
        return person;
    }
}