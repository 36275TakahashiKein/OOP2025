using System.Text.RegularExpressions;

namespace Section00 {
    internal class Program {
        //正規表現

        
        static void Main(string[] args) {

            //-----①-----
            var text = "orivate List<string> results = new List<string>();";
            
            bool isMatch = Regex.IsMatch(text, @"List<\w+>");
            if (isMatch)
                Console.WriteLine("見つかりました");
            else
                Console.WriteLine("見つかりません");
            //-----①終わり-----

            //var text = "orivate List<string> results = new List<string>();";
            //                           ↑                         ↑
            //                      　  ここ           と          ここ
            //                      　  に文字無いと「"見つかりません"」に判定される。

            //もう一つの書き方として②のパターンがある。

            //-----②-----
            //var text = "orivate List<string> results = new List<string>();";

            //var regex = new Regex(@"List<\w+>");

            //bool isMatch = regex.IsMatch(text);

            //if (isMatch)
            //    Console.WriteLine("見つかりました");
            //else
            //    Console.WriteLine("見つかりません");
            //-----②終わり-----

            //これは、
            //「bool isMatch = Regex.IsMatch(text, @"List<\w+>");」
            //のところが、
            //「var regex = new Regex(@"List<\w+>");」
            //「bool isMatch = regex.IsMatch(text);」
            //になっている


            //-----③-----
            //    var text = "orivate List<string> results = new List<string>();";

            //    bool isMatch = IsPatternText(text, @"List<\w+>");

            //    if (isMatch)
            //        Console.WriteLine("見つかりました");
            //    else
            //        Console.WriteLine("見つかりません");

            //}

            ////指定したパターンに一致した部分文字列があるか判定するメソッド
            //static bool IsPatternText(string text, string pattern) {
            //    return Regex.IsMatch(text, pattern);
            //}
            //-----③終わり-----

            //③はメソッド化してる。
            //static bool IsPatternText(string text, string pattern) {
            //のところで、一致する文字があったらtrueで返して、ない場合falseで返す(return)。

            //-----④-----
            //var strings = new[] {
            //    "Microsoft Windows",
            //    "windows",
            //    "Windows Server",
            //    "Windows",
            //};

            //var regex = new Regex(@"^(W|w)indows$");

            ////パターンと完全一致している文字列の個数をカウント
            //var count = strings.Count(s => regex.IsMatch(s));
            //Console.WriteLine($"{count}行と一致");
            //-----④終わり-----

            //var regex = new Regex(@"^(W|w)indows$");は、
            //「^」で行頭の文字列を指定する。
            //「(W|w)」は「W」または(or)「w」が条件に当てはまることを明記している。だから、
            //「^(W|w)」で先頭文字に「W」or「w」がある文字列が最初にTrueで選ばれる。
            //「$」で行末の文字列を指定する。「indows$」の場合、行末が「○○indows」で終わる文字列が判定される。
            //つまり「Regex(@"^(W|w)indows$");」は「Windows」と「windows」が該当する。
            //「.Count」なので、出力結果は「２」になる。

            //-----⑤-----
            //var strings = new[] {
            //    "Microsoft Windows",
            //    "windows",
            //    "Windows Server",
            //    "Windows",
            //};

            //var regex = new Regex(@"^(W|w)indows$");

            ////パターンと完全一致している文字列の個数をカウント
            //var count = strings.Count(s => regex.IsMatch(s));
            //Console.WriteLine($"{count}行と一致");

            ////パターンと完全一致している文字列を出力する
            //foreach (var item in strings.Where(s => regex.IsMatch(s))) {
            //    Console.WriteLine(item);
            //}
            //-----⑤終わり-----

            //これは④から、
            //「パターンと完全一致している文字列を出力する
            //foreach (var item in strings.Where(s => regex.IsMatch(s))) {
            //    Console.WriteLine(item);
            //}」
            //のメソッドを追加した。
            //「.Count(s => regex.IsMatch(s))」の、「.Count」のところを
            //「.Where(s => regex.IsMatch(s)」で、「.Where」に変えて、
            //文字列を出力する形に変化している。


        }
    }
}
