
namespace Exercise01 {
    internal class Program {
        static void Main(string[] args) {
            Exercise1_2();
            Console.WriteLine();
            Exercise1_3();
            Console.WriteLine();
            Exercise1_4();
            Console.WriteLine();
            Exercise1_5();
            Console.WriteLine();
            Exercise1_6();
            Console.WriteLine();
            Exercise1_7();
            Console.WriteLine();
            Exercise1_8();

            Console.ReadLine();
        }

        private static void Exercise1_2() {
            var book2 = Library.Books
                .MaxBy(b => b.Price);
            Console.WriteLine(book2);
        }

        private static void Exercise1_3() {
            var book3 = Library.Books
                .GroupBy(b => b.PublishedYear)
                .OrderByDescending(b => b.Key);
            foreach (var book3s in book3) {
                Console.WriteLine($"{book3s.Key}");
                

            }
            
        }

        private static void Exercise1_4() {
            
        }

        private static void Exercise1_5() {
            
        }

        private static void Exercise1_6() {
            
        }

        private static void Exercise1_7() {
            
        }

        private static void Exercise1_8() {
            
        }
    }
}
