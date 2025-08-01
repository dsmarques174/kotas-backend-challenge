﻿using Newtonsoft.Json;
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

                var pokemonDto = await this.GetPokeAPIById(randomId);
                if (pokemonDto == null)
                    continue;

                pokemons.Add(pokemonDto);
            }

            return pokemons;
        }


        public async Task<PokemonDto> GetById(int id)
        {
            var pokemonDto = await this.GetPokeAPIById(id);

            if (pokemonDto == null)
                throw new KeyNotFoundException("Pokemon não encontrado");


            return pokemonDto;
        }

        public async Task<PokemonDto> GetPokeAPIById(int id)
        {
            var httpClient = _httpClientFactory.CreateClient("PokeAPI");

            // Get basic Pokémon data
            var response = await httpClient.GetAsync($"pokemon/{id}");
            if (response.StatusCode == HttpStatusCode.NotFound)
                return null;

            response.EnsureSuccessStatusCode();

            using var responseStream = await response.Content.ReadAsStreamAsync();
            using var jsonDocument = await JsonDocument.ParseAsync(responseStream);

            var pokemonDto = jsonDocument.Deserialize<PokemonDto>();

            if (pokemonDto.Sprites != null && !string.IsNullOrEmpty(pokemonDto.Sprites.BackDefault))
                pokemonDto.Sprites.BackDefaultBase64 = await this.GetSpriteBase64(pokemonDto.Sprites.BackDefault);

            return pokemonDto;
        }


        private async Task<string> GetSpriteBase64(string spriteUrl)
        {
            if (string.IsNullOrEmpty(spriteUrl))
                return string.Empty;

            using var httpClient = new HttpClient();
            var imageBytes = await httpClient.GetByteArrayAsync(spriteUrl);
            return Convert.ToBase64String(imageBytes);
        }
    }
}