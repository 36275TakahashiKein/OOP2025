namespace Exercise04 {
    internal class Program {
        static void Main(string[] args) {
            var line = "Novelist=谷崎潤一郎;BestWork=春琴抄;Born=1886";
            var words = line.Split('=', ';');
            for (int i = 0; i < words.Length - 1; i += 2) {
                Console.WriteLine(ToJapanese(words[i]) + ':' + words[i + 1]);
            }

        }

        /// <summary>
        /// 引数の単語を日本語へ変換します
        /// </summary>
        /// <param name="key">"Novelist","BestWork","Born"</param>
        /// <returns>"「作家」,「代表作」,「誕生年」</returns>
        static string ToJapanese(string key) {
            if (key == "Novelist") {
                return "作家";
            }
            if (key == "BestWork") {
                return "代表作";
            }
            if (key == "Born") {
                return "誕生年";
            }

            return ""; //エラーをなくすためのダミー
        }
    }
}

//作家: 谷崎潤一郎
//代表作:春琴抄
//誕生年:1886