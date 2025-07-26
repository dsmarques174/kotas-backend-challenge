using System.ComponentModel.DataAnnotations;

namespace PokemonChallenge.DTOs
{
    public class CapturaPokemonDto
    {
        public int Id { get; set; }
        public int PokemonId { get; set; }
        public int MestreId { get; set; }
        public DateTime DataCaptura { get; set; }

    }
}
