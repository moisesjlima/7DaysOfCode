using Newtonsoft.Json;
using PokeApi.Model;
using RestSharp;
using System.Net;
using static System.Console;

namespace PokeApi
{
    public class Program
    {
        public const string API_BASE = "https://pokeapi.co/api/v2/pokemon";

        static void Main(string[] args)
        {
            var response = GetPokeApi(string.Empty, 100);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                //Console.WriteLine(response.Content);

                var mascot = JsonConvert.DeserializeObject<MascotModel>(response.Content);

                var abilities = mascot.Abilities.Select(x => x._ability.Name);

                WriteLine("----------------------------------------------");
                WriteLine("Pokemon Name: " + mascot.Name);
                WriteLine("Height: " + mascot.Height);
                WriteLine("Weight: " + mascot.Weight);

                WriteLine("Habilidades: ");
                foreach (string ability in abilities)
                {
                    WriteLine(" - " + ability);
                }
                WriteLine("----------------------------------------------");
            }
            else
                WriteLine("Not Found!");
        }

        public static RestResponse GetPokeApi(string name, int? id = null)
        {
            try
            {
                var options = new RestClientOptions(API_BASE);
                var cliente = new RestClient(options);

                string search = string.Empty;

                if (!string.IsNullOrEmpty(name))
                {
                    search = $"/{name}";
                }
                else if (id.HasValue)
                {
                    search = $"/{id}";
                }

                RestRequest request = new RestRequest(search);
                RestResponse response = cliente.Get(request);

                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}