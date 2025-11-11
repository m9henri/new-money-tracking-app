namespace trackingapp
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.Clear();
            Start();
        }

        static void Start()
        {
            if (new FileInfo("entries.txt").Length == 0)
            {
                Console.WriteLine("Du hast keine Geldeinträge. Ich kann dein Geld nicht berechnen.\n");
            }
            else
            {
                Console.WriteLine($"Du hast {CalculateMoney()} gespart.\n");
            }
            CreateEntry();
        }

        static void CreateEntry()
        {
            float amount;

            Console.Write("Wie viel hast du ausgegeben? ");
            amount = Convert.ToSingle(Console.ReadLine());

            // Console.Write($"Ist das richtig? {amount} [J/n] "); 
            // choice = Console.ReadLine();
            // if (choice != "" && choice != "J") // asks for conformation but i only have one variable now
            // {
            //     Console.Clear();
            //     CreateEntry();
            // }
            File.AppendAllText("entries.txt", $"{amount}\n");
            Console.Write("Eintrag wurde erstellt.");
            Thread.Sleep(3000);
            Console.Clear();
            Start();
        }

        static float CalculateMoney()
        {
            int monthsDifference;
            float totalMoney;
            string[] entries = File.ReadAllLines("entries.txt");
            DateTime timeOffset = new(2025, 8, 1);
            DateTime currentDate = DateTime.Now;

            monthsDifference = (currentDate.Year - timeOffset.Year) * 12 + (currentDate.Month - timeOffset.Month);
            totalMoney = monthsDifference * 300;

            for (int i = 0; i < entries.Length; i++)
            {
                totalMoney -= Convert.ToSingle(entries[i]);
            }

            return totalMoney;
        }
    }
}