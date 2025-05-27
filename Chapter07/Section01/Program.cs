namespace Section01 {
    internal class Program {
        static void Main(string[] args) {

            var books = Books.GetBooks();

            //①本の平均金額を表示 
            Console.WriteLine((int)books.Average(n => n.Price));

            //②本のページ合計を表示
            Console.WriteLine(books.Sum(n => n.Pages));


            //③金額の安い書籍と金額を表示
            Console.WriteLine(books.Min(n => n.Price));
            var hh = (books.Min(n => n.Price));
            Console.WriteLine(books.Where(n=> n.Price == hh));
            

            //④ページが多い書籍名とページ数を表示

            //⑤タイトルに「物語」が含まれている書籍名をすべて表示
        }
    }
}
