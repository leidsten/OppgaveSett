using System;

namespace Hva_Gjør_Denne_Koden
{
    class Program
    {
        static void Main(string[] args)
        {
            var range = 250;
            var counts = new int[range];
            string text = "something";
            int totalLetters = 0;
            while (!string.IsNullOrWhiteSpace(text))
            {
                text = Console.ReadLine() ?? string.Empty; //enten input fra burker eller tom string
                foreach (var character in text.ToUpper())  //gi alle bokstavene samme størrelse, og tell dem
                {
                    totalLetters++;
                    counts[(int)character]++;
                }
                for (var i = 0; i < range; i++)
                {
                    if (counts[i] > 0)
                    {
                        var character = (char)i;
                        var percentage = 100 * (double)counts[i] / totalLetters;  //Double for å ikke "miste" hele prosenter når de legges sammen
                        string output = character + " - " + percentage.ToString("F2") + "%"; //....matte. ToString("F2") spytter ut med kun to desimaler
                        Console.CursorLeft = Console.BufferWidth - output.Length - 1;  //ta "pekeren/markøren" og sett den helt til vinduets bredde - lengda på det som er skrevet ut
                        Console.WriteLine(output);
                    }
                }
            }
        }
    }
}
