using ApiPrimeraPracticaAzure.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ApiPrimeraPracticaAzure.Repositories;

namespace ApiPrimeraPracticaAzure.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonajesController : ControllerBase
    {
        private RepositoryPersonajes repo;
        public PersonajesController(RepositoryPersonajes repo)
        {
            this.repo = repo;
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<List<Personaje>>> GetPersonajes()
        {
            try
            {
                var personajes = await repo.GetPersonajesAsync();
                return Ok(personajes);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al obtener los personajes");
            }
        }

        [HttpGet("[action]/{id}")]
        public async Task<ActionResult<Personaje>> FindPersonaje(int id)
        {
            try
            {
                var personaje = await repo.FindPersonajeAsync(id);
                if (personaje == null)
                {
                    return NotFound($"No se encontró ningún personaje con el ID {id}");
                }
                return Ok(personaje);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error al obtener el personaje: {ex.Message}");
            }
        }

        [HttpPost("[action]")]
        public async Task<ActionResult<Personaje>> InsertarPersonaje(Personaje personaje)
        {

            await repo.InsertarPersonajeAsync(personaje);
            return Ok();

        }

        [HttpPut("[action]")]
        public async Task<IActionResult> UpdatePersonaje(Personaje personaje)
        {

            await repo.UpdatePersonajeAsync(personaje);
            return Ok();

        }

        [HttpDelete("[action]/{id}")]
        public async Task<IActionResult> DeletePersonaje(int id)
        {
            try
            {
                await repo.DeletePeliculaAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error al eliminar el personaje: {ex.Message}");
            }
        }

        [HttpGet("Series")]
        public async Task<ActionResult<List<string>>> GetSeries()
        {
            try
            {
                var series = await repo.GetSeries();
                return Ok(series);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error al obtener las series: {ex.Message}");
            }
        }

        [HttpGet("[action]/{serie}")]
        public async Task<ActionResult<List<Personaje>>> GetPersonajesSerie(string serie)
        {
            try
            {
                var personajes = await repo.GetPersonajesSerie(serie);
                if (personajes == null || personajes.Count == 0)
                {
                    return NotFound($"No se encontraron personajes para la serie {serie}");
                }
                return Ok(personajes);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error al obtener los personajes de la serie: {ex.Message}");
            }
        }


    }
}
