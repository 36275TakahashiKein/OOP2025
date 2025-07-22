
namespace Play {
    internal class Program {
        private static List<string> Looo = new List<string>();

        static void Main(string[] args) {
            // ここではアクセス修飾子は不要
            Looo.Add("選択肢A");
            Looo.Add("選択肢B");
            Looo.Add("選択肢A");
            Looo.Add("選択肢C");

            int a = Looo.Count;
            Console.WriteLine(a);

            // 動作確認用
            foreach (var item in Looo) {
                Console.WriteLine(item);
            }
        }

        private static void Task1() {
            
        }
    }
}
    