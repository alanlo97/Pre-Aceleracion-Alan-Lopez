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
    public class GeneroController : ControllerBase
    {
        private readonly IGeneroRepository _generoRepository;

        public GeneroController(IGeneroRepository generoRepository)
        {
            _generoRepository = generoRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_generoRepository.GetAll());
        }

        [HttpPost]
        public IActionResult Post(Genero genero)
        {
            _generoRepository.Insert(genero);

            return Ok(_generoRepository.GetAll());
        }

        [HttpPut]
        public IActionResult Put(Genero genero)
        {
            if (_generoRepository.GetById(genero.Id) == null)
                return BadRequest();

            _generoRepository.Update(genero);

            return Ok(_generoRepository.GetAll());

        }

    }
}
