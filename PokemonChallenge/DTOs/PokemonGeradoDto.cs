namespace PokemonChallenge.DTOs
{
        public class PokemonGeradoDto
    {
            public Ability[] abilities { get; set; }
            public int base_experience { get; set; }
            public Cries cries { get; set; }
            public Form[] forms { get; set; }
            public Game_Indices[] game_indices { get; set; }
            public int height { get; set; }
            public int id { get; set; }
            public bool is_default { get; set; }
            public string location_area_encounters { get; set; }
            public string name { get; set; }
            public int order { get; set; }
            public object[] past_types { get; set; }
            public Species species { get; set; }
            public Sprites sprites { get; set; }
            public Type[] types { get; set; }
            public int weight { get; set; }
        }

        public class Cries2
        {
            public string latest { get; set; }
            public string legacy { get; set; }
        }

        public class Species2
        {
            public string name { get; set; }
            public string url { get; set; }
        }

        public class Sprites2
        {
            public string back_default { get; set; }
            public object back_female { get; set; }
            public string back_shiny { get; set; }
            public object back_shiny_female { get; set; }
            public string front_default { get; set; }
            public object front_female { get; set; }
            public string front_shiny { get; set; }
            public object front_shiny_female { get; set; }
        }

        public class Ability
        {
            public Ability1 ability { get; set; }
            public bool is_hidden { get; set; }
            public int slot { get; set; }
        }

        public class Ability1
        {
            public string name { get; set; }
            public string url { get; set; }
        }

        public class Form
        {
            public string name { get; set; }
            public string url { get; set; }
        }

        public class Game_Indices
        {
            public int game_index { get; set; }
            public Version version { get; set; }
        }

        public class Version
        {
            public string name { get; set; }
            public string url { get; set; }
        }


}
