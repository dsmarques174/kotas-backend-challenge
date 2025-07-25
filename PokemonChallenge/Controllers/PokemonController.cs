using Microsoft.AspNetCore.Mvc;
using PokemonChallenge.DTOs;
using PokemonChallenge.Services.Interface;
using System;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PokemonChallenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonController : ControllerBase
    {

        private readonly IPokemonService _pokemonService;

        public PokemonController(IPokemonService pokemonService)
        {
            _pokemonService = pokemonService;
        }

        // GET: api/<PokemonController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PokemonDto>>> Get()
        {

            try
            {
                var pokemons = await _pokemonService.Get();
                return Ok(pokemons);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<PokemonController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PokemonDto>> Get(int id)
        {
            try
            {
                var pokemon = await _pokemonService.GetById(id);
                return Ok(pokemon);
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

        // POST api/<PokemonController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<PokemonController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PokemonController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
