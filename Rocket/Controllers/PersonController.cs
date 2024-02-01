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
        public async Task<IEnumerable<Person>> GetAsync()
        {
            return await _personService.GetPersonsAsync();
        }

        [HttpGet("{personId}")]
        public async Task<Person> GetAsync(int personId)
        {
            return await _personService.GetPersonAsync(personId);
        }

        [HttpPost]
        public async Task<Person> CreateAsync(int id, string firstName, string lastName)
        {
            return await _personService.CreatePersonAsync(id, firstName, lastName);
        }

        [HttpDelete]
        public async Task DeleteAsync(int id)
        {
            await _personService.DeletePersonAsync(id);
        }
    }

}