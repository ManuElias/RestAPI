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
            _persons.Add(person);
            return person;
        }

        public void RemovePerson(Person person)
        {
            _persons.Remove(person);
        }
    }
}
