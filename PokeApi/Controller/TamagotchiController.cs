using PokeApi.Services;
using PokeApi.View;

namespace PokeApi.Controller
{
    public class TamagotchiController
    {
        public static void Play()
        {
            Tamagotchi.PrintTamagotchi();
            bool keepGame = true;

            do
            {
                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        PokeService.AdoptMascot();
                        break;
                    case "2":
                        PokeService.ShowMascots();
                        break;
                    case "3":
                        Console.WriteLine("Exiting...");
                        keepGame = false;
                        break;
                    default:
                        Console.WriteLine("Choose one of the options above");
                        break;
                }
            } while (keepGame);
        }

    }
}