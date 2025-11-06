using System.IO;

namespace trackingapp
{
    class Program
    {
        public static string choice;
        class Entry
        {
            public int day, month, year;
            public float amount;
        }

        public static void Main(string[] args)
        {

            Console.WriteLine("Heute oder anderes Datum?\n\n 1 heutiges Datum\n 2 anderes Datum\n");
            choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    System.Environment.Exit(0); // temp fix
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

            
            Console.Write("\nJahr? ");
            newEntry.year = Convert.ToInt32(Console.ReadLine());

            Console.Write("Monat? ");
            newEntry.month = Convert.ToInt32(Console.ReadLine());

            Console.Write("Tag? ");
            newEntry.day = Convert.ToInt32(Console.ReadLine());

            Console.Write("Wie viel Geld hast du ausgegeben? ");
            newEntry.amount = Convert.ToSingle(Console.ReadLine());

            Console.Write($"Stimmt das? {newEntry.day}.{newEntry.month}.{newEntry.year}: {newEntry.amount} J/n ");
            choice = Console.ReadLine();
            if(choice is not null || choice != "J")
            {
                CreateEntry();
            }
            inputcsv = $"{newEntry.year},{newEntry.month},{newEntry.day},\"{newEntry.amount}\"";
            File.AppendAllText("entries.csv", $"\n{inputcsv}");
        }
    }
}