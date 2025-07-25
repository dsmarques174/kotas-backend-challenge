using PokemonChallenge.DTOs;
using PokemonChallenge.Models;

namespace PokemonChallenge.Services.Interface
{
    public interface IMestreService
    {
        Task<List<MestreDto>> Get();
        Task<MestreDto> GetById(int id);

        Task<MestreDto> Add(MestreDto mestreDto);

    }
}
