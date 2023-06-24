using static System.Console;

namespace PokeApi.View
{
    public class Tamagotchi
    {
        public static string PlayerName { get; set; }
        public static int Options { get; set; } = 1;

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
            WriteLine("Whats your name: ");
            PlayerName = ReadLine();
            WriteLine("Welcome: " + PlayerName);

            Menu();
        }

        public static void Menu()
        {
            if (Options == 1)
                WriteLine("\n-------------------------- MENU --------------------------");
            else
                WriteLine("\n----------------------------------------------------------");

            Options = 2;
            WriteLine(PlayerName + " You would like:");
            WriteLine("1 - Adopt virtual mascot");
            WriteLine("2 - Show your mascots");
            WriteLine("3 - Exit");
        }

        public static void AdoptMascot(string speciePicked)
        {
            WriteLine("\n----------------------------------------------------------");
            WriteLine(PlayerName + " You Would like:");
            WriteLine("1 - View more details about " + speciePicked);
            WriteLine("2 - Adopt " + speciePicked);
            WriteLine("3 - Return");
        }

    }
}