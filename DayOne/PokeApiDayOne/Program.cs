using RestSharp;
using System.Net;

namespace PokeApiDayOne
{
    public class Program
    {
        public const string API_BASE = "https://pokeapi.co/api/v2/pokemon";

        static void Main(string[] args)
        {
            var response = GetPokeApi("pikachu");
            if (response.StatusCode == HttpStatusCode.OK)
            {
                Console.WriteLine(response.Content);
            }
            else
                Console.WriteLine("Não foi encontrado");
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
            catch
            {
                throw;
            }
        }
    }
}