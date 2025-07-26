using PokemonChallenge.DTOs;

namespace PokemonChallenge.Services.Interface
{
    public interface ICapturaPokemonService
    {
        Task<List<CapturaPokemonDto>> Get();

        Task<CapturaPokemonDto> GetById(int id);

        Task<CapturaPokemonDto> Add(CapturaPokemonDto mestreDto);

    }
}
