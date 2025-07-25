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

        public async Task<List<PokemonDto>> Get()
        {
            var httpClient = _httpClientFactory.CreateClient("PokeAPI");

            var random = new Random();
            var pokemons = new List<PokemonDto>(10);
            //count: 1302
            //next: "https://pokeapi.co/api/v2/pokemon?offset=20&limit=20"
            //previous: null

            while (pokemons.Count < 10)
            {
                var randomId = random.Next(1, 1302);

                var response = await httpClient.GetAsync($"pokemon/{randomId}");
                if (response.StatusCode == HttpStatusCode.NotFound)
                    continue;

                response.EnsureSuccessStatusCode();

                using var responseStream = await response.Content.ReadAsStreamAsync();
                using var jsonDocument = await JsonDocument.ParseAsync(responseStream);

                pokemons.Add(jsonDocument.Deserialize<PokemonDto>());
            }

            return pokemons;
        }


        public async Task<PokemonDto> GetById(int id)
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