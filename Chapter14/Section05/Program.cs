namespace Section05 {
    internal class Program {
        static void Main(string[] args) {

            for (int i = 0; i < 5; i++) {
                Console.WriteLine($"処理{i}開始");
                Thread.Sleep(1000);
                Console.WriteLine($"処理{i}終了");
            }
        }
    }
}
