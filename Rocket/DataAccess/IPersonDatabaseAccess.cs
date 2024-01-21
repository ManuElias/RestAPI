namespace Rocket.DataAccess;

public interface IPersonDatabaseAccess
{
    IEnumerable<Person> GetPersons();
    Task<Person> AddPerson(Person person);

    Task<Person> RemovePerson(Person person);
}