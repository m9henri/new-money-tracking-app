using System;
using System.IO;
using System.Threading.Tasks;

namespace trackingapp
{
    class Program
    {
        public static string? choice;
        class Entry
        {
            public int day, month, year;
            public float amount;
        }

        public static void Main(string[] args)
        {
            Console.Clear();
            Start();
        }

        static void Start()
        {
            Console.WriteLine("Heutiges oder anderes Datum?\n\n 1 heutiges Datum\n 2 anderes Datum\n");
            choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    System.Environment.Exit(2); // temp fix
                    break;
                case "2":
                    CreateEntry();
                    break;
                default:
                    System.Environment.Exit(1);
                    break;
            }
        }

        static void CreateEntry()
        {
            string inputcsv;
            Entry newEntry = new();

            Console.Write("\nTag? ");
            newEntry.day = Convert.ToInt32(Console.ReadLine());

            Console.Write("Monat? ");
            newEntry.month = Convert.ToInt32(Console.ReadLine());

            Console.Write("Jahr? ");
            newEntry.year = Convert.ToInt32(Console.ReadLine());

            Console.Write("Wie viel hast du ausgegeben? ");
            newEntry.amount = Convert.ToSingle(Console.ReadLine());

            Console.Write($"Ist das richtig? {newEntry.day}.{newEntry.month}.{newEntry.year}: {newEntry.amount} [J/n] ");
            choice = Console.ReadLine(); // new line != null
            if (choice is not null || choice != "J")
            {
                // Console.Clear();
                // CreateEntry();
                Console.WriteLine(choice);
                System.Environment.Exit(-67);
            }

            if (newEntry.month > 12 || newEntry.day > 31 || newEntry.amount <= 0)
            {
                Console.WriteLine("Dein Datum oder der Betrag stimmt nicht.");
                Task.Delay(2500);
                Console.Clear();
                CreateEntry();
            }
            
            inputcsv = $"{newEntry.year},{newEntry.month},{newEntry.day},\"{newEntry.amount}\"";
            File.AppendAllText("entries.csv", $"\n{inputcsv}");
            Console.WriteLine("Eintrag wurde erstellt.");
            Task.Delay(3000);
            Console.Clear();
            Start();
        }
    }
}