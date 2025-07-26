using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.CodeAnalysis.Elfie.Serialization;
using Microsoft.EntityFrameworkCore;
using PokemonChallenge.Data;
using PokemonChallenge.DTOs;
using PokemonChallenge.Models;
using PokemonChallenge.Services.Interface;
using System.Diagnostics.Metrics;
using System.Text.RegularExpressions;

namespace PokemonChallenge.Services
{
    public class CapturaPokemonService(IHttpClientFactory httpClientFactory, AppDbContext context) : ICapturaPokemonService
    {
        private readonly IHttpClientFactory _httpClientFactory = httpClientFactory;
        private readonly AppDbContext _context = context;

        private readonly PokemonService _pokemonService;

        public async Task<CapturaPokemonDto> Add(CapturaPokemonDto capturaDto)
        {

            var mestre = await this._context.Mestre.FirstOrDefaultAsync(m => m.Id == capturaDto.MestreId);
            if (mestre == null)
                throw new KeyNotFoundException("Mestre não encontrado");

            var pokemon = _pokemonService.GetPokeAPIById(capturaDto.PokemonId);
            if (pokemon == null)
                throw new KeyNotFoundException("Pokemon não encontrado");


            var captura = new CapturaPokemon
            {
                Id = capturaDto.Id,
                MestreId = capturaDto.MestreId,
                PokemonId = capturaDto.PokemonId,
                DataCaptura = capturaDto.DataCaptura != DateTime.MinValue ? capturaDto.DataCaptura : System.DateTime.Now
            };

            this._context.CapturaPokemon.Add(captura);
            await _context.SaveChangesAsync();

            capturaDto.Id = captura.Id;

            return capturaDto;
        }

        public async Task<List<CapturaPokemonDto>> Get()
        {
            return await _context.CapturaPokemon
                            .Select(c => new CapturaPokemonDto
                            {
                                Id = c.Id,
                                MestreId = c.MestreId,
                                PokemonId = c.PokemonId,
                                DataCaptura = c.DataCaptura
                            })
                            .ToListAsync();

        }

        public async Task<CapturaPokemonDto> GetById(int id)
        {
            var captura = await this._context.CapturaPokemon.FirstOrDefaultAsync(p => p.Id == id);
            if (captura == null)
                throw new KeyNotFoundException("Captura Pokemon não encontrada");

            return new CapturaPokemonDto
            {
                     Id = captura.Id,
                     MestreId = captura.MestreId,
                     PokemonId = captura.PokemonId,
                     DataCaptura = captura.DataCaptura
                 };
        }
    }
}
