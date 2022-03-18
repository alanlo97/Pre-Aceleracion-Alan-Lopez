using Challenge.Core.Interfaces;
using Challenge.Core.Models.Dtos;
using Challenge.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Challenge.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class PersonajeController : ControllerBase
    {
        private readonly IPersonajeService _personajeService;

        public PersonajeController(IPersonajeService personajeService)
        {
            _personajeService = personajeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPersonajes()
        {
            try
            {
                var personajes = await _personajeService.GetAll();
                if (personajes != null)
                    return Ok(personajes);
                else
                    return NotFound("No se encontraron personajes");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPersonaje(int id)
        {
            var result = await _personajeService.GetById(id);
            if (result.Success)
                return Ok(result);
            return StatusCode(result.isError() ? 500 : 404, result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePersonaje(int id)
        {
            var result = await _personajeService.Delete(id);
            if (result.Success)
                return Ok(result);
            return StatusCode(result.isError() ? 500 : 400, result);
        }

        [HttpPost]
        public async Task<IActionResult> Postpersonaje([FromForm] PersonajeDtoForInsert personajeDto)
        {
            var result = await _personajeService.Insert(personajeDto);
            if (result.Success)
                return Ok(result);
            return StatusCode(result.isError() ? 500 : 400, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromForm] PersonajeDtoForInsert dto)
        {
            var result = await _personajeService.Update(id, dto);

            return StatusCode(result.StatusCode, result);
        }

    }
}

