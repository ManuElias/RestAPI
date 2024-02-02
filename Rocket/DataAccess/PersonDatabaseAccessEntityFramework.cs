namespace Rocket.DataAccess;

public class PersonDatabaseAccessEntityFramework : IPersonDatabaseAccess
{
    private readonly RocketDbContext _rocketDbContext;

    public PersonDatabaseAccessEntityFramework(RocketDbContext rocketDbContext)
    {
        _rocketDbContext = rocketDbContext;
    }

    public Task<IEnumerable<Person>> GetPersonsAsync()
    {
        return Task.FromResult(_rocketDbContext.Persons.AsEnumerable());
    }

    public async Task<Person> AddPersonAsync(Person person)
    {
        await _rocketDbContext.Persons.AddAsync(person);
        await _rocketDbContext.SaveChangesAsync();
        return person;
    }

    public async Task RemovePersonAsync(Person person)
    {
        _rocketDbContext.Remove(person);
        await _rocketDbContext.SaveChangesAsync();
    }
}