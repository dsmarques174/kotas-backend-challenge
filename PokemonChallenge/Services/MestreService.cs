using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.CodeAnalysis.Elfie.Serialization;
using Microsoft.EntityFrameworkCore;
using PokemonChallenge.Data;
using PokemonChallenge.DTOs;
using PokemonChallenge.Models;
using PokemonChallenge.Services.Interface;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;

namespace PokemonChallenge.Services
{
    public class MestreService(IHttpClientFactory httpClientFactory, AppDbContext context) : IMestreService
    {
        private readonly IHttpClientFactory _httpClientFactory = httpClientFactory;
        private readonly AppDbContext _context = context;

        public async Task<MestreDto> Add(MestreDto mestreDto)
        {

            var m = await this._context.Mestre.FirstOrDefaultAsync(m => m.CPF == mestreDto.CPF.Replace(".", "").Replace("-",""));
            if (m != null)
                throw new ValidationException($"Mestre já cadastrado com o CPF {mestreDto.CPF}");

            var mestre = new Mestre
            {
                Nome = mestreDto.Nome,
                CPF = mestreDto.CPF.Replace(".", "").Replace("-", ""),
                DataNascimento = mestreDto.DataNascimento
            };

            this._context.Mestre.Add(mestre);
            await _context.SaveChangesAsync();

            mestreDto.Id = mestre.Id;

            return mestreDto;
        }

        public async Task<List<MestreDto>> Get()
        {
            return await _context.Mestre
                            .Select(m => new MestreDto
                            {
                                Id = m.Id,
                                Nome = m.Nome,
                                CPF = m.CPF,
                                DataNascimento = m.DataNascimento
                            })
                            .ToListAsync();

        }

        public async Task<MestreDto> GetById(int id)
        {
            var mestre = await this._context.Mestre.FirstOrDefaultAsync(p => p.Id == id);
            if (mestre == null)
                throw new KeyNotFoundException("Mestre não encontrado");

            return new MestreDto
                 {
                     Id = mestre.Id,
                     Nome = mestre.Nome,
                     CPF = mestre.CPF,
                     DataNascimento = mestre.DataNascimento
                 };
        }
    }
}
