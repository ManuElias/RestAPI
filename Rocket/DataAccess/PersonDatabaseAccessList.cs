namespace Rocket.DataAccess
{
    
    public class PersonDatabaseAccessList : IPersonDatabaseAccess
    {
        private readonly RocketListContext _rocketListContext;

        public PersonDatabaseAccessList(RocketListContext rocketListContext)
        {
            _rocketListContext = rocketListContext;
        }

        public async Task<IEnumerable<Person>> GetPersonsAsync()
        {
            IEnumerable<Person> persons = _rocketListContext.GetPersons(); // das soll nicht so sein... List --> IEnumerable
            return await Task.FromResult(persons);
        }
 
        public async Task<Person> AddPersonAsync(Person person)
        {
            var addedPerson = _rocketListContext.AddPerson(person);
            return await Task.FromResult(addedPerson);
        }
        
        public async Task RemovePersonAsync(Person person)
        {
            _rocketListContext.RemovePerson(person);
            await Task.CompletedTask;
        }
    }
}
