using Microsoft.AspNetCore.Mvc;
using Rocket.Services;

namespace Rocket.Controllers
{
    [ApiController]
    [Route("persons")]
    public class PersonController : ControllerBase
    {
        private readonly PersonService _personService;

        public PersonController(PersonService personService)
        {
            _personService = personService;
        }

        [HttpGet]
        public IEnumerable<Person> Get()
        {
            return _personService.GetPersons();
        }

        [HttpGet("{personId}")]
        public Person Get(int personId)
        {
            return _personService.GetPerson(personId);
        }

        [HttpPost("search")]
        public IEnumerable<Person> Search(SearchPerson searchPerson)
        {
            return _personService.GetPersonsByFirstName(searchPerson.FirstName, searchPerson.LastName);
        }

        [HttpPost]
        public Person Create(int id, string firstName, string lastName)
        {
            return _personService.CreatePerson(id, firstName, lastName);
        }

        [HttpDelete]
        public void Delete(int id)
        {
            _personService.DeletePerson(id);
        }
    }

    public class SearchPerson
    {
        public string? FirstName { get; }
        public string? LastName { get; }

        public SearchPerson(string? firstName, string? lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
    }
}