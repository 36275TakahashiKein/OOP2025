using TextFileProcessor;

namespace LineCounter {
    internal class Program {
        static void Main(string[] args) {
            Console.WriteLine("ファイルのパスを指定してください");
            string path = Console.ReadLine();
            TextProcessor.Run<LineCounterProcessor>(fileName: path);
        }
    }
}
