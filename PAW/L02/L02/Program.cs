namespace L02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Ex1();
            //Ex2();
            var orderedWords = Ex4("Hello Worlddd");

            List<int> a = [1, 2, 3, 4];
            List<int> b = [3, 4, 5];
            IEnumerable<bool> result = Ex5(a, b);
            var c = b.Zip(result);

            Dreptunghi dreptunghi = new Dreptunghi(2, 3);
            Console.WriteLine(dreptunghi.CalculeazaArie());
            Console.WriteLine(dreptunghi.CalculeazaPerimetru());

            Patrat patrat = new Patrat(3);
            Console.WriteLine(patrat.CalculeazaArie());
            Console.WriteLine(patrat.CalculeazaPerimetru());
        }

        public class Dreptunghi
        {
            public decimal Lungime { get; private set; }
            public decimal Latime { get; private set; }

            public Dreptunghi(decimal lungime, decimal latime)
            {
                Lungime = lungime;
                Latime = latime;
            }

            public decimal CalculeazaArie()
            {
                return Lungime * Latime;
            }

            public decimal CalculeazaPerimetru()
            {
                return 2 * (Lungime + Latime);
            }
        }

        public class Patrat : Dreptunghi
        {
            public Patrat(decimal latura)
                : base(latura, latura)
            {
            }
        }

        static IEnumerable<bool> Ex5(IEnumerable<int> x, IEnumerable<int> y)
        {
            return y.Select(y => x.Contains(y));
        }

        static IEnumerable<string> Ex4(string sentence)
        {
            return sentence.Split(' ').OrderByDescending(s => s.Length);
        }

        static bool Ex3(string input)
        {
            string reversed = string.Join(string.Empty, input.Reverse());
            return input == reversed;
        }

        static void Ex2()
        {
            string? input = Console.ReadLine();

            if (input is null)
            {
                return;
            }

            string[] tokens = input.Split(' ');

            IEnumerable<int> numbers = tokens.Select(x => Convert.ToInt32(x));
            int sum = 0;

            foreach (int number in numbers)
            {
                if (IsPrime(number))
                {
                    sum += number;
                }
            }

            Console.WriteLine($"Suma numerelor prime: {sum}");
        }

        static bool IsPrime(int number)
        {
            if (number < 2)
            {
                return false;
            }

            if (number == 2)
            {
                return true;
            }

            if (number % 2 == 0)
            {
                return false;
            }

            for (int d = 3; d * d <= number; d += 2)
            {
                if (number % d == 0)
                {
                    return false;
                }
            }

            return true;
        }

        static void Ex1()
        {
            string? input = Console.ReadLine();

            bool parsed = int.TryParse(input, out int number);

            if (number % 2 == 0 && number % 3 == 0 && number % 5 != 0)
            {
                Console.WriteLine($"Nr {number} este divizibil cu 2 si 3, dar nu si cu 5");
            }
            else
            {
                Console.WriteLine($"Nr {number} nu indeplineste cerinta");
            }
        }
    }
}
