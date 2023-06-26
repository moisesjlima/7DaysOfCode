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
            WriteLine("What's your name: ");
            PlayerName = ReadLine();
            WriteLine("Welcome " + PlayerName + " =)");

            Menu();
        }

        public static void Menu()
        {
            if (Options == 1)
                WriteLine("\n-------------------------- MENU --------------------------");
            else
                WriteLine("\n----------------------------------------------------------");

            Options = 2;
            WriteLine(PlayerName + " you would like:");
            WriteLine("1 - Adopt virtual mascot");
            WriteLine("2 - Show your mascots");
            WriteLine("3 - Exit");
        }

        public static void AdoptMascot(string speciePicked)
        {
            WriteLine("\n----------------------------------------------------------");
            WriteLine(PlayerName + " you would like:");
            WriteLine("1 - View more details about " + speciePicked);
            WriteLine("2 - Adopt " + speciePicked);
            WriteLine("3 - Return");
        }

        public static void printEgg()
        {
            string[] egg =
            {
             "     ***     ",
             "  **     **  ",
             " *         * ",
             "*           *",
             " *         * ",
             "  **     **  ",
             "     ***     "
            };

            for (int line = 0; line < egg.Length; line++)
            {
                WriteLine(egg[line]);
            }

        }

        public static void AdoptedMascotDetails(string speciePicked)
        {
            WriteLine("\n----------------------------------------------------------");
            WriteLine(PlayerName + " you would like:");
            WriteLine("1 - View " + speciePicked + " mood");
            WriteLine("2 - Feed " + speciePicked);
            WriteLine("3 - Have fun with " + speciePicked);
            WriteLine("4 - View all " + speciePicked + " details");
            WriteLine("5 - Return");
        }

    }
}