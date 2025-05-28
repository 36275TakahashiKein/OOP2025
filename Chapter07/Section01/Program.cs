namespace Section01 {
    internal class Program {
        static void Main(string[] args) {

            var books = Books.GetBooks();

            //①本の平均金額を表示 
            Console.WriteLine((int)books.Average(n => n.Price));

            //②本のページ合計を表示
            Console.WriteLine(books.Sum(n => n.Pages));


            //③金額の安い書籍と金額を表示
            //Console.WriteLine(books.Min(n => n.Price));
            //var book = (books.Min(n => n.Price));
            //Console.WriteLine(books.Where(n=> n.Price == book));
            var book = books.Where(x => x.Price == books.Min(b => b.Price));
            foreach (var item in book) {
                Console.WriteLine(item.Title + " : " + item.Price);
            }


            //④ページが多い書籍名とページ数を表示       
            foreach (var item in books.Where(x => x.Pages == books.Max(b => b.Pages))) {
                Console.WriteLine(item.Title + " : " + item.Pages); 
            }

            //⑤タイトルに「物語」が含まれている書籍名をすべて表示
            foreach (var bok in books.Where(n => n.Title.Contains("物語"))) {
                Console.WriteLine(bok.Title);
            }

        }
    }
}
