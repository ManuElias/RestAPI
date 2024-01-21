using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;

namespace Rocket.DataAccess
{
    
    public class PersonDatabaseAccessList : IPersonDatabaseAccess
    {
        private readonly List<Person> _persons = new();

        public IEnumerable<Person> GetPersons()
        {
            return _persons;
        }

        public Task<Person> AddPerson(Person person)
        {
            _persons.Add(person);
            return Task.FromResult(person);
        }

        public Task<Person> RemovePerson(Person person)
        {
            _persons.Remove(person);
            return Task.FromResult(person);
        }
    }
}
