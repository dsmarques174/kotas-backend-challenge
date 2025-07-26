namespace PokemonChallenge.Models
{
    public class CapturaPokemon
    {
        public int Id { get; set; }
        public int PokemonId { get; set; }
        public int MestreId { get; set; }
        public DateTime DataCaptura { get; set; }

        public Mestre Mestre { get; set; }
        public Pokemon Pokemon { get; set; }

    }
}
