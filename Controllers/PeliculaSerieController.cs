using Challenge.Core.Interfaces;
using Challenge.Core.Models.Dtos;
using Challenge.Entities;
using Challenge.Repositories;
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

    public class PeliculaSerieController : ControllerBase
    {
        private readonly IPeliculaSerieService _peliculaSerieService;

        public PeliculaSerieController(IPeliculaSerieService peliculaSerieService)
        {
            _peliculaSerieService = peliculaSerieService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPeliculaSeries()
        {
            try
            {
                var peliculaSeries = await _peliculaSerieService.GetAll();
                if (peliculaSeries != null)
                    return Ok(peliculaSeries);
                else
                    return NotFound("No se encontraron PeliculaSeries");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPeliculaSerie(int id)
        {
            var result = await _peliculaSerieService.GetById(id);
            if (result.Success)
                return Ok(result);
            return StatusCode(result.isError() ? 500 : 404, result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePeliculaSerie(int id)
        {
            var result = await _peliculaSerieService.Delete(id);
            if (result.Success)
                return Ok(result);
            return StatusCode(result.isError() ? 500 : 400, result);
        }

        [HttpPost]
        public async Task<IActionResult> PostPeliculaSerie([FromForm] PeliculaSerieDtoForInsert peliculaSerieDto)
        {
            var result = await _peliculaSerieService.Insert(peliculaSerieDto);
            if (result.Success)
                return Ok(result);
            return StatusCode(result.isError() ? 500 : 400, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromForm] PeliculaSerieDtoForInsert dto)
        {
            var result = await _peliculaSerieService.Update(id, dto);

            return StatusCode(result.StatusCode, result);
        }

    }

}
