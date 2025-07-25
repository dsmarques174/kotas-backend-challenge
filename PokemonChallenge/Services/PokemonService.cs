using PokemonChallenge.DTOs;
using PokemonChallenge.Services.Interface;

namespace PokemonChallenge.Services
{
    public class PokemonService : IPokemonService
    {
        public Task<PokemonDto> GetPokemonById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
