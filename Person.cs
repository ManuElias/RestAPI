namespace FirstProject
{
    //public record Person(int Id, string FirstName, string LastName);

    public class Person
    {   
        public int Id { get; set; }
        public string FirstName { get;  set; }
        public string LastName { get; set; }

        //Konstruktor
        public Person(int id, string firstName, string lastName)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
        }



    }



}