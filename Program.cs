namespace trackingapp
{
    class Program
    {
        public static string choice;

        public static void Main(string[] args)
        {
            Console.Clear();
            Start();
        }

        static void Start()
        {
            if (new FileInfo("entries.txt").Length == 0)
            {
                Console.WriteLine("Du hast keine Geldeinträge. Ich kann dein Geld nicht berechnen.\n\n");
            } else
            {
                Console.WriteLine($"Du hast {CalculateMoney()} gespart.\n\n");
            }
            CreateEntry();
        }

        static void CreateEntry()
        {
            float amount;

            Console.Write("Wie viel hast du ausgegeben? ");
            amount = Convert.ToSingle(Console.ReadLine());

            Console.Write($"Ist das richtig? {amount} [J/n] ");
            choice = Console.ReadLine();
            if (choice != "" && choice != "J")
            {
                Console.Clear();
                CreateEntry();
            }
            File.AppendAllText("entries.txt", $"{amount}\n");
            Console.Write("Eintrag wurde erstellt.");
            Thread.Sleep(3000);
            Console.Clear();
            Start();
        }

        static int CalculateMoney()
        {
            DateTime timeOffset = new(2025, 8, 1);
            DateTime currentDate = DateTime.Now;
            return 0;
        }
    }
}