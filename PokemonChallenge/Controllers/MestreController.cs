using Microsoft.AspNetCore.Mvc;
using PokemonChallenge.DTOs;
using PokemonChallenge.Services;
using PokemonChallenge.Services.Interface;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PokemonChallenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MestreController : ControllerBase
    {
        private readonly IMestreService _mestreService;

        public MestreController(IMestreService mestreService)
        {
            _mestreService = mestreService;
        }

        // GET: api/<MestreController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MestreDto>>> Get()
        {

            try
            {
                var pokemons = await _mestreService.Get();
                return Ok(pokemons);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<MestreController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MestreDto>> Get(int id)
        {
            try
            {
                var mestre = await _mestreService.GetById(id);
                return Ok(mestre);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<MestreController>
        [HttpPost]
        public async Task<ActionResult<MestreDto>> Post([FromBody] MestreDto mestreDto)
        {
            try
            {
                var mestre = await _mestreService.Add(mestreDto);
                return Ok(mestre);
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