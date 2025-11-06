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
            Console.Clear();
            Start();
        }

        static void Start()
        {
            Console.WriteLine("Heutiges oder anderes Datum?\n\n 1 heutiges Datum\n 2 anderes Datum\n");
            choice = Console.ReadLine();
            if (choice != "1" && choice != "2")
            {
                Console.WriteLine("Invalid Number");
                Environment.Exit(1);
            }
            CreateEntry();
        }

        static void CreateEntry()
        {
            string inputcsv;
            Entry newEntry = new();
            DateTime date = DateTime.Now;
            newEntry.year = date.Year;
            newEntry.month = date.Month;
            newEntry.day = date.Day;

            if (choice == "2")
            {
                Console.Write("\nTag? ");
                newEntry.day = Convert.ToInt32(Console.ReadLine());

                Console.Write("Monat? ");
                newEntry.month = Convert.ToInt32(Console.ReadLine());

                Console.Write("Jahr? ");
                newEntry.year = Convert.ToInt32(Console.ReadLine());
            }
            
            Console.Write("Wie viel hast du ausgegeben? ");
            newEntry.amount = Convert.ToSingle(Console.ReadLine());

            Console.Write($"Ist das richtig? {newEntry.day}.{newEntry.month}.{newEntry.year}: {newEntry.amount} [J/n] ");
            choice = Console.ReadLine();
            if (choice != "" && choice != "J")
            {
                Console.Clear();
                CreateEntry();
            }

            if (newEntry.month > 12 || newEntry.day > 31 || newEntry.amount <= 0)
            {
                Console.WriteLine("Dein Datum oder der Betrag stimmt nicht.");
                Thread.Sleep(2500);
                Console.Clear();
                CreateEntry();
            }

            inputcsv = $"{newEntry.year},{newEntry.month},{newEntry.day},\"{newEntry.amount}\"";
            File.AppendAllText("entries.csv", $"\n{inputcsv}");
            Console.Write("Eintrag wurde erstellt.");
            Thread.Sleep(3000);
            Console.Clear();
            Start();
        }
    }
}