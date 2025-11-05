using System.Text;

namespace Exercise01_Console {
    internal class Program {
        static async Task Main(string[] args) {
            string text = await TextReaderSample.ReadText("走れメロス.txt");
            Console.WriteLine(text);
            Console.WriteLine("End");
        }

        public class TextReaderSample {
            public static async Task<string> ReadText(string filePath) {
                var sb = new StringBuilder();
                // usingを使って自動的にファイルを閉じる
                using (var sr = new StreamReader(filePath, Encoding.UTF8)) {
                    while (!sr.EndOfStream) sb.AppendLine();

                    string? line = await sr.ReadLineAsync(); //117aл.2Hx4)
                    return sb.ToString();
                }
            }
        }
    }
}
