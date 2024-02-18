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

        public async Task<Person> GetPersonAsync(int id)
        {

            var allPersons = await _personDatabaseAccess.GetPersonsAsync();
            return allPersons.ToList().Single(person => person.Id == id);
        }

        public async Task<IEnumerable<Person>> GetPersonsByFirstName(string? firstName, string? lastName)
        {
            // In eine schöne sehr schöne linq query umschreiben!
            var persons = await _personDatabaseAccess.GetPersonsAsync();//.ToArray();
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


        public async Task<IEnumerable<Person>> GetPersonsAsync()
        {
            _log.LogInformation("ahhh someone logged here.");
            return await _personDatabaseAccess.GetPersonsAsync();
        }

        public async Task<Person> CreatePersonAsync(string firstName, string lastName)
        {
            var item = new Person(0, firstName, lastName);
            var addedPerson = await _personDatabaseAccess.AddPersonAsync(item);
            return addedPerson;
        }

        public async Task DeletePersonAsync(int id)
        {
            await _personDatabaseAccess.RemovePersonAsync(await GetPersonAsync(id));
        }
    }
}
