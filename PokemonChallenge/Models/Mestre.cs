
using NuGet.DependencyResolver;

namespace PokemonChallenge.Models
{
    public class Mestre
    {
        public int Id { get; set; }

        public required string Nome { get; set; }

        public DateOnly DataNascimento { get; set; }

        public required string CPF { get; set; }


    }
}
