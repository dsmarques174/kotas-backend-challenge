using Newtonsoft.Json;
using PokemonChallenge.Data;
using PokemonChallenge.DTOs;
using PokemonChallenge.Services.Interface;
using System.Net;
using System.Net.Http;
using System.Text.Json;

namespace PokemonChallenge.Services
{
    public class PokemonService : IPokemonService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly AppDbContext _context;

        public PokemonService(IHttpClientFactory httpClientFactory, AppDbContext context)
        {
            _httpClientFactory = httpClientFactory;
            _context = context;
        }

        public async Task<PokemonDto> GetPokemonById(int id)
        {
            var httpClient = _httpClientFactory.CreateClient("PokeAPI");

            // Get basic Pokémon data
            var response = await httpClient.GetAsync($"pokemon/{id}");
            if (response.StatusCode == HttpStatusCode.NotFound)
                throw new KeyNotFoundException("Pokemon não encontrado");

            response.EnsureSuccessStatusCode();

            using var responseStream = await response.Content.ReadAsStreamAsync();
            using var jsonDocument = await JsonDocument.ParseAsync(responseStream);

            return jsonDocument.Deserialize<PokemonDto>();
        }



    }
}