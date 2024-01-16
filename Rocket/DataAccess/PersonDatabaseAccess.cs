using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;

namespace Rocket.DataAccess
{
    /*
    public class PersonDatabaseAccess : IPersonDatabaseAccess
    {
        private readonly List<Person> _persons = new();

        public IEnumerable<Person> GetPersons()
        {
            return _persons;
        }

        public void AddPerson(Person person)
        {
            _persons.Add(person);
        }

        public void RemovePerson(Person person)
        {
            _persons.Remove(person);
        }
    }
    */
    public class PersonDbContext : IPersonDatabaseAccess
    {
        private readonly RocketDbContext rocketDbContext;

        public PersonDbContext(RocketDbContext rocketDbContext)
        {
            this.rocketDbContext = rocketDbContext;
        }

        public IEnumerable<Person> GetPersons()
        {
            //async?
            return rocketDbContext.Persons;
        }

        public async Task<Person> AddPerson(Person person)
        {
            rocketDbContext.Persons.Add(person);
            await rocketDbContext.SaveChangesAsync();
            return person;
        }

        public async Task<Person> RemovePerson(Person person)
        {
            rocketDbContext.Remove(person);
            await rocketDbContext.SaveChangesAsync();
            return person;
        }
    }

    public interface IPersonDatabaseAccess
    {
        IEnumerable<Person> GetPersons();
        Task<Person> AddPerson(Person person);

        Task<Person> RemovePerson(Person person);
    }
}
