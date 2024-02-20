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

        public async Task<Person> GetPersonAsync(Guid id)
        {

            var allPersons = await _personDatabaseAccess.GetPersonsAsync();
            return allPersons.ToList().Single(person => person.Id.Equals(id));
        }

        public async Task<IEnumerable<Person>> GetPersonsByFirstName(string? firstName, string? lastName)
        {
            // Können so firstName, lastName null sein?
            var persons = await _personDatabaseAccess.GetPersonsAsync();
            persons = persons.Where(x => !string.IsNullOrEmpty(firstName) && !string.IsNullOrEmpty(lastName))
                     .Where(p => p.FirstName.Contains(firstName) && p.LastName.Contains(lastName))
                     .ToArray();
            return persons;
        }


        public async Task<IEnumerable<Person>> GetPersonsAsync()
        {
            _log.LogInformation("ahhh someone logged here.");
            return await _personDatabaseAccess.GetPersonsAsync();
        }

        public async Task<Person> CreatePersonAsync(string firstName, string lastName)
        {
            var item = new Person(Guid.NewGuid(), firstName, lastName);
            var addedPerson = await _personDatabaseAccess.AddPersonAsync(item);
            return addedPerson;
        }

        public async Task DeletePersonAsync(Guid id)
        {
            await _personDatabaseAccess.RemovePersonAsync(await GetPersonAsync(id));
        }
    }
}
