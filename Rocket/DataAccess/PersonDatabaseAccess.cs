namespace Rocket.DataAccess
{
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

    public interface IPersonDatabaseAccess
    {
        IEnumerable<Person> GetPersons();
        void AddPerson(Person person);

        void RemovePerson(Person person);
    }
}
