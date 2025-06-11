
namespace Exercise01 {
    internal class Program {
        static void Main(string[] args) {
            var text = "Cozy lummox gives smart squid who asks for job pen";

            Exercise1(text);
            Console.WriteLine();

            Exercise2(text);

        }

        private static void Exercise1(string text) {
            //ディクショナリインスタンスの作成
            var dict = new Dictionary<char, int>();

            //textを大文字にしつつ、一文字ずつ取り出す、dictにAddする。
            foreach (var ch in text.ToUpper()) {
                if('A' <= ch && ch <= 'Z') {
                    //if、Keyが存在していたら。
                    if (dict.ContainsKey(ch)) {
                        var count = dict[ch];
                        dict.Remove(ch);
                        dict.Add(ch,count + 1);
                    } else {
                        dict.Add(ch,1);
                    }
                }
            }
            
            //出力処理
            foreach (var item in dict.OrderBy(s=> s.Key)) {
                Console.WriteLine($"'{item.Key}': {item.Value}");
            }
        }

        private static void Exercise2(string text) {
            
        }
    }
}
