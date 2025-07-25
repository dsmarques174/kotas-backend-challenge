using PokemonChallenge.DTOs;

namespace PokemonChallenge.Services.Interface
{
    public interface IPokemonService
    {
        Task<PokemonDto> GetPokemonById(int id);
    }
}
