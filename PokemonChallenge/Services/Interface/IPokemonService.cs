using PokemonChallenge.DTOs;

namespace PokemonChallenge.Services.Interface
{
    public interface IPokemonService
    {
        Task<List<PokemonDto>> Get();
        Task<PokemonDto> GetById(int id);
    }
}
