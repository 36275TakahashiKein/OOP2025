
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
            /* var book3 = Library.Books
                 .GroupBy(b => b.PublishedYear)
                 .OrderByDescending(b => b.Key);
             foreach (var book3x in book3) {
                 Console.WriteLine($"{book3x.Key}年{book3x.Count()}");
             }*/

            var result = Library.Books
                .GroupBy(b => b.PublishedYear)
                .OrderBy(b => b.Key)
                .Select(b => new {
                    PublishYear = b.Key,
                    Count = b.Count()
                });

            foreach (var item in result) {
                Console.WriteLine($"{item.PublishYear}:{item.Count}");

            }
        }

        private static void Exercise1_4() {
            /*var book4 = Library.Books
                .GroupBy(b => b.PublishedYear)
                .OrderByDescending(b => b.Key);
            foreach (var book4x in book4) {
                var book4y = book4x
                    .GroupBy(b => b.Price)
                    .OrderByDescending(b => b.Key);
                foreach (var book4z in book4y) {
                    Console.WriteLine($"{book4z.Key}年");
                }
                
            }*/

            var book4x = Library.Books
                .OrderByDescending(b => b.PublishedYear)
                .ThenByDescending(b => b.Price);

            foreach (var item in book4x) {
                Console.WriteLine($"{item.PublishedYear}年{item.Price}{item.Title}");

            }
        }

        private static void Exercise1_5() {
            var books = Library.Books.Where(b => b.PublishedYear == 2022)
                .Join(Library.Categories
                        , b => b.CategoryId
                        , c => c.Id,
                        (b, c) => new {
                            c.Name
                        }).Distinct();

            foreach (var book in books) {
                Console.WriteLine($"{book}");
            }
        }

        private static void Exercise1_6() {
            var books = Library.Books
                 .Join(Library.Categories
                         , b => b.CategoryId
                         , c => c.Id,
                         (b, c) => new {
                             CategoryName = c.Name,
                             b.Title,
                         }).GroupBy(x => x.CategoryName)
                         .OrderBy(x => x.Key);

            foreach (var book in books) {
                Console.WriteLine($"#{book.Key}");
                foreach (var bok in book) {
                    Console.WriteLine($"{bok.Title}");
                }
            }
        }

        private static void Exercise1_7() {
            var books = Library.Categories
                .Where(x => x.Name.Equals("Development"))
                .Join(Library.Books
                        , c => c.Id
                        , b => b.CategoryId
                        ,
                        (c, b) => new {
                            b.Title,
                            b.PublishedYear,
                        })
                .GroupBy(x => x.PublishedYear)
                .OrderBy(x => x.Key)
                ;

            foreach (var book in books) {
                Console.WriteLine($"#{book.Key}");
                foreach (var bok in book) {
                    Console.WriteLine($"{bok.Title}");
                }
            }
        }

        private static void Exercise1_8() {

        }
    }
}
