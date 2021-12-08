using Challenge.Context;
using Challenge.Entities;
using Challenge.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Challenge.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class PersonajeController : ControllerBase
    {
        private readonly IPersonajeRepository _personajeRepository;

        public PersonajeController(IPersonajeRepository personajeRepository)
        {
            _personajeRepository = personajeRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_personajeRepository.GetAll());
        }

        [HttpPost]
        public IActionResult Post(Personaje personaje)
        {
            _personajeRepository.Insert(personaje);

            return Ok(_personajeRepository.GetAll());
        }

        [HttpPut]
        public IActionResult Put(Personaje personaje)
        {
            if (_personajeRepository.GetById(personaje.Id) == null)
                return BadRequest();

            _personajeRepository.Update(personaje);

            return Ok(_personajeRepository.GetAll());

        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            if (_personajeRepository.GetById(id) == null)

                return BadRequest();

            _personajeRepository.Delete(id);

            return Ok(_personajeRepository.GetAll());
        }

    }
}

