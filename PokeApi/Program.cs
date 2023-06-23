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
        public static List<MascotModel> Mascots { get; set; }
        public static string Name { get; set; }
        public static int Options { get; set; } = 1;

        static void Main(string[] args)
        {
            Mascots = new List<MascotModel>();

            PrintTamagotchi();

            WriteLine("Whats your name: ");
            Name = ReadLine();
            WriteLine("Welcome: " + Name);
            Menu();
        }

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

        public static void PrintTamagotchi()
        {
            string[] word = {
            "########      #####      #      #      #####     ######    ######  ########  ######   #       #  #",
            "   #         #     #     ##    ##     #     #   #      #  #      #    #     #      #  #       #  #",
            "   #        #       #    ###  ###    #       #  #         #      #    #     #         #       #  #",
            "   #        #       #    #  ##  #    #       #  #         #      #    #     #         #########  #",
            "   #        #########    #      #    #########  #    ###  #      #    #     #         #       #  #",
            "   #        #       #    #      #    #       #  #      #  #      #    #     #      #  #       #  #",
            "   #        #       #    #      #    #       #   ######    ######     #      ######   #       #  #",};


            for (int line = 0; line < word.Length; line++)
            {
                WriteLine(word[line]);
            }
            WriteLine();
        }

        public static void Menu()
        {
            WriteLine();
            if (Options == 1)
                WriteLine("-------------------------- MENU --------------------------");
            else
                WriteLine("----------------------------------------------------------");

            Options = 2;
            WriteLine(Name + " You would like:");
            WriteLine("1 - Adopt virtual mascot");
            WriteLine("2 - Show your mascots");
            WriteLine("3 - Exit");
            var choice = int.Parse(ReadLine());

            switch (choice)
            {
                case 1:
                    AdoptMascot();
                    break;
                case 2:
                    ShowMascots();
                    break;
                case 3:
                    WriteLine("Exiting...");
                    break;
                default:
                    WriteLine("Choose one of the options above");
                    break;
            }
        }

        public static void AdoptMascot()
        {
            WriteLine();
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

                if (response.StatusCode != HttpStatusCode.OK)
                {
                    WriteLine("Mascot not found, choose one of above");
                    Menu();
                }

                var mascot = JsonConvert.DeserializeObject<MascotModel>(response.Content);

                WriteLine("----------------------------------------------------------");
                WriteLine(Name + " You Would like:");
                WriteLine("1 - View more details about " + speciePicked);
                WriteLine("2 - Adopt " + speciePicked);
                WriteLine("3 - Return");
                var choose = int.Parse(ReadLine());


                switch (choose)
                {
                    case 1:
                        {
                            ShowMascotDetails(response, mascot);
                            Menu();
                            break;
                        }
                    case 2:
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
                                    WriteLine(Name + " Your mascot " + mascot.Name + " was successfully adopted");
                                }
                                Menu();
                            }
                            else
                            {
                                Mascots.Add(mascot);
                                WriteLine(Name + " Your mascot " + mascot.Name + " was successfully adopted");
                                Menu();
                            }
                            break;
                        }
                    case 3:
                        Menu();
                        break;
                    default:
                        WriteLine("Choose one of the options above");
                        Menu();
                        break;
                }
            }
            else
                WriteLine("Not Found!");
        }

        public static void ShowMascots()
        {
            WriteLine();
            if (Mascots.Any())
            {
                WriteLine("Your mascots:");
                foreach (var mascot in Mascots)
                    WriteLine(" - " + mascot.Name);
            }
            else
            {
                WriteLine("You don't have any virtual mascot");
                Menu();
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

                    WriteLine("Habilidades: ");
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