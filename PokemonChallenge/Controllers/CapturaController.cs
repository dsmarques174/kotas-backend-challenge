using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PokemonChallenge.DTOs;
using PokemonChallenge.Services;
using PokemonChallenge.Services.Interface;

namespace PokemonChallenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CapturaController(ICapturaPokemonService capturaPokemonService) : ControllerBase
    {

        private readonly ICapturaPokemonService _capturaPokemonService = capturaPokemonService;


        // GET: api/<CapturaController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CapturaPokemonDto>>> Get()
        {

            try
            {
                var capturas = await _capturaPokemonService.Get();
                return Ok(capturas);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<CapturaController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CapturaPokemonDto>> Get(int id)
        {
            try
            {
                var captura = await _capturaPokemonService.GetById(id);
                return Ok(captura);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<CapturaController>
        [HttpPost]
        public async Task<ActionResult<CapturaPokemonDto>> Post([FromBody] CapturaPokemonDto capturaPokemonDto)
        {
            try
            {
                var captura = await _capturaPokemonService.Add(capturaPokemonDto);
                return Ok(captura);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }


}
