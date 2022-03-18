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
    public class GeneroController : ControllerBase
    {
        private readonly IGeneroService _generoService;

        public GeneroController(IGeneroService generoService)
        {
            _generoService = generoService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllGeneros()
        {
            try
            {
                var genero = await _generoService.GetAll();
                if (genero != null)
                    return Ok(genero);
                else
                    return NotFound("No se encontraron Generos");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGenero(int id)
        {
            var result = await _generoService.Delete(id);
            if (result.Success)
                return Ok(result);
            return StatusCode(result.isError() ? 500 : 400, result);
        }

        [HttpPost]
        public async Task<IActionResult> PostGenero([FromForm] GeneroDto generoDto)
        {
            var result = await _generoService.Insert(generoDto);
            if (result.Success)
                return Ok(result);
            return StatusCode(result.isError() ? 500 : 400, result);
        }

    }
}
