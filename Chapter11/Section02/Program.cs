using System.Text.RegularExpressions;

namespace Section02 {
    internal class Program {
        //正規表現
        static void Main(string[] args) {
            var strings = new[] {
                "Microsoft Windows",
                "windows",
                "Windows Server",
                "Windows",
            };

            var regex = new Regex(@"^(W|w)indows$");

            //パターンと完全一致している文字列の個数をカウント
            var count = strings.Count(s => regex.IsMatch(s));
            Console.WriteLine($"{count}行と一致");

            //パターンと完全一致している文字列を出力する
            foreach (var item in strings.Where(s => regex.IsMatch(s))) {
                Console.WriteLine(item);
            }
            
        }
    }
}
