namespace Rocket.DataAccess
{
    // This is a Singelton to simulate a simple List Database
    public class RocketListContext
    {
        private readonly List<Person> _persons = new(); // rudimentäre DB

        public IEnumerable<Person> GetPersons()
        {
            return _persons;
        }

        public Person AddPerson(Person person)
        {
            var newPerson = person with { Id = _persons.Count };
            _persons.Add(newPerson);
            return newPerson;
        }

        public void RemovePerson(Person person)
        {
            _persons.Remove(person);
        }
    }
}
