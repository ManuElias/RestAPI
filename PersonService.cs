namespace FirstProject.Services
{
    public class PersonService
    {
        private readonly List<Person> _persons = new();

        public Person GetPerson(int id)
        {
            return _persons.Single(x => x.Id == id);
        }

        public IEnumerable<Person> GetPersons()
        {
            return _persons;
        }

        public Person CreatePerson(int id, string firstName, string lastName)
        {
            var item = new Person(id, firstName, lastName);
            _persons.Add(item);
            return item;
        }

        public void DeletePerson(int id)
        {
            var item = GetPerson(id);
            _persons.Remove(item);
        }

        //Nicht im Controller benutzt
        public void DeletePersons()
        {
            _persons.Clear();
        }

        public Person UpdateFirstName(int id, string newFirstName)
        {
            Person person = GetPerson(id);
            _persons.Remove(person);
            person.FirstName = newFirstName;
            _persons.Add(person);
            return person;
        }

        public IEnumerable<Person> GetAllPersonsByLastName(string lastName)
        {
            return _persons.Where(p => p.LastName.Equals(lastName));


            //List<Person> eliasPersons = new();
            //foreach (var person in _persons)
            //{
            //    if (person.LastName.Equals("Elias")){
            //        eliasPersons.Add(person);
            //    }
            //}
            //return eliasPersons;



        }
    }
}
