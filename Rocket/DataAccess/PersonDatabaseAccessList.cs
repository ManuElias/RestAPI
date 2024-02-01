using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;

namespace Rocket.DataAccess
{
    
    public class PersonDatabaseAccessList : IPersonDatabaseAccess
    {
        private readonly List<Person> _persons = new();

        public async Task<IEnumerable<Person>> GetPersonsAsync()
        {
            IEnumerable<Person> persons = _persons; // das soll nicht so sein... List --> IEnumerable
            return await Task.FromResult(persons);
        }
 
        public async Task<Person> AddPersonAsync(Person person)
        {
            _persons.Add(person);
            return await Task.FromResult(person);
        }
        
        public async Task RemovePersonAsync(Person person)
        {
            _persons.Remove(person);
            await Task.CompletedTask;
        }
    }
}
