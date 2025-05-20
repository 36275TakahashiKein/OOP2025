
namespace Exercise02 {
    internal class Program {
        static void Main(string[] args) {
            var cities = new List<string> {
                "Tokyo", "New Delhi", "Bangkok", "London",
                "Paris", "Berlin", "Canberra", "Hong Kong",
            };

            Console.WriteLine("***** 3.2.1 *****");
            Exercise2_1(cities);
            Console.WriteLine();

            Console.WriteLine("***** 3.2.2 *****");
            Exercise2_2(cities);
            Console.WriteLine();

            Console.WriteLine("***** 3.2.3 *****");
            Exercise2_3(cities);
            Console.WriteLine();

            Console.WriteLine("***** 3.2.4 *****");
            Exercise2_4(cities);
            Console.WriteLine();

        }

        private static void Exercise2_1(List<string> names) {
            Console.WriteLine("都市名を入力。空行で終了");
            while (true) {
                var name = Console.ReadLine();
                if (string.IsNullOrEmpty(name))
                    break;
                int index = names.FindIndex(s => s == name);
                Console.WriteLine(index);
            }
        }

        private static void Exercise2_2(List<string> names) {
            var exist = names.Count(s => s.Contains('o'));
            Console.WriteLine(exist);
        }

        private static void Exercise2_3(List<string> names) {
            var ggg = names.Where(s => s.Contains('o'));
            foreach (var name in ggg) {
                Console.WriteLine(name);
            }
        }

        private static void Exercise2_4(List<string> names) {
            var hhh = names
                .Where(s => s.StartsWith('B'))
                .Select(s => s.Length);
            foreach (var name in hhh) {
                Console.WriteLine(name);
            }
        }
    }
}
