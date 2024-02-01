namespace Rocket.DataAccess;

public interface IPersonDatabaseAccess
{
    Task<IEnumerable<Person>> GetPersonsAsync();
    Task<Person> AddPersonAsync(Person person);

    Task RemovePersonAsync(Person person);
}