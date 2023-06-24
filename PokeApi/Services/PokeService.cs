using Newtonsoft.Json;
using PokeApi.Model;
using PokeApi.View;
using RestSharp;
using System.Net;
using static System.Console;

namespace PokeApi.Services
{
    public class PokeService
    {
        public const string API_BASE = "https://pokeapi.co/api/v2/pokemon";
        public static List<MascotModel> Mascots { get; set; } = new List<MascotModel>();

        public static RestResponse GetPokeApi(string name, int? id = null, bool getAll = false)
        {
            try
            {
                var options = new RestClientOptions(API_BASE);
                var cliente = new RestClient(options);

                if (!getAll)
                {
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
                else
                {
                    RestRequest request = new RestRequest("?limit=25");
                    RestResponse response = cliente.Get(request);

                    return response;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void AdoptMascot()
        {
            var GetSpecies = GetPokeApi(string.Empty, null, true);
            if (GetSpecies.StatusCode == HttpStatusCode.OK)
            {
                var mascots = JsonConvert.DeserializeObject<MascotResponseModel>(GetSpecies.Content);
                WriteLine("Pick a specie: ");

                foreach (var result in mascots.Results)
                {
                    WriteLine(" - " + result.Name);
                }
                var speciePicked = ReadLine();

                var response = GetPokeApi(speciePicked);

                if (response.StatusCode != HttpStatusCode.OK || response == null)
                {
                    WriteLine("Mascot not found, choose one of above");
                    Tamagotchi.Menu();
                    return;
                }

                var mascot = JsonConvert.DeserializeObject<MascotModel>(response.Content);


                Tamagotchi.AdoptMascot(speciePicked);
                var choice = ReadLine();

                switch (choice)
                {
                    case "1":
                        {
                            ShowMascotDetails(response, mascot);
                            Tamagotchi.Menu();
                            break;
                        }
                    case "2":
                        {
                            if (Mascots.Any())
                            {
                                if (Mascots.Any(x => x.Name == mascot.Name))
                                {
                                    WriteLine("You already have this mascot");
                                }
                                else
                                {
                                    Mascots.Add(mascot);
                                    WriteLine(Tamagotchi.PlayerName + " Your mascot " + mascot.Name + " was successfully adopted");
                                }
                                Tamagotchi.Menu();
                            }
                            else
                            {
                                Mascots.Add(mascot);
                                WriteLine(Tamagotchi.PlayerName + " Your mascot " + mascot.Name + " was successfully adopted");
                                Tamagotchi.Menu();
                            }
                            break;
                        }
                    case "3":
                        Tamagotchi.Menu();
                        break;
                    default:
                        WriteLine("Choose one of the options above");
                        Tamagotchi.Menu();
                        break;
                }
            }
            else
                WriteLine("Not Found!");
        }

        public static void ShowMascots()
        {
            if (Mascots.Any())
            {
                WriteLine("Your mascots:");
                foreach (var mascot in Mascots)
                    WriteLine(" - " + mascot.Name);

                Tamagotchi.Menu();
            }
            else
            {
                WriteLine("You don't have any virtual mascot");
                Tamagotchi.Menu();
            }
        }

        public static void ShowMascotDetails(RestResponse response, MascotModel mascot)
        {
            {
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var abilities = mascot.Abilities.Select(x => x._ability.Name);

                    WriteLine("----------------------------------------------------------");

                    WriteLine("Pokemon Name: " + mascot.Name);
                    WriteLine("Height: " + mascot.Height);
                    WriteLine("Weight: " + mascot.Weight);

                    WriteLine("Abilitie3s: ");
                    foreach (string ability in abilities)
                    {
                        WriteLine(" - " + ability);
                    }
                }
                else
                    WriteLine("Not Found!");
            }
        }

    }
}