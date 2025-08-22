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

            //-----⑥-----
            //    Console.WriteLine(IsPhoneNumber("080-9111-1234"));
            //    Console.WriteLine(IsPhoneNumber("090-9111-1234"));
            //    Console.WriteLine(IsPhoneNumber("060-9111-1234"));
            //    Console.WriteLine(IsPhoneNumber("190-9111-1234"));
            //    Console.WriteLine(IsPhoneNumber("091-9111-1234"));
            //    Console.WriteLine(IsPhoneNumber("090-9111-12341"));
            //    Console.WriteLine(IsPhoneNumber("090-911-1234"));
            //    Console.WriteLine(IsPhoneNumber("090-1911-234"));
            //}

            //private static bool IsPhoneNumber(string telNum) {
            //    return Regex.IsMatch(telNum, @"^(070|080|090)-\d{4}-\d{4}$");
            //}
            //-----⑥終わり-----

            //電話番号かどうかを判別するプログラム。
            //「private static bool IsPhoneNumber(string telNum)」メソッドは携帯電話番号か判別する条件式メソッド。
            //「@"^(080|090|070)-\d{4}-\d{4}$"」は、
            //「^(080|090|070)」で、「^」の行頭の最初の文字を選別する条件式で、
            //先頭文字が「070」or「080」or「090」かで、選定してる。
            //「-\d{4}-\d{4}$」は、「$」で、行末の文字列が「～$」、「～」の部分の文字列が一致しているか判別している。
            //「$」が書かれている時点で行末が「-\d{4}-\d{4}」と一致しているか秤にかけられている。
            //「\d」は「0から9までの数字1文字と一致する」かどうかを判別する正規表現の特殊文字で、
            //「\d{4}」なので、文字列が四連続で0～9いずれかに該当するかを判別している。
            //今回の命題は、
            //「指定された文字列が携帯電話の電話番号かどうかを判定するメソッドを定義してください。
            //電話番号は必ずハイフン（-）で区切られていなければなりません。
            //また、先頭3文字は"090"、"080"、"070"のいずれかとします。」
            //だ。
            //実行結果は、「"080-9111-1234"」と「"090-9111-1234"」がtrueとして返される。

            //-----⑦-----
            //Console.WriteLine(IsPhoneNumber("080-9111-1234"));
            //Console.WriteLine(IsPhoneNumber("090-9111-1234"));
            //Console.WriteLine(IsPhoneNumber("060-9111-1234"));
            //Console.WriteLine(IsPhoneNumber("190-9111-1234"));
            //Console.WriteLine(IsPhoneNumber("091-9111-1234"));
            //Console.WriteLine(IsPhoneNumber("090-9111-12341"));
            //Console.WriteLine(IsPhoneNumber("090-911-1234"));
            //Console.WriteLine(IsPhoneNumber("090-1911-234"));
            //}

            //private static bool IsPhoneNumber(string telNum) {
            //    return Regex.IsMatch(telNum, @"^0[7-9]0-\d{4}-\d{4}$");
            //}
            //-----⑦終わり-----
            //⑥の「 @"^(070|080|090)-\d{4}-\d{4}$"」が「@"^0[7-9]0-\d{4}-\d{4}$"」に変わっている。
            //「[7-9]」7～9の半角文字列文字列と一致するか判別している。

            //-----⑧-----
            //var text = "RegexクラスのMatchメソッドを使います";
            //
            //Match match = Regex.Match(text, @"\p{IsKatakana}+");
            //if (match.Success)//Successはあっていた場合
            //    Console.WriteLine($"{match.Index},{match.Value}");
            //
            //var matches = Regex.Matches(text, @"\p{IsKatakana}+");
            //foreach (Match match2 in matches) {
            //    Console.WriteLine($"Index={match2.Index},Length={match2.Length},Value={match2.Value}");
            //}
            //-----⑧終わり-----

            //実行結果は「
            //5,クラス
            //Index = 5,Length = 3,Value = クラス
            //Index = 14,Length = 4,Value = メソッド
            //」
            //「if (match.Success)
            //    Console.WriteLine($"{match.Index},{match.Value}");」の
            //実行結果が、
            //「5,クラス」だ。

            //「foreach (Match match2 in matches) {
            //    Console.WriteLine($"Index={match2.Index},Length={match2.Length},Value={match2.Value}");
            //}」の
            //実行結果が、「
            //Index = 5,Length = 3,Value = クラス
            //Index = 14,Length = 4,Value = メソッド
            //」だ。
            //「Match match = Regex.Match(text, @"\p{IsKatakana}+");」の
            //「\p{IsKatakana}+」でカタカナかどうかを判別してる。

            //-----⑨-----
            /*  string filePath = "sample.txt";
                Pickup3DightNumber(filePath);
            }

            private static void Pickup3DightNumber(string filePath) {
                foreach (var line in File.ReadLines(filePath)) {
                    var matches = Regex.Matches(line, @"\b\d{3,}\b");

                    foreach (Match m in matches) {
                        Console.WriteLine($"Index={m.Index},Length={m.Length},Value={m.Value}");//結果を出力
                    }
                }
            }
            */

            /*sample.txtの中身
                H123 4567 9876 as 23
                top 59128 jello time 405
                add remove insert 432 567 890M 4 54*/
            //-----⑨終わり-----
            /*実行結果
                Index = 5, Length = 4, Value = 4567
                Index = 10,Length = 4,Value = 9876
                Index = 4,Length = 5,Value = 59128
                Index = 21,Length = 3,Value = 405
                Index = 18,Length = 3,Value = 432
                Index = 22,Length = 3,Value = 567
            */
            //命題
            //「テキストファイルを読み込み、3文字以上の数字だけからなる部分文字列をすべて抜き出すコードを書いてください。」
            //「@"\b\d{3,}\b"」で「3文字以上の数字だけからなる部分文字列をすべて抜き出す」をしている。
            //「\b」
            //「\d」
            //「{3,n}」

            /*秀丸
            「Ctrl + F」 →　正規表現
            「\y\d{ 3,}\y」で検索。
            →でいろいろ検索。*/

            //やること「⑨」「⑩はExercise03」、「⑪はSection3の追加メソッド」


        }
    }
}
