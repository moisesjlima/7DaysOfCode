using Newtonsoft.Json;

namespace PokeApi.Model
{
    public class MascotModel
    {
        [JsonProperty("abilities")]
        public Ability[] Abilities { get; set; }

        [JsonProperty("base_experience")]
        public int BaseExperience { get; set; }

        [JsonProperty("height")]
        public int Height { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("weight")]
        public int Weight { get; set; }

        [JsonProperty("mood")]
        public string Mood { get; set; }

        [JsonProperty("food_nivel")]
        public int FoodNivel { get; set; }
    }

    public class Ability
    {
        [JsonProperty("ability")]
        public Ability1 _ability { get; set; }

        [JsonProperty("is_hidden")]
        public bool IsHidden { get; set; }

        [JsonProperty("slot")]
        public int Slot { get; set; }
    }

    public class Ability1
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }
    }

    public class MascotResponseModel
    {
        [JsonProperty("results")]
        public Results[] Results { get; set; }
    }

    public class Results
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }
    }
}