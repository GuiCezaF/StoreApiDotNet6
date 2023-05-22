using Microsoft.AspNetCore.Mvc;
using MP.ApiDotNet6.Application.DTOS;
using MP.ApiDotNet6.Application.Services.Interfaces;

namespace MP.ApiDotNet6.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _personService;

        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] PersonDTO personDTO)
        {
            var result = await _personService.CreateAsync(personDTO);
            if (result.IsSucess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}