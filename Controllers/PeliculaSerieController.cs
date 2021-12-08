using Challenge.Context;
using Challenge.Entities;
using Challenge.Interfaces;
using Challenge.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Challenge.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]

    public class PeliculaSerieController : ControllerBase
    {
        private readonly IPeliculaSerieRepository _peliculaSerieRepository;

        public PeliculaSerieController(PeliculaSerieRepository peliculaSerieRepository)
        {
            _peliculaSerieRepository = peliculaSerieRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_peliculaSerieRepository.GetAll());
        }

        [HttpPost]
        public IActionResult Post(PeliculaSerie peliculaSerie)
        {
            _peliculaSerieRepository.Insert(peliculaSerie);

            return Ok(_peliculaSerieRepository.GetAll());
        }

        [HttpPut]
        public IActionResult Put(PeliculaSerie peliculaSerie)
        {
            if(_peliculaSerieRepository.GetById(peliculaSerie.Id) == null)
                return BadRequest();

            _peliculaSerieRepository.Update(peliculaSerie);

            return Ok(_peliculaSerieRepository.GetAll());

        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            if (_peliculaSerieRepository.GetById(id) == null)

                return BadRequest();

            _peliculaSerieRepository.Delete(id);

            return Ok(_peliculaSerieRepository.GetAll());

        }

    }

}
