using Rocket.DataAccess;

namespace Rocket.Services
{
    public class PersonService
    {
        private readonly IPersonDatabaseAccess _personDatabaseAccess;
        private readonly ILogger<PersonService> _log;

        public PersonService(IPersonDatabaseAccess personDatabaseAccess, ILogger<PersonService> log)
        {
            _personDatabaseAccess = personDatabaseAccess;
            _log = log;
        }

        public Person GetPerson(int id)
        {
            return _personDatabaseAccess.GetPersons().Single(person => person.Id == id);
        }

        public IEnumerable<Person> GetPersonsByFirstName(string? firstName, string? lastName)
        {
            // In eine schöne sehr schöne linq query umschreiben!
            var persons = _personDatabaseAccess.GetPersons().ToArray();
            if (!string.IsNullOrEmpty(firstName))
            {
                persons = persons.Where(p => p.FirstName.Contains(firstName)).ToArray();
            }

            if (!string.IsNullOrEmpty(lastName))
            {
                persons = persons.Where(p => p.LastName.Contains(lastName)).ToArray();
            }

            return persons;
        }


        public IEnumerable<Person> GetPersons()
        {
            _log.LogInformation("ahhh someone logged here.");
            return _personDatabaseAccess.GetPersons();
        }

        public Person CreatePerson(int id, string firstName, string lastName)
        {
            var item = new Person(id, firstName, lastName);
            _personDatabaseAccess.AddPerson(item);
            return item;
        }

        public void DeletePerson(int id)
        {
            var item = GetPerson(id);
            _personDatabaseAccess.RemovePerson(item);
        }
    }
}
